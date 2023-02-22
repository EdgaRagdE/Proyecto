using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace Proyecto_Arbol.analizador
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: false) 
        {
            #region Expresiones Regulares
            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "[0-9]+");
            IdentifierTerminal id = new IdentifierTerminal("id");
            #endregion

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var div = ToTerm("/");
            #endregion

            #region No Terminales
            NonTerminal S = new NonTerminal("S"),
                E = new NonTerminal("E");
            #endregion

            #region Gramatica
            S.Rule = E;
            E.Rule = E + mas + E
                | E + menos + E
                | E + por + E
                | E + div + E
                | ToTerm("(") + E + ToTerm(")")
                | numero
                | id;
            #endregion

            #region Preferencias
            this.Root = S;
            this.RegisterOperators(20, Associativity.Left, mas, menos);
            this.RegisterOperators(30, Associativity.Left, por, div);
            #endregion
        }
    }
}
