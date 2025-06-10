﻿using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Response;

namespace MinhaPrimeiraApi.Contracts.Services
{
    public interface ICidadeService
    {
        Task<MessageResponse> Delete(int id);
        Task<CidadeGetAllResponse> GetAll();
        Task<CidadeEntity> GetById(int id);
        Task<MessageResponse> Post(CidadeInsertDTO cidade);
        Task<MessageResponse> Update(CidadeEntity cidade);
    }
}