using DAL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
        RepositoryContext.Set<T>()
        .AsNoTracking() :
        RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
             !trackChanges ?
             RepositoryContext.Set<T>() // Чтобы данные не помещались в кэш,
             .Where(expression)
             .AsNoTracking() :  //Коли встановлено значення false, ми приєднайте метод AsNoTracking до нашого запиту, щоб повідомити EF Core, що не потрібно відстежувати зміни для необхідних об'єктів. Це сильно підвищує швидкість запиту.
             RepositoryContext.Set<T>()
             .Where(expression);
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
