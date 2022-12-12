using Infraestrutura.DataBaseContext;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.Pet;

namespace Infraestrutura.Repository.WriteRepository;

public class PetWriteRepository : BaseWriteRepository<Pet>, IPetWriteRepository
{
    public PetWriteRepository(Context context) : base(context)
    {
    }
}