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

 public class TipoMovimientoController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public TipoMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoMovimientoDto>>> Get()
    {
        var Con = await  _unitofwork.TipoMovimientos.GetAllAsync();
        return _mapper.Map<List<TipoMovimientoDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoMovimientoDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.TipoMovimientos.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<TipoMovimientoDto>>(pag.registros);
        return new Pager<TipoMovimientoDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }




    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.TipoMovimientos.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoMovimiento>> Post(TipoMovimientoDto tipomovimientoDto){
        var tipomovimiento = _mapper.Map<TipoMovimiento>(tipomovimientoDto);
        this._unitofwork.TipoMovimientos.Add(tipomovimiento);
        await _unitofwork.SaveAsync();
        if(tipomovimiento == null)
        {
            return BadRequest();
        }
        tipomovimientoDto.Id = tipomovimiento.Id;
        return CreatedAtAction(nameof(Post),new {id= tipomovimientoDto.Id}, tipomovimientoDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoMovimiento>> Put(int id, [FromBody]TipoMovimiento rol){
        if(rol == null)
            return NotFound();
        _unitofwork.TipoMovimientos.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.TipoMovimientos.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.TipoMovimientos.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}