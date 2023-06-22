using LabFashion.Controllers;
using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;

namespace LabFashion.Services.Interfaces
{
    public interface IColecoesService
    {
        Task<bool?> CreateAsync(PostColecao colecao);
        Task<bool> UpdateAsync(PutColecao colecao);
        Task<bool?> UpdateEstadoSistemaAsync(int id, EstadoSistema status);
    }
}
