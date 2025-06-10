using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Response.Especialidade;
using Mysqlx;

namespace MinhaPrimeiraApi.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            EspecialidadeRepository _repository = new EspecialidadeRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Especialidade excluida com sucesso!"
            };
       }

        public async Task <EspecialidadeGetAllResponse> GetAll()
        {
            EspecialidadeRepository _repository = new EspecialidadeRepository();
            return new EspecialidadeGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<EspecialidadeEntity> GetById(int id)
        {
            EspecialidadeRepository _repository = new EspecialidadeRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(EspecialidadeInsertDTO especialidade)
        {
            EspecialidadeRepository _repository = new EspecialidadeRepository();
            await _repository.Insert(especialidade);
            return new MessageResponse
            {
                Message = "Especialidade inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(EspecialidadeEntity especialidade)
        {
            EspecialidadeRepository _repository = new EspecialidadeRepository();
            await _repository.Update(especialidade);
            return new MessageResponse
            {
                Message = "Especialidade alterada com sucesso!"
            };
        }
    }
}
