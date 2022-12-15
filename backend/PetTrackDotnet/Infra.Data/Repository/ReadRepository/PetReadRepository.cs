using Infra.Data.DataBaseContext;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Pet;

namespace Infra.Data.Repository.ReadRepository;

public class PetReadRepository : BaseReadRepository<Pet>,IPetReadRepository
{
    public PetReadRepository(Context context) : base(context)
    {
    }
}