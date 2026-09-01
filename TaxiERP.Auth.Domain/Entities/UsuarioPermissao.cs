

namespace TaxiERP.Auth.Domain.Entities
{
    public class UsuarioPermissao
    {
        public Guid UsuarioId { get; private set; }
        public Guid PermissaoId { get; private set; }

        public Usuario Usuario { get; private set; }
        public Permissao Permissao { get; private set; }

        protected UsuarioPermissao() { }

        public UsuarioPermissao(Guid usuarioId, Guid permissaoId)
        {
            UsuarioId = usuarioId;
            PermissaoId = permissaoId;
        }
    }
}
