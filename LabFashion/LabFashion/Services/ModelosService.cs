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
    }
}