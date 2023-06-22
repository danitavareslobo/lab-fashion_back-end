using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;
using LabFashion.Models;

namespace LabFashion.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<bool?> CreateAsync(PostUsuario usuario);
        Task<List<Usuario?>> GetAllAsync(Status? status);
        Task<bool> UpdateAsync(PutUsuario usuario);
        Task<bool> UpdateStatusAsync(int id, Status status);
        Task<Usuario?> GetByIdAsync(int id);
    }
}
