using LabFashion.Models.Enums;
using LabFashion.Models;
namespace LabFashion.Database.Repositories.Interfaces
{
    public interface IColecoesRepository
    {
        Task<bool> CheckNomeColecaoAsync(object nomeColecao);
        Task<bool?> CreateAsync(Colecao colecao);
        Task<bool?> UpdateAsync(Colecao colecao);
        Task<bool?> UpdateEstadoSistemaAsync(int id, EstadoSistema status);
        Task<List<Colecao>> GetAllAsync(EstadoSistema? status);
        Task<Colecao?> GetByIdAsync(int id);
    }
}
