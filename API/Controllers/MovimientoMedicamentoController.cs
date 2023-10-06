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

 public class MovimientoMedicamentoController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public MovimientoMedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MovimientoMedicamentoDto>>> Get()
    {
        var Con = await  _unitofwork.MovimientoMedicamentos.GetAllAsync();
        return _mapper.Map<List<MovimientoMedicamentoDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MovimientoMedicamentoDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.MovimientoMedicamentos.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<MovimientoMedicamentoDto>>(pag.registros);
        return new Pager<MovimientoMedicamentoDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }




    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.MovimientoMedicamentos.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicamento>> Post(MovimientoMedicamentoDto movimiendomedicamentoDto){
        var movimientomedicamento = _mapper.Map<MovimientoMedicamento>(movimiendomedicamentoDto);
        this._unitofwork.MovimientoMedicamentos.Add(movimientomedicamento);
        await _unitofwork.SaveAsync();
        if(movimientomedicamento == null)
        {
            return BadRequest();
        }
        movimiendomedicamentoDto.Id = movimientomedicamento.Id;
        return CreatedAtAction(nameof(Post),new {id= movimiendomedicamentoDto.Id}, movimiendomedicamentoDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicamento>> Put(int id, [FromBody]MovimientoMedicamento rol){
        if(rol == null)
            return NotFound();
        _unitofwork.MovimientoMedicamentos.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.MovimientoMedicamentos.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.MovimientoMedicamentos.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}