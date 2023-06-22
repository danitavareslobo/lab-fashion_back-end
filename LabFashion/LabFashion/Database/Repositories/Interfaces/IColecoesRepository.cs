using LabFashion.Models.Enums;
using LabFashion.Models;
namespace LabFashion.Database.Repositories.Interfaces
{
    public interface IColecoesRepository
    {
        Task<bool> CheckNomeColecaoAsync(object nomeColecao);
        Task<bool?> CreateAsync(Colecao colecao);
        Task<Colecao> GetByIdAsync(int id);
        Task<bool?> UpdateAsync(Colecao colecao);
        Task<bool?> UpdateEstadoSistemaAsync(int id, EstadoSistema status);
    }
}
