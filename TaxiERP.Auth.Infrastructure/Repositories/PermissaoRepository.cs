using Microsoft.EntityFrameworkCore;
using TaxiERP.Auth.Domain.Entities;
using TaxiERP.Auth.Domain.Interfaces;
using TaxiERP.Auth.Infrastructure.Data;

namespace TaxiERP.Auth.Infrastructure.Repositories
{
    public class PermissaoRepository : BaseRepository, IPermissaoRepository
    {
        public PermissaoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Permissao>> BuscarTodasAsync()
        {
            return await _context.Permissao.ToListAsync();
        }
    }
}
