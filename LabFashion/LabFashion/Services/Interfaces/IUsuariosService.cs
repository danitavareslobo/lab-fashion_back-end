using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;
using LabFashion.Models;

namespace LabFashion.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<bool?> CreateAsync(PostUsuario usuario);
        
    }
}
