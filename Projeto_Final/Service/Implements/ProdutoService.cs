using Microsoft.EntityFrameworkCore;
using Projeto_Final.Data;
using Projeto_Final.Model;

namespace Projeto_Final.Service.Implements
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService (AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Produto = await _context.Produtos
                     .FirstAsync(i => i.Id == id);

                return Produto;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            var Produto = await _context.Produtos
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();

            return Produto;
        }

        public async Task<IEnumerable<Produto>> GetByFabricante(string fabricante)
        {
            var Produto = await _context.Produtos
                .Where(p => p.Fabricante.Contains(fabricante))
                .ToListAsync();

            return Produto;
        }

        public Task<Produto?> Create(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto?> Update(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
