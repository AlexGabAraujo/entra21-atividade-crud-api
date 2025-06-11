using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Response.Especialidade;
using MinhaPrimeiraApi.Response;

namespace MinhaPrimeiraApi.Services
{
    public class VooService : IVooService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            VooRepository _repository = new VooRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Voo excluida com sucesso!"
            };
        }

        public async Task<VooGetAllResponse> GetAll()
        {
            VooRepository _repository = new VooRepository();
            return new VooGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<VooEntity> GetById(int id)
        {
            VooRepository _repository = new VooRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(VooInsertDTO voo)
        {
            VooRepository _repository = new VooRepository();
            await _repository.Insert(voo);
            return new MessageResponse
            {
                Message = "Voo inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(VooEntity voo)
        {
            VooRepository _repository = new VooRepository();
            await _repository.Update(voo);
            return new MessageResponse
            {
                Message = "Voo alterada com sucesso!"
            };
        }
    }
}
