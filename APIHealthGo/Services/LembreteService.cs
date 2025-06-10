using APIHealthGo.Contracts.Service;
using APIHealthGo.Response;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Entity;
using MyFirstCRUD.Repository;

namespace APIHealthGo.Services
{
    public class LembreteService : ILembreteService
    {
        public async Task<LembreteGetAllResponse> GetAllLembrete()
        {
            LembreteRepository _repository = new LembreteRepository();
            return new LembreteGetAllResponse
            {
                Data = await _repository.GetAllLembrete()
            };
        }
        public async Task<LembreteEntity> GetLembreteById(int id)
        {
            LembreteRepository _repository = new LembreteRepository();
            return await _repository.GetLembreteById(id);
        }
        public async Task<MessageResponse> Post(LembreteInsertDTO lembrete)
        {
            LembreteRepository _repository = new LembreteRepository();
            await _repository.InsertLembrete(lembrete);
            return new MessageResponse
            {
                message = "Gerente inserido com sucesso!!"
            };
        }
        public async Task<MessageResponse> Update(LembreteEntity lembrete)
        {
            LembreteRepository _repository = new LembreteRepository();
            await _repository.UpdateLembrete(lembrete);
            return new MessageResponse
            {
                message = "Gerente atualizado com sucesso!!"
            };
        }
        public async Task<MessageResponse> Delete(int id)
        {
            LembreteRepository _repository = new LembreteRepository();
            await _repository.DeleteLembrete(id);
            return new MessageResponse
            {
                message = "Gerente Removido com sucesso!!"
            };
        }
    }
}

