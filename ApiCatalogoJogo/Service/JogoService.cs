using ApiCatalogoJogo.Entities;
using ApiCatalogoJogo.Exceptions;
using ApiCatalogoJogo.InputModel;
using ApiCatalogoJogo.Repositories;
using ApiCatalogoJogo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogo.Service
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository) => _jogoRepository = jogoRepository;

        public async Task Atualizar(Guid id, JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);
            if(entidadeJogo == null) throw new JogoNaoCadastradoExcepction();

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Preco = jogo.Preco;
            entidadeJogo.Produtora = jogo.Produtora;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if(entidadeJogo == null) throw new JogoNaoCadastradoExcepction();

            entidadeJogo.Preco = preco;
            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            var entitadeJogos = await _jogoRepository.Obter(jogo.Nome,jogo.Produtora);

            if (entitadeJogos.Count >0) throw new JogoJaCadastradoException();

            var jogoInsert = new Jogo { Id = Guid.NewGuid(), Nome = jogo.Nome, Produtora = jogo.Produtora, Preco = jogo.Preco };

            await _jogoRepository.Inserir(jogoInsert);
            return new JogoViewModel { Id = jogoInsert.Id, Nome = jogoInsert.Nome, Produtora = jogoInsert.Produtora, Preco = jogoInsert.Preco };
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);
            return jogos.Select(jogos => new JogoViewModel
            {
                Id = jogos.Id,
                Nome = jogos.Nome,
                Produtora = jogos.Produtora,
                Preco = jogos.Preco
            }).ToList();
        }

        public async Task<JogoViewModel> Obter(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null) return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Produtora = jogo.Produtora
            };
        }

        public async Task Remover(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);
            if (jogo == null) throw new JogoNaoCadastradoExcepction();

            await _jogoRepository.Remover(id);
        }
        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }
    }
}
