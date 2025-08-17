﻿using Microsoft.EntityFrameworkCore.Update.Internal;
using MyMvc.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Data.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void update(Product product);
    }
}
