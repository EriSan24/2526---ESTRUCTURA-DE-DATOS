using System;
using System.Collections.Generic;

class ValidadorExpresion
{
    static void Main()
    {
        Console.WriteLine("Ingrese una expresión matemática:");
        string expresion = Console.ReadLine();

        if (ValidarExpresion(expresion))
        {
            Console.WriteLine("La expresión está correctamente balanceada.");
        }
        else
        {
            Console.WriteLine("La expresión NO está balanceada.");
        }

        Console.ReadKey(); // Pausa la consola
    }

    static bool ValidarExpresion(string texto)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char caracter in texto)
        {
            // Si es un símbolo de apertura, se guarda en la pila
            if (caracter == '(' || caracter == '{' || caracter == '[')
            {
                pila.Push(caracter);
            }
            // Si es un símbolo de cierre, se verifica
            else if (caracter == ')' || caracter == '}' || caracter == ']')
            {
                if (pila.Count == 0)
                    return false;

                char ultimo = pila.Pop();

                if (!Coinciden(ultimo, caracter))
                    return false;
            }
        }

        // Si la pila queda vacía, la expresión es correcta
        return pila.Count == 0;
    }

    static bool Coinciden(char abre, char cierra)
    {
        if (abre == '(' && cierra == ')') return true;
        if (abre == '{' && cierra == '}') return true;
        if (abre == '[' && cierra == ']') return true;

        return false;
    }
}
