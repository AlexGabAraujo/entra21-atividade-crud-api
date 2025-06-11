using MinhaPrimeiraApi.Contracts.Repository;
using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Response.Especialidade;

namespace MinhaPrimeiraApi.Services
{
    public class AviaoService : IAviaoService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            AviaoRepository _repository = new AviaoRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Aviao excluida com sucesso!"
            };
        }

        public async Task<AviaoGetAllResponse> GetAll()
        {
            AviaoRepository _repository = new AviaoRepository();
            return new AviaoGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<AviaoEntity> GetById(int id)
        {
            AviaoRepository _repository = new AviaoRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(AviaoInsertDTO aviao)
        {
            AviaoRepository _repository = new AviaoRepository();
            await _repository.Insert(aviao);
            return new MessageResponse
            {
                Message = "Aviao inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(AviaoEntity aviao)
        {
            AviaoRepository _repository = new AviaoRepository();
            await _repository.Update(aviao);
            return new MessageResponse
            {
                Message = "Aviao alterada com sucesso!"
            };
        }
    }
}
