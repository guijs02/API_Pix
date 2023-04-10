using Microsoft.AspNetCore.Mvc;
using PixAPI.Model;
using PixAPI.Repository.Interface;
using TenisAPI.Model;

namespace TenisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PixController : Controller
    {
        private readonly IPixRepository _pixRepo;
        public PixController(IPixRepository pixRepo)
        {
            _pixRepo = pixRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChavePix([FromBody] Pix PixObj)
        {
            try
            {

                await _pixRepo.CreateChavePix(PixObj);

                return Ok(PixObj);

            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost("transacao")]
        public async Task<IActionResult> RealizarTransacao([FromBody] TransacaoPix transacaoPix)
        {
            try
            {
                await _pixRepo.RealizarTransacao(transacaoPix);

                return Ok(transacaoPix);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
                throw;
            }
        }


        [HttpGet]
        [Route("{key}")]
        public async Task<IActionResult> ObterChavePorKey([FromRoute] string key)
        {
            try
            {
                var result = await _pixRepo.ObterChavePorKey(key);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> ObterTodasKeys()
        {
            try
            {
                var result = await _pixRepo.ObterTodasKeys();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }

    }
}