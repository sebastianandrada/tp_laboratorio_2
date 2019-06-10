using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region "Constructores"
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.randomClases();
        }
        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }
         
        #endregion

        #region "Metodos"

        private void randomClases()
        {
            for(int i = 0; i<2; i++)
            {
                int clase = random.Next(0,3);
                switch (clase)
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach(Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region "Sobrecargas"
        public static bool operator ==(Profesor i, Universidad.EClases clases)
        {
            bool daClase = false;
            foreach(Universidad.EClases clase in i.clasesDelDia)
            {
                if(clase == clases)
                {
                    daClase = true;
                    break;
                }
            }
            return daClase;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clases)
        {
            return !(i == clases);
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
