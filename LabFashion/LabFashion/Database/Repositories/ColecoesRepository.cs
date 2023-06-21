using LabFashion.Database.Repositories.Interfaces;
using LabFashion.Models;
namespace LabFashion.Database.Repositories
{
    public class ColecoesRepository : IColecoesRepository
    {
        private readonly LabFashionContext _context;

        public ColecoesRepository(LabFashionContext context)
        {
            _context = context;
        }

        public Task<bool> CheckNomeColecaoAsync(object nomeColecao)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> CreateAsync(Colecao colecao)
        {
            try
            {
                await _context.Colecoes.AddAsync(colecao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> UpdateAsync(object colecao)
        {
            throw new NotImplementedException();
        }
    }
}

