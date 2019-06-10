using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializara un dato T en un archivo xml, en caso de ocurrir un error lanzara una excepcion
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>retornará true, si ha podido serializar el dato correctamente</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter w = new XmlTextWriter(archivo, Encoding.UTF8);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            bool resultado = false;
            try
            {
                ser.Serialize(w, datos);
                resultado = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                w.Close();
            }
            return resultado;
        }

        /// <summary>
        /// Intenta convertir un dato T, serializado como un xml en un Objeto de tipo T, en caso de ocurrir un error arrojará una excepcion
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true, si ha podido deserealizar correctamente el archivo</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = new XmlTextReader(archivo);
            XmlSerializer ser;
            bool resultado = false;
            try
            {
                ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                resultado = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                reader.Close();
            }
            return resultado;
        }
    }
}
