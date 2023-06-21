using LabFashion.Database.Repositories.Interfaces;
using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;
using LabFashion.Models;
using LabFashion.Services.Interfaces;
using LabFashion.Controllers;

namespace LabFashion.Services
{
    public class ColecoesService : IColecoesService
    {
        private readonly IColecoesRepository _colecoesRepository;

        public ColecoesService(IColecoesRepository colecoesRepository)
        {
            _colecoesRepository = colecoesRepository;
        }


        public async Task<bool?> CreateAsync(PostColecao postColecao)
        {
            try
            {
                if (await _colecoesRepository.CheckNomeColecaoAsync(postColecao.NomeColecao))
                    return null;

                var colecao = new Colecao
                {
                    NomeColecao = postColecao.NomeColecao,
                    IdResponsavel = postColecao.IdResponsavel,
                    Marca = postColecao.Marca,
                    Orcamento = postColecao.Orcamento,
                    AnoLancamento = postColecao.AnoLancamento,
                    Estacao = postColecao.Estacao,
                    EstadoSistema = postColecao.EstadoSistema                   
                };

                return await _colecoesRepository.CreateAsync(colecao);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}