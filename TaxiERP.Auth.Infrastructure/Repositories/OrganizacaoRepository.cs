
using Microsoft.EntityFrameworkCore;
using TaxiERP.Auth.Domain.Entities;
using TaxiERP.Auth.Domain.Interfaces;
using TaxiERP.Auth.Infrastructure.Data;

namespace TaxiERP.Auth.Infrastructure.Repositories
{
    public class OrganizacaoRepository : BaseRepository, IOrganizacaoRepository
    {
        public OrganizacaoRepository(AppDbContext context) : base(context) {}
        public async Task<Organizacao?> BuscarPorId(Guid id)
        {
            return await _context.Organizacoes.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task Adicionar(Organizacao organizacao)
        {
           await _context.Organizacoes.AddAsync(organizacao);
        }
    }
}
