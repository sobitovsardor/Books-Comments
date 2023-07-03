﻿using Books_Comments.Domain.Commons;
using System.Linq.Expressions;

namespace Books_Comments.DataAccess.Interfaces;

public interface IGenericRepository<T> : IRepository<T> where T : BaseEntity
{
    public IQueryable<T> GetAll();

    public IQueryable<T> Where(Expression<Func<T, bool>> expression);
}
