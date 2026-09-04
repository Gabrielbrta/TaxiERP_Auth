using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Infrastructure.Data;

namespace TaxiERP.Auth.Infrastructure.Repositories
{
    public abstract class BaseRepository 
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context) {
            _context = context;
        }
    }
}
