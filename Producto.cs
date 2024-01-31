using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregableLautaroIriazabal
{
    internal class Producto
    {
        private int Id { get; set; }
        private string Descripcion { get; set; }
        private decimal Costo { get; set; }
        private decimal PrecioVenta { get; set; }
        private int Stock { get; set; }
        private int IdUsuario { get; set; }
    }

}