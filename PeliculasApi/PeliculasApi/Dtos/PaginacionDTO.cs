namespace PeliculasApi.Dtos
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        public int cantidadRegistrosPorPagina = 10;
        private readonly int cantidadMaximaRegistroPorPagina = 50;

        public int CantidadRegistrosPorPagina
        {
            get => CantidadRegistrosPorPagina;
            set
            {
                cantidadRegistrosPorPagina= (value > cantidadMaximaRegistroPorPagina) ?cantidadMaximaRegistroPorPagina : value;
            }
        }


        


    }
}