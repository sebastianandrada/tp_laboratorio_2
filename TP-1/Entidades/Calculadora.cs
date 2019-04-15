using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida y realiza la operacion pedida entre dos numeros
        /// </summary>
        /// <param name="numero1">n°1</param>
        /// <param name="numero2">n°2</param>
        /// <param name="operador">string que representa un operador (+, -, / o *)</param>
        /// <returns>el resultado de la operacion pedida</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    resultado = numero2.GetNumero() == 0 ? double.MinValue : numero1 / numero2;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida que el operador recibido sea alguno de los siguientes: +, -, / o *
        /// </summary>
        /// <param name="operador">string que representa un operador matematico</param>
        /// <returns>el valor del operador en caso de ser valido, o "+" en caso de no ser valido</returns>
        private static string ValidarOperador(string operador)
        {
            return operador == "+" || operador == "-" || operador == "*" || operador == "/" ? operador : "+";
        }
    }
}
