using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    static int paso = 1;

    static void Main()
    {
        int discos = 3;

        Stack<int> origen = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();
        Stack<int> destino = new Stack<int>();

        // Colocamos los discos en la torre origen
        for (int i = discos; i >= 1; i--)
            origen.Push(i);

        ResolverHanoi(discos, origen, destino, auxiliar, "A", "C", "B");
    }

    static void ResolverHanoi(
        int n,
        Stack<int> origen,
        Stack<int> destino,
        Stack<int> auxiliar,
        string nomOrigen,
        string nomDestino,
        string nomAuxiliar)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Paso {paso++}: Mover disco {disco} de {nomOrigen} a {nomDestino}");
            return;
        }

        ResolverHanoi(n - 1, origen, auxiliar, destino, nomOrigen, nomAuxiliar, nomDestino);

        int discoMayor = origen.Pop();
        destino.Push(discoMayor);
        Console.WriteLine($"Paso {paso++}: Mover disco {discoMayor} de {nomOrigen} a {nomDestino}");

        ResolverHanoi(n - 1, auxiliar, destino, origen, nomAuxiliar, nomDestino, nomOrigen);
    }
}
