using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Contracts.Services;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Contracts.Repository;
using MinhaPrimeiraApi.Response.Aeroporto;

namespace MinhaPrimeiraApi.Services
{
    public class AeroportoService : IAeroportoService
    {
        
        private IAeroportoRepository _repository;

        public AeroportoService(IAeroportoRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Aeroporto excluido com sucesso!"
            };
        }

        public async Task<AeroportoGetAllResponse> GetAll()
        {
            return new AeroportoGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<AeroportoEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(AeroportoInsertDTO aeroporto)
        {
            await _repository.Insert(aeroporto);
            return new MessageResponse
            {
                Message = "Aeroporto inserido com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(AeroportoEntity aeroporto)
        {
            await _repository.Update(aeroporto);
            return new MessageResponse
            {
                Message = "Aeroporto alterado com sucesso"
            };
        }
    }
}