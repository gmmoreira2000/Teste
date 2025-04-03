using System;
using Data;
using Business;
using Domain;
using Api;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Api.Controllers;
using Data.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Business.Services;
using Business.ViewModels;

namespace Teste_de_Unidade
{
    public class AdicionarContatoTeste
    {
        private Mock<IContatoRepository> _repositorio;
        private ContatoService _contatoService;
        private IMapper _mapper;

        public AdicionarContatoTeste() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contato, Business.ViewModels.ContatoViewModel>().ReverseMap();
            });
            _mapper = config.CreateMapper();
            _repositorio = new Mock<IContatoRepository>();
            _contatoService= new ContatoService(_repositorio.Object, _mapper);
        }

        [Theory]
        [InlineData("Nome 1", "2005-01-03", 'F', true)]
        [InlineData("Nome 2", "2001-07-04", 'M', true)]
        [InlineData("Nome 3", "2000-02-05", 'T', true)]
        public async Task AdicionarContatoValido(string nome, DateTime dataNascimento, char sexo, bool ativo)
        { 
            var contato = new ContatoViewModel();
            contato.Nome = nome;
            contato.DataNascimento = dataNascimento;
            contato.Sexo = sexo;
            contato.Ativo = ativo;

            _repositorio.Setup(r => r.Adicionar(It.IsAny<Contato>()));


            await _contatoService.Adicionar(contato);

            _repositorio.Verify(r => r.Adicionar(It.IsAny<Contato>()), Times.Once); 
        }

        [Theory]
        [InlineData("Nome 1", "2015-01-03", 'F', true)]
        [InlineData("Nome 2", "2011-07-04", 'M', true)]
        [InlineData("Nome 3", "2009-02-05", 'T', true)]
        public async Task AdicionarContatoInValidoIdade(string nome, DateTime dataNascimento, char sexo, bool ativo)
        {
            var contato = new ContatoViewModel();
            contato.Nome = nome;
            contato.DataNascimento = dataNascimento;
            contato.Sexo = sexo;
            contato.Ativo = ativo;
            _repositorio.Setup(r => r.Adicionar(It.IsAny<Contato>()));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _contatoService.Adicionar(contato));
            Assert.Equal("A idade do contato deve ser maior de 18", exception.Message);
        }

        [Theory]
        [InlineData("Nome 1", "2025-04-27", 'F', true)]
        [InlineData("Nome 2", "2025-07-04", 'M', true)]
        [InlineData("Nome 3", "2026-04-03", 'T', true)]
        public async Task AdicionarContatoInValidoData(string nome, DateTime dataNascimento, char sexo, bool ativo)
        {
            var contato = new ContatoViewModel();
            contato.Nome = nome;
            contato.DataNascimento = dataNascimento;
            contato.Sexo = sexo;
            contato.Ativo = ativo;
            _repositorio.Setup(r => r.Adicionar(It.IsAny<Contato>()));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _contatoService.Adicionar(contato));
            Assert.Equal("A data de nascimento não pode ser maior do que a data de hoje", exception.Message);
        }

    }
}
