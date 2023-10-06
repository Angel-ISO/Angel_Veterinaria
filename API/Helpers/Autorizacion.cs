namespace API.Helpers;

    public class Autorizacion
    {
        public enum Rols
        {
            Administrador,
            Gerente,
            Veterinario,
            propietario
        }
        public const Rols Rol_PorDefecto = Rols.propietario;
    }