using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        /// <summary>
        /// Persistirá en un archivo txt un string dado, en caso de ocurrir un error lanzará excepcion
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true, en caso de haber escrito el txt correctamente</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool resultado = false;
            StreamWriter sw = new StreamWriter(archivo, false);
            try
            {
                sw.WriteLine(datos);
                resultado = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sw.Close();
            }
            return resultado;
        }

        /// <summary>
        /// Leerá un archivo txt y lo almacenara en la referencia datos, en caso de ocurrir un error lanzará una excepcion
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true, en caso de haber leido el archivo correctamente</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool resultado = false;
            StreamReader sr = new StreamReader(archivo);
            try
            {
                datos = sr.ReadToEnd();
                resultado = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                sr.Close();
            }
            return resultado;
        }
    }
}
