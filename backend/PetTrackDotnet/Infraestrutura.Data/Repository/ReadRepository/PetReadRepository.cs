using Infraestrutura.DataBaseContext;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.Pet;

namespace Infraestrutura.Repository.ReadRepository;

public class PetReadRepository : BaseReadRepository<Pet>,IPetReadRepository
{
    public PetReadRepository(Context context) : base(context)
    {
    }
}