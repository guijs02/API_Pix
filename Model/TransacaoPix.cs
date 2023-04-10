using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TenisAPI.Model;

namespace PixAPI.Model
{
    public class TransacaoPix
    {
        public int Id { get; set; }
        public string ChaveReceptor { get; set; }
        [Precision(5,2)]
        public decimal Valor { get; set; } = 0;
        public string ChaveEmissor { get; set; }
    }
    
}
