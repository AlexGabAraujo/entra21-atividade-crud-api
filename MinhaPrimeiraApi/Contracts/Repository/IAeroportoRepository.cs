using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;

namespace MinhaPrimeiraApi.Contracts.Repository
{
    public interface IAeroportoRepository
    {
        Task<IEnumerable<AeroportoEntity>> GetAll();

        Task<AeroportoEntity> GetById(int id);

        Task Insert(AeroportoInsertDTO aeroporto);

        Task Delete(int id);

        Task Update(AeroportoEntity aeroporto);
    }
}