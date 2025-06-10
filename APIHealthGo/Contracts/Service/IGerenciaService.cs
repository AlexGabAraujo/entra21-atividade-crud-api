using APIHealthGo.Response;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Entity;

namespace APIHealthGo.Contracts.Service
{
    public interface IGerenciaService
    {
        Task<GerenciaGetAllResponse> GetAllGerencia();
        Task<GerenciaEntity> GetGerenciaById(int id);
        Task<GerenciaInsertDTO> Post(GerenciaInsertDTO gerencia);
    }
}
