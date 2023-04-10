using Microsoft.AspNetCore.Mvc;
using PixAPI.Model;
using TenisAPI.Model;

namespace PixAPI.Repository.Interface
{
    public interface IPixRepository
    {
        Task<Pix> CreateChavePix(Pix pagamentoPix);
        Task<TransacaoPix> RealizarTransacao(TransacaoPix transacaoPix);
        Task<List<TransacaoPix>> ObterChavePorKey(string key);
        Task<List<Pix>> ObterTodasKeys ();

    }
}
