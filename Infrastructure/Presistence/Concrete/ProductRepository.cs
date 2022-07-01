using Application.Abstract;
using Domain.Entities;
using Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
