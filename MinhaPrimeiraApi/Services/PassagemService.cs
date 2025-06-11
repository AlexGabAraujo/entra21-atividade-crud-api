using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Response.Especialidade;
using MinhaPrimeiraApi.Response;

namespace MinhaPrimeiraApi.Services
{
    public class PassagemService : IPassagemService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            PassagemRepository _repository = new PassagemRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Passagem excluida com sucesso!"
            };
        }

        public async Task<PassagemGetAllResponse> GetAll()
        {
            PassagemRepository _repository = new PassagemRepository();
            return new PassagemGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<PassagemEntity> GetById(int id)
        {
            PassagemRepository _repository = new PassagemRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(PassagemInsertDTO passagem)
        {
            PassagemRepository _repository = new PassagemRepository();
            await _repository.Insert(passagem);
            return new MessageResponse
            {
                Message = "Passagem inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(PassagemEntity passagem)
        {
            PassagemRepository _repository = new PassagemRepository();
            await _repository.Update(passagem);
            return new MessageResponse
            {
                Message = "Passagem alterada com sucesso!"
            };
        }
    }
}
