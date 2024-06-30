﻿using EBook.DataAccess.NetCore.DBContext;
using EBook.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.Services
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EBookDBContext _dbContext;

        public  GenericRepository(EBookDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(T entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }

        public async Task<List<T>> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable().ToList();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }

}