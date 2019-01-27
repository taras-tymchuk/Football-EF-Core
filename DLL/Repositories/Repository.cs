using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class Repository<TEntity, TContext>
        : IRepository<TEntity> where TEntity : class
                               where TContext : DbContext
    {
        private DbSet<TEntity> entities;

        protected TContext Context;

        public Repository( TContext context )
        {
            Context = context;
            entities = Context.Set<TEntity>();
        }

        public void Add( TEntity entity )
        {
            entities.Add( entity );
        }

        public void AddRange( IEnumerable<TEntity> entities )
        {
            this.entities.AddRange( entities );
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public TEntity GetById( int id )
        {
            return entities.Find( id );
        }

        public void Remove( TEntity entity )
        {
            entities.Remove( entity );
        }

        public void RemoveRange( IEnumerable<TEntity> entities )
        {
            this.entities.RemoveRange( entities );
        }

        public IEnumerable<TEntity> Find( 
                Expression<Func<TEntity, bool>> predicate )
        {
            return entities.Where( predicate ).ToList();
        }
    }
}
