using LabFashion.Database.Repositories.Interfaces;
using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;
using LabFashion.Models;
using LabFashion.Services.Interfaces;

namespace LabFashion.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }


        public async Task<bool?> CreateAsync(PostUsuario postUsuario)
        {
            try
            {
                if (await _usuariosRepository.CheckCpfCnpjAsync(postUsuario.CpfCnpj))
                    return null;

                var usuario = new Usuario
                {
                    NomeCommpleto = postUsuario.NomeCommpleto,
                    Genero = postUsuario.Genero,
                    CpfCnpj = postUsuario.CpfCnpj,
                    Email = postUsuario.Email,
                    TipoUsuario = postUsuario.TipoUsuario,
                    Status = postUsuario.Status,
                    DataNascimento = postUsuario.DataNascimento,
                    Telefone = postUsuario.Telefone
                };

                return await _usuariosRepository.CreateAsync(usuario);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool?> UpdateAsync(PutUsuario putUsuario)
        {
            try
            {
                var usuario = await _usuariosRepository.GetByIdAsync(putUsuario.Id);

                if (usuario == null)
                    return null;

                if (!string.IsNullOrEmpty(putUsuario.NomeCommpleto))
                    usuario.NomeCommpleto = putUsuario.NomeCommpleto;

                if (!string.IsNullOrEmpty(putUsuario.Genero))
                    usuario.Genero = putUsuario.Genero;

                if (putUsuario.DataNascimento != DateTime.MinValue)
                    usuario.DataNascimento = putUsuario.DataNascimento;

                if (!string.IsNullOrEmpty(putUsuario.Telefone))
                    usuario.Telefone = putUsuario.Telefone;

                if (!Enum.IsDefined(typeof(TipoUsuario), putUsuario.TipoUsuario))
                    usuario.TipoUsuario = putUsuario.TipoUsuario;

                return await _usuariosRepository.UpdateAsync(usuario);
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
                var usuario = await _usuariosRepository.GetByIdAsync(id);

                if (usuario == null)
                    return null;

                if (Enum.IsDefined(typeof(Status), status))
                    return null;

                return await _usuariosRepository.UpdateStatusAsync(id, status);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Usuario>> GetAllAsync(Status? status)
        {
            return await _usuariosRepository.GetAllAsync(status);
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _usuariosRepository.GetByIdAsync(id);
        }

        Task<bool> IUsuariosService.UpdateAsync(PutUsuario usuario)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUsuariosService.UpdateStatusAsync(int id, Status status)
        {
            throw new NotImplementedException();
        }
    }
}