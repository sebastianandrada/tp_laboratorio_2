using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "DNI Invalido";

        public DniInvalidoException()
        {
        }

        public DniInvalidoException(Exception exception) : base(mensajeBase, exception)
        {
        }

        public DniInvalidoException(string message) : base(message)
        {
        }

        public DniInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
    }
}
