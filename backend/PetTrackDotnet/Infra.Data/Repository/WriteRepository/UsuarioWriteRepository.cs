using Infra.Data.DataBaseContext;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Usuario;

namespace Infra.Data.Repository.WriteRepository;

public class UsuarioWriteRepository : BaseWriteRepository<Usuario>, IUsuarioWriteRepository
{
    public UsuarioWriteRepository(Context context) : base(context)
    {
    }
}