using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">evento</param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Limpia los campos de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realiza una operacion matematica de acuerdo los datos ingresados en el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.txtNumero1.Text.Equals(string.Empty) || this.txtNumero2.Text.Equals(string.Empty) || this.cmbOperador.Text.Equals(string.Empty))
            {
                MessageBox.Show("Tenes que completar todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                double rdo = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
                this.lblResultado.Text = rdo.ToString();
            }
        }

        /// <summary>
        /// Setea los campos del formulario con un string vacio
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.cmbOperador.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// Realiza una operacion matematica de acuerdo a los parametros ingresados
        /// </summary>
        /// <param name="numero1">n°1</param>
        /// <param name="numero2">n°2</param>
        /// <param name="operador">operador matematico</param>
        /// <returns>Retorna el double resultado de la operacion matematica</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            return Calculadora.Operar(n1, n2, operador);
        }

        /// <summary>
        /// Metodo que convierte el resultado de la operacion decimal en binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero binario = new Numero();
            string anterior = this.lblResultado.Text;
            if (anterior != "Valor invalido" && anterior != string.Empty && lblResultado.Text[0] != '0')
                this.lblResultado.Text = binario.DecimalBinario(this.lblResultado.Text);
        }

        /// <summary>
        /// Metodo que convierte el resultado de la operacion binaria a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero binario = new Numero();
            string anterior = this.lblResultado.Text;
            if(anterior != "Valor invalido" && anterior != string.Empty)
            {
                this.lblResultado.Text = binario.BinarioDecimal(this.lblResultado.Text);
            }
        }
    }
}
