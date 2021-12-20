﻿using NLayerProject.Core.Repositories;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public IProductRepository productRepository => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository categoryRepository => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
             await _context.SaveChangesAsync();
        }
    }
}
