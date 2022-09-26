using PeliculasApi.Dtos;

namespace PeliculasApi.Helpers
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Paginar <T>(this IQueryable<T> queryble, PaginacionDTO paginacionDTO)
        {
            return queryble.Skip((paginacionDTO.Pagina-1)*paginacionDTO.cantidadRegistrosPorPagina).Take(paginacionDTO.cantidadRegistrosPorPagina);
        }
    }
}