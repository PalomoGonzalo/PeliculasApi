using Microsoft.EntityFrameworkCore;

namespace PeliculasApi.Helpers
{
    public static class HttpContextExtension
    {
        public async static Task InsertarParametrosPorPaginacion<T>(this HttpContext httpContext,IQueryable<T> queryable,int cantidadDeRegistros)
        {
            double cantidad= await queryable.CountAsync();
            double cantidadPaginas= Math.Ceiling(cantidad/cantidadDeRegistros);
            httpContext.Response.Headers.Add("cantidadPaginas", cantidadPaginas.ToString());
        }
    }
}