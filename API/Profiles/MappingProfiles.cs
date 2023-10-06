using AutoMapper;
using Domain.Entities;
using API.Dtos;

namespace ApiJwt.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
     { 
            CreateMap<Rol, RolDto>()
            .ReverseMap();

             CreateMap<Cita, CitaDto>()
            .ReverseMap();

             CreateMap<DetalleMovimiento, DetalleMovimientoDto>()
            .ReverseMap();
            
             CreateMap<Especie, EspecieDto>()
            .ReverseMap();
            
             CreateMap<Laboratorio, LaboratorioDto>()
            .ReverseMap();

             CreateMap<Mascota, MascotaDto>()
            .ReverseMap();

             CreateMap<Medicamento, MedicamentoDto>()
            .ReverseMap();

             CreateMap<MovimientoMedicamento, MovimientoMedicamentoDto>()
            .ReverseMap();

             CreateMap<Proveedor, ProoveedoDto>()
            .ReverseMap();

             CreateMap<Propietario, PropietarioDto>()
            .ReverseMap();

             CreateMap<Raza, RazaDto>()
            .ReverseMap();


             CreateMap<TipoMovimiento, TipoMovimientoDto>()
            .ReverseMap();


             CreateMap<TratamientosMedico, TratamientoMedicoDto>()
            .ReverseMap();


             CreateMap<Veterinario, VeterinarioDto>()
            .ReverseMap();


           

    }
}