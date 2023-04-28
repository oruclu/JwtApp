﻿using System;
using System.Linq.Expressions;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace JwtApp.Persistance.Repositories
{
	public class Repository<T> : IRepository<T> where T : class, new()
	{
		public Repository(JwtAppContext jwtAppContext)
		{
            _context = jwtAppContext;
		}

        private readonly JwtAppContext _context;

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

