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

namespace Teste_de_Unidade
{
    public class AdicionarContatoTeste
    {
        private IContatoRepository _repositorio;
        private IMapper _mapper;

        //[Theory]
        //[InlineData("Nome 1", "2005-01-03", 'F', true)]
        //[InlineData("Nome 2", "2001-01-03", 'M', true)]
        //public void AdicionarContatoValido(string nome, DateTime dataNascimento, char sexo, bool ativo)
        //{
        //    var option = new DbContextOptionsBuilder<ContatoContextDb>().UseInMemoryDatabase("ContatoContextDb").Options;
        //    var context = new ContatoContextDb(option);
        //    var controladorContato = new ContatoController(_repositorio, _mapper);

        //    var contato = new ContatoViewModel();
        //    contato.Nome = nome;
        //    contato.DataNascimento = dataNascimento;
        //    contato.Sexo = sexo;
        //    contato.Ativo = ativo;

        //    IActionResult resultado = null;

        //    //resultado = controladorContato.Adicionar(contato);

        //    Assert.IsType<OkObjectResult>(resultado);
        //}

    }
}
