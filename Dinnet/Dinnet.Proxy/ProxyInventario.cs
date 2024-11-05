using Dinnet.DataAccess.Business;
using Dinnet.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinnet.Proxy
{
    public class ProxyInventario
    {
        private InventarioRepository<InventarioBe> proxy = null;
        public ProxyInventario()
        {
            proxy = new InventarioRepository<InventarioBe>(Settings.conexion);
        }
        public Int32 InsertarInventario(InventarioBe inventario)
        {
            try
            {
                return proxy.InsertarInventario(inventario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<InventarioBe> Filtrarinventario(string filtro)
        {
            try
            {
                return proxy.Filtrarinventario(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
