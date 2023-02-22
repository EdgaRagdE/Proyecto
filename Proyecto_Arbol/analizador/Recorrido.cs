using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;

namespace Proyecto_Arbol.analizador
{
    class Recorrido
    {
        public static void resolverOperacion(ParseTreeNode root)
        {
            MessageBox.Show("El resultado es: " + expresion(root.ChildNodes.ElementAt(0)));

        }

        private static Double expresion(ParseTreeNode root) 
        {
            switch (root.ChildNodes.Count) 
            {
                default:
                    return expresion(root.ChildNodes.ElementAt(1));
                case 1:
                    {
                        String[] numero = root.ChildNodes.ElementAt(0).ToString().Split(' ');
                        return Convert.ToDouble(numero[0]);
                    }
                case 3:
                    {
                        switch (root.ChildNodes.ElementAt(1).ToString().Substring(0, 1))
                        {
                            case "+":
                                return expresion(root.ChildNodes.ElementAt(0)) + expresion(root.ChildNodes.ElementAt(2));
                            case "-":
                                return expresion(root.ChildNodes.ElementAt(0)) - expresion(root.ChildNodes.ElementAt(2));
                            case "*":
                                return expresion(root.ChildNodes.ElementAt(0)) * expresion(root.ChildNodes.ElementAt(2));
                            case "/":
                                return expresion(root.ChildNodes.ElementAt(0)) / expresion(root.ChildNodes.ElementAt(2));
                            default:
                                return expresion(root.ChildNodes.ElementAt(1));
                        }
                    }

            }
            return 0.0;
        }
    }
}
