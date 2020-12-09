using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fracciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void numNumerador1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void lbligual_Click(object sender, EventArgs e)
        {
            Fraccion f1 = new Fraccion((int)numNumerador1.Value, (int)numDenominador1.Value);
            Fraccion f2 = new Fraccion((int)numNumerador1.Value, (int)numDenominador1.Value);
            Fraccion resultado=null;

            switch (cboOperacion.Text)
            {
                case "+":
                    resultado = f1.Sumar(f2);
                    break;

                case "X":
                    resultado = f1.Multiplicar(f2);
                    break;
                case "-":
                    resultado = f1.Restar(f2);
                    break;
                case "/":
                    resultado = f1.Dividir(f2);
                    break;
                default:
                    MessageBox.Show("Falta seleccionar la operacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
                    lblResultado.Text = resultado.ToString();
        }
    }
}
