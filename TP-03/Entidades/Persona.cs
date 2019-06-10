using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region "Propiedades"
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(nacionalidad, value);
            }
        }


        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion

        #region "Constructores"
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// retorna los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.apellido, this.nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y
        /// 89999999 y Extranjero entre 90000000 y 99999999. Caso Contrario lanzara excepcion NacionalidadInvalidaException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>int</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Extranjero:  
                    if(dato > 99999999 || dato < 89999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                    break;
                case ENacionalidad.Argentino:
                    if(dato > 89999999 || dato < 1)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                    break;
            }
            return dato;
        }

        /// <summary>
        /// valida que el string DNI sea correcto, Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.) 
        /// se lanzará DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            dato = dato.Replace(".", "");
            if (dato.Length < 1 || dato.Length > 8 )
            {
                throw new DniInvalidoException("cantidad de caranteres de dni invalida");
            }
            try
            {
                dni = int.Parse(dato);
            } 
            catch(Exception e)
            {
                throw new DniInvalidoException("el dni solo debe contener caranteres numericos", e);
            }
            return this.ValidarDni(nacionalidad, dni);
        }

        /// <summary>
        /// Valida que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string nomAp = "";
            if (Regex.IsMatch(dato, @"^[a-zA-z]+$"))
            {
                nomAp = dato;
            }
            return nomAp;
        }
        #endregion
    }
}
