using Infra.Data.DataBaseContext;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Ong;

namespace Infra.Data.Repository.ReadRepository;

public class OngReadRepository : BaseReadRepository<Ong>,IOngReadRepository
{
    public OngReadRepository(Context context) : base(context)
    {
    }
}