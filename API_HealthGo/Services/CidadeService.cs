﻿using MinhaPrimeiraApi.Response;
using API_HealthGo.Response;
using API_HealthGo.Response.Cidade;
using API_HealthGo.DTO;
using API_HealthGo.Contracts.Repository;
using API_HealthGo.Contracts.Service;
using API_HealthGo.Entity;

namespace API_HealthGo.Services
{
    public class CidadeService : ICidadeService
    {

        private ICidadeRepository _repository;

        public CidadeService(ICidadeRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Cidade excluida com sucesso!"
            };
        }

        public async Task<CidadeGetAllResponse> GetAll()
        {
            return new CidadeGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<CidadeEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(CidadeInsertDTO cidade)
        {
            await _repository.Insert(cidade);
            return new MessageResponse
            {
                Message = "Cidade inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(CidadeEntity cidade)
        {
            await _repository.Update(cidade);
            return new MessageResponse
            {
                Message = "Cidade alterada com sucesso"
            };
        }
    }
}