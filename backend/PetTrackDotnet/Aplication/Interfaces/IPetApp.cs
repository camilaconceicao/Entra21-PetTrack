using Aplication.Models.Request.Base;
using Aplication.Models.Request.Pet;
using Aplication.Models.Response.Base;
using Aplication.Models.Response.Pet;
using Aplication.Utils.Obj;
using Infra.Data.Entity;

namespace Aplication.Interfaces;

public interface IPetApp
{
    public List<Pet> GetAll();
    public PetResponse GetById(int id);
    public ValidationResult Cadastrar(PetRequest request);
    public ValidationResult Editar(PetRequest request);
    public void DeleteById(int id);
    public BaseGridResponse ConsultarGridPet(BaseGridRequest request);
    public List<PetConsultaResponse> ConsultarPetsAdocao();
    public List<PetConsultaResponse> ConsultarPetsPerdidos();
}