using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region "Propiedades"
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region "Constructores"
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Guardará todos los datos de una Jornada en un archivo de texto que se localizará en el escritorio
        /// </summary>
        /// <param name="jornada">Objeto de tipo Jornada</param>
        /// <returns>Retornará true si el archivo se ha generado correctamente</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool resultado = false;
            string path = String.Format("{0}\\Jornada.txt", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Texto texto = new Texto();

            resultado = texto.Guardar(path, jornada.ToString());

            return resultado;
        }

        /// <summary>
        /// Leerá los datos de un archivo, que contiene los datos de una jornada
        /// </summary>
        /// <returns>Retornará un string con los datos de Jornada.ToString()</returns>
        public string Leer()
        {
            string path = String.Format("{0}\\Jornada.txt", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Texto texto = new Texto();
            string resultado = "";

            texto.Leer(path, out resultado);

            return resultado;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Indica si un alumno participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si participa de la clase</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool participaEnClase = false;
            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                {
                    participaEnClase = true;
                    break;
                }
            }
            return participaEnClase;
        }

        /// <summary>
        /// Indicara si un alumno no participa de la clase de jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si el alumno no participa de la clase</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregará un alumno a la clase, si es que el alumno no pertenece a la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>la misma jornada, con el alumno agregado a la clase</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool estaCargado = false;
            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                {
                    estaCargado = true;
                    break;
                }
            }
            if (!estaCargado)
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Retorna un string con todos los datos de una jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}\n", this.clase.ToString(), this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.Append(alumno.ToString());
            }
            sb.AppendLine("\n<------------------------------------------------>");
            return sb.ToString();
        }
        #endregion
    }
}
