using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Domain.Entities;
using TaxiERP.Auth.Domain.Interfaces;
using TaxiERP.Auth.Infrastructure.Data;

namespace TaxiERP.Auth.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository 
    {
        public UsuarioRepository(AppDbContext context) : base(context) { }
        public async Task<Usuario?> BuscarPorEmail(string email)
        {
            return await _context.Usuarios
                .Include(u => u.UsuarioPermissoes)
                .ThenInclude(up => up.Permissao)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> BuscarPorId(Guid id)
        {
            return await _context.Usuarios
                .Include(u => u.UsuarioPermissoes)
                .ThenInclude(up => up.Permissao)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public async Task Desativar(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if(usuario != null)
            {
                usuario.DeletedAt = DateTime.UtcNow;
            }
        }
    }
}
