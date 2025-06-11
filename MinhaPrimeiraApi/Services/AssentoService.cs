using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Response.Especialidade;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Contracts.Repository;

namespace MinhaPrimeiraApi.Services
{
    public class AssentoService : IAssentoService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            AssentoRepository _repository = new AssentoRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Assento excluida com sucesso!"
            };
        }

        public async Task<AssentoGetAllResponse> GetAll()
        {
            AssentoRepository _repository = new AssentoRepository();
            return new AssentoGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<AssentoEntity> GetById(int id)
        {
            AssentoRepository _repository = new AssentoRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(AssentoInsertDTO assento)
        {
            AssentoRepository _repository = new AssentoRepository();
            await _repository.Insert(assento);
            return new MessageResponse
            {
                Message = "Assento inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(AssentoEntity assento)
        {
            AssentoRepository _repository = new AssentoRepository();
            await _repository.Update(assento);
            return new MessageResponse
            {
                Message = "Assento alterada com sucesso!"
            };
        }
    }
}
