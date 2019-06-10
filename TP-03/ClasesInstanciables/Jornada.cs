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
        public static bool Guardar(Jornada jornada)
        {
            bool resultado = false;
            string path = String.Format("{0}\\Jornada.txt", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Texto texto = new Texto();

            resultado = texto.Guardar(path, jornada.ToString());

            return resultado;
        }

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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

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
