using System;

class Program
{
    static void Main(string[] args)
    {
        ArbolBST arbol = new ArbolBST();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- MENU BST ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Inorden");
            Console.WriteLine("5. Preorden");
            Console.WriteLine("6. Postorden");
            Console.WriteLine("7. Minimo");
            Console.WriteLine("8. Maximo");
            Console.WriteLine("9. Altura");
            Console.WriteLine("10. Limpiar");
            Console.WriteLine("0. Salir");

            Console.Write("Opcion: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada invalida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Valor: ");
                    if (!int.TryParse(Console.ReadLine(), out valor))
                    {
                        Console.WriteLine("Valor invalido.");
                        continue;
                    }
                    arbol.Insertar(valor);
                    break;

                case 2:
                    Console.Write("Buscar: ");
                    if (!int.TryParse(Console.ReadLine(), out valor))
                    {
                        Console.WriteLine("Valor invalido.");
                        continue;
                    }
                    Console.WriteLine(arbol.Buscar(valor) ? "Encontrado" : "No encontrado");
                    break;

                case 3:
                    Console.Write("Eliminar: ");
                    if (!int.TryParse(Console.ReadLine(), out valor))
                    {
                        Console.WriteLine("Valor invalido.");
                        continue;
                    }
                    arbol.Eliminar(valor);
                    break;

                case 4:
                    arbol.InOrden();
                    Console.WriteLine();
                    break;

                case 5:
                    arbol.PreOrden();
                    Console.WriteLine();
                    break;

                case 6:
                    arbol.PostOrden();
                    Console.WriteLine();
                    break;

                case 7:
                    try
                    {
                        Console.WriteLine("Minimo: " + arbol.Minimo());
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("El arbol esta vacio");
                    }
                    break;

                case 8:
                    try
                    {
                        Console.WriteLine("Maximo: " + arbol.Maximo());
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("El arbol esta vacio");
                    }
                    break;

                case 9:
                    Console.WriteLine("Altura: " + arbol.Altura());
                    break;

                case 10:
                    arbol.Limpiar();
                    Console.WriteLine("Arbol limpiado");
                    break;
            }

        } while (opcion != 0);
    }
}