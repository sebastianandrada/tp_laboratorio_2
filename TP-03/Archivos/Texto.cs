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
