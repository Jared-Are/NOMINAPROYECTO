﻿using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace migracio_api.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<T> GetById(int id);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
        Task<bool> ExistsAsync(Expression<Func<T, bool>>? filter = null);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}

