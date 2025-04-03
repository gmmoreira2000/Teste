using Data.Context;
using Data.Repository.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class Repository : IContatoRepository
    {
        private readonly ContatoContextDb Db;
        private readonly DbSet<Contato> ContatoSet;

        public Repository(ContatoContextDb db)
        {
            Db = db;
            ContatoSet = db.Set<Contato>();
        }
        public async Task Adicionar(Contato contato)
        {
            ContatoSet.Add(contato);
            await SaveChanges();
        }

        public async Task Atualizar(Contato contato)
        {
            ContatoSet.Update(contato);
            await SaveChanges();
        }

        public async Task<Contato> ObterPorId(int id)
        {
            return await ContatoSet.FindAsync(id) ;
        }

        public async Task<List<Contato>> ObterTodos()
        {
            return await ContatoSet.ToListAsync();
        }

        public async Task Remover(int id)
        {
            var contato = await ContatoSet.FindAsync(id);
            ContatoSet.Remove(contato);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}