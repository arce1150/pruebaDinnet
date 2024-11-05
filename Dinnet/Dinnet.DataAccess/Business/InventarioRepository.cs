using Dinnet.DataAccess.Interfaces;
using Dinnet.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Dinnet.DataAccess.Business
{
    public class InventarioRepository<T> : IInventarioRepository<T> where T : class
    {
        private readonly SqlConnection _conexion;
        public InventarioRepository(string cadenaConexion)
        {
            _conexion = new SqlConnection(cadenaConexion);
        }
        public int InsertarInventario(InventarioBe inventario)
        {
            int filasAfectadas = 0;
            try
            {
                _conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Insert_NVENTARIO", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@COD_CIA", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.CodigoCompania ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@COMPANIA_VENTA_3", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.CompaniaVenta ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ALMACEN_VENTA", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.AlmacenVenta ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TIPO_MOVIMIENTO", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.TipoMovimiento ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@TIPO_DOCUMENTO", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.TipoDocumento ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@NRO_DOCUMENTO", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.Nrodocumento ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@COD_ITEM_2", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.CodigoItem ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PROVEEDOR", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.Proveedor ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ALMACEN_DESTINO", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.AlmacenDestino ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CANTIDAD", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.Cantidad ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@COSTO_UNITARIO", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.CostoUnitario ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@MOTIVO", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.Motivo ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FECHA_TRANSACCION", SqlDbType = SqlDbType.VarChar, Value = (object)inventario.FechaTransaccion ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                cmd.ExecuteNonQuery();
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                    _conexion.Close();
            }
        }
        public List<InventarioBe> Filtrarinventario(string filtro)
        {
            List<InventarioBe> inventarios = null;
            InventarioBe inventario = null;
            
            try
            {
                _conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_filtro_NVENTARIO", _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@filtro", SqlDbType = SqlDbType.VarChar, Value = (object)filtro ?? DBNull.Value, Direction = ParameterDirection.Input, IsNullable = false });
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr != null)
                {
                    int pCOD_CIA = dr.GetOrdinal("COD_CIA");
                    int pCOMPANIA = dr.GetOrdinal("COMPANIA_VENTA_3");
                    int pAlmacen = dr.GetOrdinal("ALMACEN_VENTA");
                    int pTipoMov = dr.GetOrdinal("TIPO_MOVIMIENTO");
                    int pTIPO_DOCUMENTO = dr.GetOrdinal("TIPO_DOCUMENTO");
                    int pNRODoc = dr.GetOrdinal("NRO_DOCUMENTO");
                    int pCOD_ITEM_2 = dr.GetOrdinal("COD_ITEM_2");
                    int pPROVEEDOR = dr.GetOrdinal("PROVEEDOR");
                    int pALMACEN_DESTINO = dr.GetOrdinal("ALMACEN_DESTINO");
                    int pCANTIDAD = dr.GetOrdinal("CANTIDAD");
                    int pCostoUnitario = dr.GetOrdinal("COSTO_UNITARIO");
                    int pMOTIVO = dr.GetOrdinal("MOTIVO");
                    int pFechaTransac = dr.GetOrdinal("FECHA_TRANSACCION");
                    inventarios = new List<InventarioBe>();
                    while (dr.Read())
                    {
                        inventario = new InventarioBe();
                        inventario.CodigoCompania = dr.GetValue(pCOD_CIA) == DBNull.Value ? default(string) : dr.GetString(pCOD_CIA);
                        inventario.CompaniaVenta = dr.GetValue(pCOMPANIA) == DBNull.Value ? default(string) : dr.GetString(pCOMPANIA);
                        inventario.AlmacenVenta = dr.GetValue(pAlmacen) == DBNull.Value ? default(string) : dr.GetString(pAlmacen);
                        inventario.TipoMovimiento = dr.GetValue(pTipoMov) == DBNull.Value ? default(string) : dr.GetString(pTipoMov);
                        inventario.Nrodocumento = dr.GetValue(pNRODoc) == DBNull.Value ? default(string) : dr.GetString(pNRODoc);
                        inventario.Proveedor = dr.GetValue(pPROVEEDOR) == DBNull.Value ? default(string) : dr.GetString(pPROVEEDOR);
                        inventario.CostoUnitario = dr.GetValue(pCostoUnitario) == DBNull.Value ? default(string) : dr.GetString(pCostoUnitario);
                        inventario.FechaTransaccion = dr.GetValue(pFechaTransac) == DBNull.Value ? default(string) : dr.GetString(pFechaTransac);
                        inventarios.Add(inventario);
                    }
                    dr.Close();
                }
                return inventarios;
            }
            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                    _conexion.Close();
            }
        }


    }
}
