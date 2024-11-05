using Dinnet.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Dinnet.DataAccess.Interfaces
{
    public interface   IInventarioRepository<T> where T : class
    {
        Int32 InsertarInventario(InventarioBe inventario);
        List<InventarioBe> Filtrarinventario(string filtro);
    }
}
