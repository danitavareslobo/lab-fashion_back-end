﻿using LabFashion.Database.Repositories.Interfaces;
using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;
using LabFashion.Models;
using LabFashion.Services.Interfaces;
using LabFashion.Controllers;
using LabFashion.Database.Repositories;
using System.Text.RegularExpressions;
using AutoMapper;

namespace LabFashion.Services
{
    public class ColecoesService : IColecoesService
    {
        private readonly IMapper _mapper;
        private readonly IColecoesRepository _colecoesRepository;

        public ColecoesService(IMapper mapper, IColecoesRepository colecoesRepository)
        {
            _mapper = mapper;
            _colecoesRepository = colecoesRepository;
        }

        public async Task<bool?> CreateAsync(PostColecao postColecao)
        {
            try
            {
                if (await _colecoesRepository.CheckNomeColecaoAsync(postColecao.NomeColecao))
                    return null;

                var colecao = _mapper.Map<Colecao>(postColecao);
                

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
                var colecao = await _colecoesRepository.GetByIdAsync(id);

                if (colecao == null)
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

        public async Task<List<Colecao?>> GetAllAsync(EstadoSistema? status)
        {
            return await _colecoesRepository.GetAllAsync(status);
        }

        public async Task<Colecao?> GetByIdAsync(int id)
        {
            return await _colecoesRepository.GetByIdAsync(id);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var colecao = await GetByIdAsync(id);

            if (colecao == null)
                return null;

            if (colecao.EstadoSistema != EstadoSistema.Inativa) return false;

            if (colecao.Modelos.Any()) return false;

            return await _colecoesRepository.DeleteAsync(id);
        }
    }
}