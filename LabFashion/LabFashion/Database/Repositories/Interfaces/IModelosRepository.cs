using LabFashion.Models.Enums;
using LabFashion.Models;
namespace LabFashion.Database.Repositories.Interfaces
{
    public interface IModelosRepository
    {
        Task<bool> CheckNomeModeloAsync(string nomeModelo);
        Task<bool?> CreateAsync(Modelo modelo);
    }
}
