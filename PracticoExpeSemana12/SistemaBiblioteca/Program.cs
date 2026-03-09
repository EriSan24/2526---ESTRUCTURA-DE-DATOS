using System;
using System.Collections.Generic;

class Biblioteca
{
    static Dictionary<int, Libro> libros = new Dictionary<int, Libro>();
    
    static void Main(string[] args)
    {
        int opcion;

        do
        {
            MostrarMenu();
            opcion = ObtenerOpcion();

            switch (opcion)
            {
                case 1:
                    RegistrarLibro();
                    break;

                case 2:
                    ConsultarLibro();
                    break;

                case 3:
                    MostrarTodosLibros();
                    break;

                case 4:
                    Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }

            if (opcion != 4)
            {
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }

        } while (opcion != 4);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("╔════════════════════════════════╗");
        Console.WriteLine("║   SISTEMA DE BIBLIOTECA        ║");
        Console.WriteLine("╠════════════════════════════════╣");
        Console.WriteLine("║ 1. Registrar libro             ║");
        Console.WriteLine("║ 2. Consultar libro             ║");
        Console.WriteLine("║ 3. Mostrar todos los libros    ║");
        Console.WriteLine("║ 4. Salir                       ║");
        Console.WriteLine("╚════════════════════════════════╝");
    }

    static int ObtenerOpcion()
    {
        Console.Write("\nSeleccione una opción: ");
        
        if (int.TryParse(Console.ReadLine(), out int opcion))
        {
            return opcion;
        }
        
        Console.WriteLine("Error: Ingrese un número válido.");
        return 0;
    }

    static void RegistrarLibro()
    {
        Console.WriteLine("\n--- REGISTRAR LIBRO ---");
        
        // Obtener código
        int codigo = ObtenerNumero("Ingrese código del libro: ");
        
        if (libros.ContainsKey(codigo))
        {
            Console.WriteLine("Error: Ya existe un libro con ese código.");
            return;
        }

        // Obtener título
        Console.Write("Ingrese título del libro: ");
        string titulo = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(titulo))
        {
            Console.WriteLine("Error: El título no puede estar vacío.");
            return;
        }

        // Obtener autor
        Console.Write("Ingrese autor del libro: ");
        string autor = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(autor))
        {
            Console.WriteLine("Error: El autor no puede estar vacío.");
            return;
        }

        // Obtener año
        int año = ObtenerNumero("Ingrese año de publicación: ");
        
        if (año < 1000 || año > DateTime.Now.Year)
        {
            Console.WriteLine("Error: Ingrese un año válido.");
            return;
        }

        // Registrar libro
        libros[codigo] = new Libro(codigo, titulo, autor, año);
        Console.WriteLine("✓ Libro registrado correctamente.");
    }

    static void ConsultarLibro()
    {
        Console.WriteLine("\n--- CONSULTAR LIBRO ---");
        
        int codigo = ObtenerNumero("Ingrese código del libro a buscar: ");

        if (libros.ContainsKey(codigo))
        {
            Console.WriteLine("\nLibro encontrado:");
            Console.WriteLine(libros[codigo]);
        }
        else
        {
            Console.WriteLine("Error: Libro no encontrado.");
        }
    }

    static void MostrarTodosLibros()
    {
        Console.WriteLine("\n--- LISTA DE LIBROS ---");
        
        if (libros.Count == 0)
        {
            Console.WriteLine("No hay libros registrados.");
            return;
        }

        Console.WriteLine($"\nTotal de libros: {libros.Count}\n");
        
        foreach (var libro in libros.Values)
        {
            Console.WriteLine(libro);
        }
    }

    static int ObtenerNumero(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                return numero;
            }
            
            Console.WriteLine("Error: Ingrese un número válido.");
        }
    }
}
