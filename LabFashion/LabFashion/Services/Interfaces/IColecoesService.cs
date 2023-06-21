using LabFashion.Controllers;
using LabFashion.Models.ViewModels;

namespace LabFashion.Services.Interfaces
{
    public interface IColecoesService
    {
        Task<bool?> CreateAsync(PostColecao colecao);
    }
}
