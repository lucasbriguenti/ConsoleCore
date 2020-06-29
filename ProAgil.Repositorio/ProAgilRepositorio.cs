using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Dominio;

namespace ProAgil.Repositorio
{
    public class ProAgilRepositorio : IProAgilRepositorio
    {
        private readonly ProAgilContext _context;

        public ProAgilRepositorio(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Add(entity);
        }
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            if(includePalestrantes)
            {
                query = query
                .Include(c => c.PalestranteEventos)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.OrderByDescending(x => x.DataEvento);
            return await query.ToArrayAsync();

        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            if(includePalestrantes)
            {
                query = query
                .Include(c => c.PalestranteEventos)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.OrderByDescending(x => x.DataEvento)
                        .Where(x => x.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventoAsyncById(int id, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            if(includePalestrantes)
            {
                query = query
                .Include(c => c.PalestranteEventos)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.OrderByDescending(x => x.DataEvento)
                        .Where(x => x.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantAsyncByName(string name)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais)
                .Include(c => c.PalestranteEventos)
                .ThenInclude(pe => pe.Evento);
            
            return await query.Where(x => x.Nome.ToLower().Contains(name.ToLower())).ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteAsync(int id)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(x => x.RedesSociais)
                .Include(x => x.PalestranteEventos)
                .ThenInclude(x => x.Evento);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}