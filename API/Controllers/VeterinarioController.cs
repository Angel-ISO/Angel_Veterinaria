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
[ApiVersion("1.2")]
[Authorize]
 public class VeterinarioController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public VeterinarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> Get()
    {
        var Con = await  _unitofwork.Veterinarios.GetAllAsync();
        return _mapper.Map<List<VeterinarioDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<VeterinarioDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Veterinarios.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<VeterinarioDto>>(pag.registros);
        return new Pager<VeterinarioDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }




    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Veterinarios.GetByIdAsync(id);
        return Ok(byidC);
    }




     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Veterinario>> Post(VeterinarioDto veterinarioDto){
        var veterinario = _mapper.Map<Veterinario>(veterinarioDto);
        this._unitofwork.Veterinarios.Add(veterinario);
        await _unitofwork.SaveAsync();
        if(veterinario == null)
        {
            return BadRequest();
        }
        veterinarioDto.Id = veterinario.Id;
        return CreatedAtAction(nameof(Post),new {id= veterinarioDto.Id}, veterinarioDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Veterinario>> Put(int id, [FromBody]Veterinario rol){
        if(rol == null)
            return NotFound();
        _unitofwork.Veterinarios.Update(rol);
        await _unitofwork.SaveAsync();
        return rol;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Veterinarios.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Veterinarios.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }




    //consultas especificas = veterinario 



   [HttpGet]
   [MapToApiVersion("1.2")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetcirujanoBascular(string especialidad)
    {
        try
        {
            var cirgBascular = await _unitofwork.Veterinarios.GetVeterinarioCardioVascular(especialidad);
            return Ok(cirgBascular);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }
        

   
}