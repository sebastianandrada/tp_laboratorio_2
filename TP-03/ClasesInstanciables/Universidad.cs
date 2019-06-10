using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                jornadas[i] = value;
            }
        }
        #endregion

        #region "Constructores"
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornadas = new List<Jornada>();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>True si ha realizado la serializacion correctamente</returns>
        public static bool Guardar(Universidad uni)
        {
            string path = String.Format("{0}\\Universidad.xml", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            bool resultado = false;
            Xml<Universidad> xml = new Xml<Universidad>();

            resultado = xml.Guardar(path, uni);

            return resultado;
        }

        /// <summary>
        /// retornará un Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            string path = String.Format("{0}\\Universidad.xml", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad uni = new Universidad();

            xml.Leer(path, out uni);

            return uni;
        }

        /// <summary>
        /// Metodo privado que retorna todos los datos de una universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada j in uni.Jornadas)
            {
                sb.Append(j.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Retorna si una Universidad es igual a un Alumno, si el mismo está inscripto en ella.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>booleano que indica si esta inscripto</returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            bool estaInscripto = false;
            foreach (Alumno alumno in u.alumnos)
            {
                if (alumno == a)
                {
                    estaInscripto = true;
                    break;
                }
            }
            return estaInscripto;
        }

        /// <summary>
        /// Retornara si un alumno no esta inscrito en una universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retornara si un alumno no esta inscrito en una universidad</returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Una Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>Retorna un booleano indicando si un profesor da clases en la universidad</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool estaDandoClases = false;
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                {
                    estaDandoClases = true;
                    break;
                }
            }
            return estaDandoClases;
        }

        /// <summary>
        /// Retorno true si un profesor no está dando clases en una universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// retornará el primer Profesor capaz de dar esa clase. Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Un Profesor, o una excepcion</returns>
        public static Profesor operator ==(Universidad u, Universidad.EClases clase)
        {
            Profesor profesor = null;
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                {
                    profesor = p;
                    break;
                }
            }
            if (object.Equals(profesor, null))
            {
                throw new SinProfesorException();
            }
            return profesor;
        }

        /// <summary>
        /// Retorna el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Un Profesor, o una excepcion si no pudo encontrar ningun profesor que no pueda dar la clase</returns>
        public static Profesor operator !=(Universidad u, Universidad.EClases clase)
        {
            Profesor profesor = null;
            foreach (Profesor ins in u.Instructores)
            {
                if (ins != clase)
                {
                    profesor = ins;
                    break;
                }
            }
            if (object.ReferenceEquals(profesor, null))
            {
                throw new SinProfesorException();
            }
            return profesor;
        }

        /// <summary>
        /// Al agregar una clase a una Universidad se deberá generar y agregar una nueva Jornada indicando la
        /// clase, un Profesor que pueda darla y la lista de alumnos que la toman
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>La misma universidad, con la clase agregada en una jornada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = (g == clase);
            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == clase)
                {
                    jornada.Alumnos.Add(alumno);
                }
            }
            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Agrega un alumno a una universidad, si es que este no pertenece a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>La misma universidad con el alumno inscripto, o sin el alumno inscripto en caso de ya pertenecer</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            return u;
        }

        /// <summary>
        /// Agrega un profesor a una universidad, si es que este no da clases en ella
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>La misma universidad, con el profesor en caso que no pertezca con anterioridad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Metodo publico, que retorna string con todos los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion
    }
}
