﻿using LabFashion.Database.Repositories.Interfaces;
using LabFashion.Models;
using LabFashion.Models.Enums;

using Microsoft.EntityFrameworkCore;

namespace LabFashion.Database.Repositories
{
    public class ColecoesRepository : IColecoesRepository
    {
        private readonly LabFashionContext _context;

        public ColecoesRepository(LabFashionContext context)
        {
            _context = context;
        }

        public async Task<bool?> CreateAsync(Colecao colecao)
        {
            try
            {
                await _context.Colecoes.AddAsync(colecao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool?> UpdateAsync(Colecao colecao)
        {
            try
            {
                _context.Colecoes.Update(colecao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool?> UpdateEstadoSistemaAsync(int id, EstadoSistema status)
        {
            try
            {
                var colecao = await GetByIdAsync(id);

                if (colecao == null)
                    return null;

                colecao.EstadoSistema = status;
                _context.Colecoes.Update(colecao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Colecao?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Colecoes.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> CheckNomeColecaoAsync(object nomeColecao)
        {
            try
            {
                return await _context.Colecoes.AnyAsync(u => u.NomeColecao == nomeColecao);
            }
            catch (Exception e)
            {
                return false;
            }
        }        }
}

