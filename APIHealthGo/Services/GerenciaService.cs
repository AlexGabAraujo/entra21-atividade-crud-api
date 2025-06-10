using APIHealthGo.Contracts.Service;
using APIHealthGo.Response;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Entity;
using MyFirstCRUD.Repository;

namespace APIHealthGo.Services
{
    public class GerenciaService : IGerenciaService
    {
        public async Task<GerenciaGetAllResponse> GetAllGerencia()
        {
            GerenciaRepository _repository = new GerenciaRepository();
            return new GerenciaGetAllResponse
            {
                Data = await _repository.GetAllGerencia()
            };
        }

        public async Task<GerenciaEntity> GetGerenciaById(int id)
        {
            GerenciaRepository _repository = new GerenciaRepository();
            return await _repository.GetGerenciaById(id);
        }

        public async Task<MessageResponse> Post(GerenciaInsertDTO gerencia)
        {
            GerenciaRepository _repository = new GerenciaRepository();
            await _repository.InsertGerencia(gerencia);
            return new MessageResponse
            {
                message = "Gerente adicionado com suceso"
            };
        }
    }
}
