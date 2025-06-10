using APIHealthGo.Contracts.Service;
using APIHealthGo.Response;
using atividade_bd_csharp.Entity;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Repository;

namespace APIHealthGo.Services
{
    public class PessoaService : IPessoaService
    {

        public async Task<PessoaGetAllResponse> GetAllPessoa()
        {
            PessoaRepository _repository = new PessoaRepository();
            return new PessoaGetAllResponse
            {
                Data = await _repository.GetAllPessoa()
            };
        }


        public async Task<PessoaEntity> GetPessoaById(int id)
        {
            PessoaRepository _repository = new PessoaRepository();
            return await _repository.GetPessoaById(id);
        }

        public async Task<MessageResponse> Post(PessoaInsertDTO pessoa)
        {
            PessoaRepository _repository = new PessoaRepository();
            await _repository.InsertPessoa(pessoa);
            return new MessageResponse
            {
                message = "Pessoa inserida com sucesso!"
            };
        }
        public async Task<MessageResponse> Update(PessoaEntity pessoa)
        {
            PessoaRepository _repository = new PessoaRepository();
            await _repository.DeletePessoa(pessoa);
            return new MessageResponse
            {
                message = "Pessoa inserida com sucesso!"
            };
        }
        public async Task<MessageResponse> Delete(int id)
        {
            PessoaRepository _repository = new PessoaRepository();
            await _repository.DeletePessoa(id);
            return new MessageResponse
            {
                message = "Pessoa Excluída com sucesso"
            };
        }
    }
}


