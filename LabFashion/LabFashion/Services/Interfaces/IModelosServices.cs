﻿using LabFashion.Controllers;
using LabFashion.Models;
using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;

namespace LabFashion.Services.Interfaces
{
    public interface IModelosService
    {
        Task<bool?> CreateAsync(PostModelo modelo);
        Task<bool?> UpdateAsync(PutModelo modelo);
        Task<List<Modelo>> GetAllAsync(Layout? layout);
        Task<Modelo?> GetByIdAsync(int id);
        Task<bool?> DeleteAsync(int id);
    }
}
