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

 public class EspecieController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public EspecieController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EspecieDto>>> Get()
    {
        var Con = await  _unitofwork.Especies.GetAllAsync();
        return _mapper.Map<List<EspecieDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EspecieDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Especies.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<EspecieDto>>(pag.registros);
        return new Pager<EspecieDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }




    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Especies.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Especie>> Post(EspecieDto especieDto){
        var especie = _mapper.Map<Especie>(especieDto);
        this._unitofwork.Especies.Add(especie);
        await _unitofwork.SaveAsync();
        if(especie == null)
        {
            return BadRequest();
        }
        especieDto.Id = especie.Id;
        return CreatedAtAction(nameof(Post),new {id= especieDto.Id}, especieDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Especie>> Put(int id, [FromBody]Especie rol){
        if(rol == null)
            return NotFound();
        _unitofwork.Especies.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Especies.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Especies.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}