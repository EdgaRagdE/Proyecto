using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using Proyecto_Arbol.control;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_Arbol.analizador
{
    class Sintactico : Grammar
    {
        public static ParseTreeNode analizar(String cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            return arbol.Root;
        }

        public static Image getImage(ParseTreeNode raiz)
        {
            string grafoDOT = ControlD.getDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDOT);
            byte[] imageBytes = Convert.FromBase64String(img.ToBase64String());
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            Image imagen = Image.FromStream(ms, true);
            return imagen;
        }

        private static void generarImage(ParseTreeNode raiz)
        {
            String grafoDOT = ControlD.getDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDOT);
            img.Save("AST.png");
        }
    }
}
