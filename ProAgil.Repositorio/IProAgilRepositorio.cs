using System.Threading.Tasks;
using ProAgil.Dominio;

namespace ProAgil.Repositorio
{
    public interface IProAgilRepositorio
    {
        //GERAL
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> SaveChangesAsync();
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes = false);
        Task<Evento> GetAllEventoAsyncById(int id, bool includePalestrantes = false);

        Task<Palestrante[]> GetAllPalestrantAsyncByName(string name);
        Task<Palestrante> GetPalestranteAsync(int id);
    }
}