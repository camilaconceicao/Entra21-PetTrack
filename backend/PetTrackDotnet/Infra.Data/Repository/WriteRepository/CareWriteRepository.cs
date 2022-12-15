using Infra.Data.DataBaseContext;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Care;

namespace Infra.Data.Repository.WriteRepository;

public class CareWriteRepository : BaseWriteRepository<Care>, ICareWriteRepository
{
    public CareWriteRepository(Context context) : base(context)
    {
    }
}