using LabFashion.Controllers;
using LabFashion.Models;
using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;

namespace LabFashion.Services.Interfaces
{
    public interface IModelosService
    {
        Task<bool?> CreateAsync(PostModelo modelo);

    }
}
