using Infraestrutura.DataBaseContext;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.Ong;

namespace Infraestrutura.Repository.WriteRepository;

public class OngWriteRepository : BaseWriteRepository<Ong>, IOngWriteRepository
{
    public OngWriteRepository(Context context) : base(context)
    {
    }
}