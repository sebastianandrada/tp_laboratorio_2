using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Setea la propeidad numero
        /// </summary>
        private string SetNumero
        {
            set {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario">un string que representa un numero binario</param>
        /// <returns>Un valor decimal o "valor invalido" en caso de no poder convertir</returns>
        public string BinarioDecimal(string binario)
        {
            bool valido = true;
            double sum = 0;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '1')
                {
                    sum = sum + Math.Pow(2, (binario.Length - (i + 1)));
                } else if(binario[i] != '0')
                {
                    valido = false;
                    break;
                }
            }
            return valido ? sum.ToString() : "Valor invalido";
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">un string que representa un numero decimal</param>
        /// <returns>un string que representa un numero binario o "valor invalido" en caso de no poder realizar la conversion</returns>
        public string DecimalBinario(string numero)
        {
            string rdo = string.Empty;
            if (double.TryParse(numero, out double valor))
            {
                rdo = this.DecimalBinario(valor);
            }
            else
            {
                rdo = "Valor invalido";
            }
            return rdo;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">un double que representa un numero decmal</param>
        /// <returns>un string que representa un numero binario o "valor invalido" en caso de no poder realizar la conversion</returns>
        public string DecimalBinario(double numero)
        {
            string rdo = string.Empty;
            int enteroAbs = Math.Abs((int)numero);
            while (enteroAbs > 0)
            {
                rdo = (enteroAbs % 2).ToString() + rdo;
                enteroAbs = enteroAbs / 2;
            }
            return rdo;
        }

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="numero">numero double</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="strNumero">un string que representa a un numero double</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Sobrecarga de operador -
        /// </summary>
        /// <param name="numero1">n°1</param>
        /// <param name="numero2">n°2</param>
        /// <returns>el resultado de la resta</returns>
        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.numero - numero2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador +
        /// </summary>
        /// <param name="numero1">n°1</param>
        /// <param name="numero2">n°2</param>
        /// <returns>el resultado de la suma</returns>
        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.numero + numero2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="numero1">n°1</param>
        /// <param name="numero2">n°2</param>
        /// <returns>el resultado de la multiplicacion</returns>
        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.numero * numero2.numero;
        }

        /// <summary>
        /// Spbrecarga del operador /
        /// </summary>
        /// <param name="numero1">n°1</param>
        /// <param name="numero2">n°2</param>
        /// <returns>Resultado de la operacion devision</returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            return numero1.numero / numero2.numero;
        }

        /// <summary>
        /// comprueba que el valor recibido sea numérico
        /// </summary>
        /// <param name="strNumero">string que representa a un numero</param>
        /// <returns>retorna un valor formato double. En caso que no sea numerico, retorna 0.</returns>
        private static double ValidarNumero(string strNumero)
        {
            return double.TryParse(strNumero, out double ret) ? ret : 0;
        }

        /// <summary>
        /// getter del atributo numero
        /// </summary>
        /// <returns>double</returns>
        public double GetNumero()
        {
            return this.numero;
        }
    }
}
