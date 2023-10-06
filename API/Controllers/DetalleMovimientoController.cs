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

 public class DetalleMovimientoController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public DetalleMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleMovimientoDto>>> Get()
    {
        var Con = await  _unitofwork.DetalleMovimientos.GetAllAsync();
        return _mapper.Map<List<DetalleMovimientoDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleMovimientoDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.DetalleMovimientos.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<DetalleMovimientoDto>>(pag.registros);
        return new Pager<DetalleMovimientoDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }




    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.DetalleMovimientos.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleMovimiento>> Post(DetalleMovimientoDto detallemovimientoDto){
        var detallemovimiento = _mapper.Map<DetalleMovimiento>(detallemovimientoDto);
        this._unitofwork.DetalleMovimientos.Add(detallemovimiento);
        await _unitofwork.SaveAsync();
        if(detallemovimiento == null)
        {
            return BadRequest();
        }
        detallemovimientoDto.Id = detallemovimiento.Id;
        return CreatedAtAction(nameof(Post),new {id= detallemovimientoDto.Id}, detallemovimientoDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleMovimiento>> Put(int id, [FromBody]DetalleMovimiento rol){
        if(rol == null)
            return NotFound();
        _unitofwork.DetalleMovimientos.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.DetalleMovimientos.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.DetalleMovimientos.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}