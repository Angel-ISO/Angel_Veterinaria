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

 public class ProoveedorController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public ProoveedorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProoveedoDto>>> Get()
    {
        var Con = await  _unitofwork.Prooveedores.GetAllAsync();
        return _mapper.Map<List<ProoveedoDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ProoveedoDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Prooveedores.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<ProoveedoDto>>(pag.registros);
        return new Pager<ProoveedoDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }




    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Prooveedores.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Proveedor>> Post(ProoveedoDto prooveedorDto){
        var prooveedor = _mapper.Map<Proveedor>(prooveedorDto);
        this._unitofwork.Prooveedores.Add(prooveedor);
        await _unitofwork.SaveAsync();
        if(prooveedor == null)
        {
            return BadRequest();
        }
        prooveedorDto.Id = prooveedor.Id;
        return CreatedAtAction(nameof(Post),new {id= prooveedorDto.Id}, prooveedorDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Proveedor>> Put(int id, [FromBody]Proveedor rol){
        if(rol == null)
            return NotFound();
        _unitofwork.Prooveedores.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Prooveedores.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Prooveedores.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}