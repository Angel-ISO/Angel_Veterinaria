using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize]

 public class TratamientoMedicoController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public TratamientoMedicoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TratamientoMedicoDto>>> Get()
    {
        var Con = await  _unitofwork.TratamientosMedicos.GetAllAsync();
        return _mapper.Map<List<TratamientoMedicoDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TratamientoMedicoDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.TratamientosMedicos.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<TratamientoMedicoDto>>(pag.registros);
        return new Pager<TratamientoMedicoDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }




    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.TratamientosMedicos.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TratamientosMedico>> Post(TratamientoMedicoDto tratamientomedicoDto){
        var tratamientomedico = _mapper.Map<TratamientosMedico>(tratamientomedicoDto);
        this._unitofwork.TratamientosMedicos.Add(tratamientomedico);
        await _unitofwork.SaveAsync();
        if(tratamientomedico == null)
        {
            return BadRequest();
        }
        tratamientomedicoDto.Id = tratamientomedico.Id;
        return CreatedAtAction(nameof(Post),new {id= tratamientomedicoDto.Id}, tratamientomedicoDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TratamientosMedico>> Put(int id, [FromBody]TratamientosMedico rol){
        if(rol == null)
            return NotFound();
        _unitofwork.TratamientosMedicos.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.TratamientosMedicos.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.TratamientosMedicos.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}