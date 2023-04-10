using Microsoft.EntityFrameworkCore;
using PixAPI.Model;
using PixAPI.Repository.Interface;
using TenisAPI.Context;
using TenisAPI.Model;

namespace PixAPI.Repository
{
    public class PixRepository : IPixRepository
    {
        private readonly AppContextData _db;
        public PixRepository(AppContextData db)
        {
            _db = db;
        }

        public async Task<Pix> CreateChavePix(Pix pagamentoPix)
        {
            await _db.Pix.AddAsync(pagamentoPix);

            _db.SaveChanges();

            return pagamentoPix;
        }

        public async Task<List<TransacaoPix>> ObterChavePorKey(string key)
        {
            return await _db.Transacao.Where(x => x.ChaveEmissor == key).ToListAsync();
        }

        public Task<List<Pix>> ObterTodasKeys()
        {
            return _db.Pix.ToListAsync();
        }

        public async Task<TransacaoPix> RealizarTransacao(TransacaoPix transacaoPix)
        {
            var obj = await _db.Pix.FirstOrDefaultAsync(x => x.ChavePix == transacaoPix.ChaveEmissor);


            if (obj is null)
            {
                throw new Exception("Não foi encontrada esta chave na base de dados");
            }

            await _db.Transacao.AddAsync(transacaoPix);

            _db.SaveChanges();

            return transacaoPix;
        }
    }
}
