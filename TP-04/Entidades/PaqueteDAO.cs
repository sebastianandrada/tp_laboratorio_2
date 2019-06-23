using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            string connectionStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security = True";
            try
            {
                PaqueteDAO.conexion = new SqlConnection(connectionStr);
                PaqueteDAO.comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region "Metodos"
        /// <summary>
        /// Inserta un paquete en una base de datos
        /// </summary>
        /// <param name="p">Paquete a persistir</param>
        /// <returns>True en caso que se guarde correctamente</returns>
        public static bool Insertar(Paquete p)
        {
            bool resultado = false;
            string consulta = String.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ('{0}','{1}', '{2}')", p.DireccionEntrega, p.TrackingID, "Sebastian Andrada");
            try
            {
                comando.CommandText = consulta;
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = true;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }
        #endregion
    }
}
