using LabFashion.Models.Enums;
using LabFashion.Models;
using Microsoft.EntityFrameworkCore;
using LabFashion.Database.Repositories.Interfaces;

namespace LabFashion.Database.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly LabFashionContext _context;

        public UsuariosRepository(LabFashionContext context)
        {
            _context = context;
        }

        public async Task<bool?> CreateAsync(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool?> UpdateAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool?> UpdateStatusAsync(int id, Status status)
        {
            try
            {
                var usuario = await GetByIdAsync(id);

                if (usuario == null)
                    return null;

                usuario.Status = status;
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Usuario>> GetAllAsync(Status? status)
        {
            try
            {
                if (status == null)
                    return await _context.Usuarios.ToListAsync();

                return await _context.Usuarios.Where(u => u.Status == status).ToListAsync();
            }
            catch (Exception e)
            {
                return new List<Usuario>();
            }
        }

        public async Task<bool> CheckCpfCnpjAsync(string cpfCnpj)
        {
            try
            {
                return await _context.Usuarios.AnyAsync(u => u.CpfCnpj == cpfCnpj);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Usuarios.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario == null)
                    return null;

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
