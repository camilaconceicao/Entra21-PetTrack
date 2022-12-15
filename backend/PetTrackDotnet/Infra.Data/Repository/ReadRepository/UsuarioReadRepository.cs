using Infra.Data.DataBaseContext;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Usuario;

namespace Infra.Data.Repository.ReadRepository;

public class UsuarioReadRepository : BaseReadRepository<Usuario>,IUsuarioReadRepository
{
    public UsuarioReadRepository(Context context) : base(context)
    {
    }
}