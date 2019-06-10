using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }


        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region "Constructor"
        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;   
        }
        #endregion
        
        #region "Operadores"
        /// <summary>
        /// Indicará si un alumno toma la clase y que no sea un "Deudor"
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true, si toma la clase y no es deudor</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Indicara si un alumno es distinto de la clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true, si el alumno no toma la clase</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Retornará un string con todos los datos de un alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta.ToString());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Retornará un string que indica que clase toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASE DE {0}\n", this.claseQueToma.ToString());
        }

        /// <summary>
        /// Retornará un string con todos los datos de un alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
