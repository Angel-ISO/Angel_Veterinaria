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

 public class CitaController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public CitaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CitaDto>>> Get()
    {
        var Con = await  _unitofwork.Citas.GetAllAsync();
        return _mapper.Map<List<CitaDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CitaDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Citas.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<CitaDto>>(pag.registros);
        return new Pager<CitaDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }




    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Citas.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cita>> Post(CitaDto citaDto){
        var cita = _mapper.Map<Cita>(citaDto);
        this._unitofwork.Citas.Add(cita);
        await _unitofwork.SaveAsync();
        if(cita == null)
        {
            return BadRequest();
        }
        citaDto.Id = cita.Id;
        return CreatedAtAction(nameof(Post),new {id= citaDto.Id}, citaDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cita>> Put(int id, [FromBody]Cita rol){
        if(rol == null)
            return NotFound();
        _unitofwork.Citas.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Citas.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Citas.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}