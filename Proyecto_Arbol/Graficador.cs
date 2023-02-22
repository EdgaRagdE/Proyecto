using Proyecto_Arbol.analizador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using Irony.Ast;

namespace Proyecto_Arbol
{
    public partial class Graficador : Form
    {
        public Graficador()
        {
            InitializeComponent();
        }

        private void analizar_Click(object sender, EventArgs e)
        {
            ParseTreeNode resultado = Sintactico.analizar(textBox1.Text);
            if (resultado != null)
            {
                consola.Text = postfi.InfixToPostfix(textBox1.Text);
                pictureBox1.Image = Sintactico.getImage(resultado);
                Recorrido.resolverOperacion(resultado);
            }
            else 
            {
                consola.Text = "La cadena es incorrecta"; 
            }
        }
    }
}