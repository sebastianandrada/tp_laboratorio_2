using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region "Constructores"
        public Universitario() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Retorna si dos Universitario son iguales, si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool sonIguales = false;
            
            if(obj is Universitario)
            {
                Universitario universitario = (Universitario)obj;
                sonIguales = this == universitario;
            }
            return sonIguales;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Retorna los datos de un universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat("\nLEGAJO NÚMERO: {0}\n", this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// metodo abstracta a ser implementado...
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region "Operadores"
        /// <summary>
        /// Retorna si dos Universitario son iguales, si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }

        /// <summary>
        /// Retorna si dos Universitario son distintos.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
