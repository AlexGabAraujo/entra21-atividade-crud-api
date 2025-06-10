using APIHealthGo.Contracts.Service;
using APIHealthGo.Response;
using Microsoft.AspNetCore.Mvc;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Entity;
using MyFirstCRUD.Repository;
using System.Security.Cryptography.X509Certificates;

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
                message = "Gerente inserido com sucesso!!"
            };
        }
        public async  Task<MessageResponse> Update(GerenciaEntity gerencia)
        {
            GerenciaRepository _repository = new GerenciaRepository();
            await _repository.UpdateGerencia(gerencia);
            return new MessageResponse
            {
                message = "Gerente atualizado com sucesso!!"
            };
        }
        public async Task<MessageResponse> Delete(int id)
        {
            GerenciaRepository _repository = new GerenciaRepository();
            await _repository.DeleteGerencia(id);
            return new MessageResponse
            {
                message = "Gerente Removido com sucesso!!"
            };
        }
    }
}
