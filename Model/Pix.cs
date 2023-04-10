using Microsoft.EntityFrameworkCore;
using TenisAPI.Enum;

namespace TenisAPI.Model
{
    public class Pix
    {
        public int Id { get; set; }
        public EChavePix TipoChavePix { get; set; }
        public string ChavePix { get; set; }


        //public int RetornarIdentificadorPix(int id)
        //{
        //    return id;
        //}
    }
   
}
