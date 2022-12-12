using Infraestrutura.DataBaseContext;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.Ong;

namespace Infraestrutura.Repository.ReadRepository;

public class OngReadRepository : BaseReadRepository<Ong>,IOngReadRepository
{
    public OngReadRepository(Context context) : base(context)
    {
    }
}