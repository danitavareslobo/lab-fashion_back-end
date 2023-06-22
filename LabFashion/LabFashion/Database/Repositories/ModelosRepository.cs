﻿using LabFashion.Models.Enums;
using LabFashion.Models;
using Microsoft.EntityFrameworkCore;
using LabFashion.Database.Repositories.Interfaces;

namespace LabFashion.Database.Repositories
{
    public class ModelosRepository : IModelosRepository
    {
        private readonly LabFashionContext _context;

        public ModelosRepository(LabFashionContext context)
        {
            _context = context;
        }

        public Task<bool> CheckNomeModeloAsync(string nomeModelo)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> CreateAsync(Modelo modelo)
        {
            try
            {
                await _context.Modelos.AddAsync(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool?> UpdateAsync(Modelo modelo)
        {
            try
            {
                _context.Modelos.Update(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Modelo>> GetAllAsync(Layout? layout)
        {
            try
            {
                if (layout == null)
                    return await _context.Modelos.ToListAsync();

                return await _context.Modelos.Where(u => u.Layout == layout).ToListAsync();
            }
            catch (Exception e)
            {
                return new List<Modelo>();
            }
        }

        public async Task<Modelo?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Modelos.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
