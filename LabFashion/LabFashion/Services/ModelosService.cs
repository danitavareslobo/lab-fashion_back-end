using LabFashion.Database.Repositories.Interfaces;
using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;
using LabFashion.Models;
using LabFashion.Services.Interfaces;
using LabFashion.Controllers;
using LabFashion.Database.Repositories;
using System.Text.RegularExpressions;

namespace LabFashion.Services
{
    public class ModelosService : IModelosService
    {
        private readonly IModelosRepository _modelosRepository;

        public ModelosService(IModelosRepository modeloRepository)
        {
            _modelosRepository = modeloRepository;
        }


        public async Task<bool?> CreateAsync(PostModelo postModelo)
        {
            try
            {
                if (await _modelosRepository.CheckNomeModeloAsync(postModelo.NomeModelo))
                    return null;

                var modelo = new Modelo
                {
                    NomeModelo = postModelo.NomeModelo,
                    IdColecaoRelacionada = postModelo.IdColecaoRelacionada,
                    Tipo = postModelo.Tipo,
                    Layout = postModelo.Layout
                };

                return await _modelosRepository.CreateAsync(modelo);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool?> UpdateAsync(PutModelo putModelo)
        {
            try
            {
                var modelo = await _modelosRepository.GetByIdAsync(putModelo.Id);

                if (modelo == null)
                    return null;

                if (!string.IsNullOrEmpty(putModelo.NomeModelo))
                    modelo.NomeModelo = putModelo.NomeModelo;

                if (putModelo.IdColecaoRelacionada > 0)
                    modelo.IdColecaoRelacionada = putModelo.IdColecaoRelacionada;

                if (!Enum.IsDefined(typeof(Tipo), putModelo.Tipo))
                    modelo.Tipo = putModelo.Tipo;

                if (!Enum.IsDefined(typeof(Layout), putModelo.Layout))
                    modelo.Layout = putModelo.Layout;

                return await _modelosRepository.UpdateAsync(modelo);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Modelo>> GetAllAsync(Layout? layout)
        {
            return await _modelosRepository.GetAllAsync(layout);
        }
    }
}