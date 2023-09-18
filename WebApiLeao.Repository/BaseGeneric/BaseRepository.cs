using Microsoft.EntityFrameworkCore;
using WebApi.Data.Contexto;

namespace WebApiLeao.Repository.BaseGeneric
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            _dataContext.Set<T>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dataContext.Set<T>().AsNoTracking().ToListAsync(); //asNoTraking importante colocar para a consulta ficar mais rápida
        }

        public async Task<T> GetById(int Id)
        {
            return await _dataContext.Set<T>().FindAsync(x => x.Id == Id);
        }

        public async Task Insert(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(int Id, T entity)
        {
            _dataContext.Set<T>().Update(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
