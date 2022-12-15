using Infra.Data.DataBaseContext;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Care;

namespace Infra.Data.Repository.ReadRepository;

public class CareReadRepository : BaseReadRepository<Care>,ICareReadRepository
{
    public CareReadRepository(Context context) : base(context)
    {
    }
}