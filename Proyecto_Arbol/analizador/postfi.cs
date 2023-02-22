using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Arbol.analizador
{
    class postfi
    {
        public static string InfixToPostfix(string infix)
        {
            // Definimos un diccionario que asocia cada operador con su precedencia.
            Dictionary<char, int> precedence = new Dictionary<char, int>
            {
                {'+', 1}, {'-', 1},
                {'*', 2}, {'/', 2}
            };

            // Creamos una pila para almacenar los operadores a medida que los procesamos.
            Stack<char> stack = new Stack<char>();
            // Creamos un StringBuilder para construir la expresión postfix.
            StringBuilder postfix = new StringBuilder();

            // Recorremos la expresión infix carácter por carácter.
            foreach (char c in infix)
            {
                if (c == '(')
                {
                    // Si encontramos un paréntesis de apertura, lo agregamos a la pila.
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    // Si encontramos un paréntesis de cierre, desapilamos los operadores de la pila y los agregamos a la expresión postfix
                    // hasta encontrar el paréntesis de apertura correspondiente.
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix.Append(stack.Pop());
                    }

                    // Una vez que se encuentra el paréntesis de apertura correspondiente, lo desapilamos y lo descartamos.
                    if (stack.Count > 0 && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
                else if (precedence.ContainsKey(c))
                {
                    // Si encontramos un operador, desapilamos los operadores de mayor o igual precedencia de la pila y los agregamos a la
                    // expresión postfix antes de agregar el operador actual a la pila.
                    while (stack.Count > 0 && stack.Peek() != '(' && precedence[c] <= precedence[stack.Peek()])
                    {
                        postfix.Append(stack.Pop());
                    }

                    stack.Push(c);
                }
                else
                {
                    // Si encontramos un operando, lo agregamos directamente a la expresión postfix.
                    postfix.Append(c);
                }
            }

            // Desapilamos cualquier operador restante de la pila y lo agregamos a la expresión postfix.
            while (stack.Count > 0)
            {
                postfix.Append(stack.Pop());
            }

            // Devolvemos la expresión postfix como una cadena.
            return postfix.ToString();
        }
    }
}
