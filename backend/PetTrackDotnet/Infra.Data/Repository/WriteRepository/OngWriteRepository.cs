using Infra.Data.DataBaseContext;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Ong;

namespace Infra.Data.Repository.WriteRepository;

public class OngWriteRepository : BaseWriteRepository<Ong>, IOngWriteRepository
{
    public OngWriteRepository(Context context) : base(context)
    {
    }
}