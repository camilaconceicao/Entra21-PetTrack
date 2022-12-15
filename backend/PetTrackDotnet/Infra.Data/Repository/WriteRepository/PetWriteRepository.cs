using Infra.Data.DataBaseContext;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Pet;

namespace Infra.Data.Repository.WriteRepository;

public class PetWriteRepository : BaseWriteRepository<Pet>, IPetWriteRepository
{
    public PetWriteRepository(Context context) : base(context)
    {
    }
}