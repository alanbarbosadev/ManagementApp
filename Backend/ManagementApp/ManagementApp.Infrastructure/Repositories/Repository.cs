﻿using ManagementApp.Application.Repositories;
using ManagementApp.Application.Specifications;
using ManagementApp.Domain.Models;
using ManagementApp.Infrastructure.DataContext;
using ManagementApp.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ManagementAppContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ManagementAppContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(IBaseSpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecificationAsync(IBaseSpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(IBaseSpecification<T> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Add(entity);

            await SaveChangesAsync();

            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(IBaseSpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), specification);
        }
    }
}
