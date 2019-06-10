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
        public static bool Guardar(Universidad uni)
        {
            string path = String.Format("{0}\\Universidad.xml", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            bool resultado = false;
            Xml<Universidad> xml = new Xml<Universidad>();

            resultado = xml.Guardar(path, uni);

            return resultado;
        }

        public static Universidad Leer()
        {
            string path = String.Format("{0}\\Universidad.xml", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad uni = new Universidad();

            xml.Leer(path, out uni);

            return uni;
        }

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

        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            return u;
        }

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
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion
    }
}
