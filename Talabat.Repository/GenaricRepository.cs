using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    internal class GenaricRepository<T> : IGenaricRerpository<T> where T : BaseEntity
    {
        private StoreContext _dbcontext;

        public GenaricRepository(StoreContext DbContext) { // ask clr to create object from dbcontext

            _dbcontext = DbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }
    }
}
