using WebApi.Data.Contexto;
using WebApiLeao.Domain.Entities;
using WebApiLeao.Repository.BaseGeneric;
using WebApiLeao.Repository.Interface;

namespace WebApiLeao.Repository.Repository
{
    public class CursosRepository : BaseRepository<EntityCursos>, ICursosRepository
    {
        public CursosRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
