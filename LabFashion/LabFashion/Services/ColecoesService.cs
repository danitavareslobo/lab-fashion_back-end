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

        public async Task<bool?> UpdateAsync(PutColecao putColecao)
        {
            try
            {
                var colecao = await _colecoesRepository.GetByIdAsync(putColecao.Id);

                if (colecao == null)
                    return null;

                if (!string.IsNullOrEmpty(putColecao.NomeColecao))
                    colecao.NomeColecao = putColecao.NomeColecao;

                if (putColecao.IdResponsavel > 0)
                    colecao.IdResponsavel = putColecao.IdResponsavel;

                if (!string.IsNullOrEmpty(putColecao.Marca))
                    colecao.Marca = putColecao.Marca;

                if (putColecao.Orcamento > 0)
                    colecao.Orcamento = putColecao.Orcamento;

                if (putColecao.AnoLancamento != DateTime.MinValue)
                    colecao.AnoLancamento = putColecao.AnoLancamento;

                if (!Enum.IsDefined(typeof(Estacao), putColecao.Estacao))
                    colecao.Estacao = putColecao.Estacao;

                if (!Enum.IsDefined(typeof(EstadoSistema), putColecao.EstadoSistema))
                    colecao.EstadoSistema = putColecao.EstadoSistema;

                return await _colecoesRepository.UpdateAsync(colecao);
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
                var usuario = await _colecoesRepository.GetByIdAsync(id);

                if (usuario == null)
                    return null;

                if (Enum.IsDefined(typeof(EstadoSistema), status))
                    return null;

                return await _colecoesRepository.UpdateEstadoSistemaAsync(id, status);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        Task<bool> IColecoesService.UpdateAsync(PutColecao colecao)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Colecao>> GetAllAsync(EstadoSistema? status)
        {
            return await _colecoesRepository.GetAllAsync(status);
        }
    }
}