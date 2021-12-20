﻿using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository productRepository { get; }
        ICategoryRepository categoryRepository { get; }

        Task CommitAsync();
        void Commit();
    }
}
