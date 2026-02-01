using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== SIMULACIÓN DE COLAS - ESTRUCTURA DE DATOS ===\n");

        // Ejercicio 1: Asignación de 30 asientos en orden de llegada
        Console.WriteLine("EJERCICIO 1: Asignación de 30 Asientos en Orden de Llegada");
        Console.WriteLine("=========================================================\n");
        Ejercicio1();

        Console.WriteLine("\n" + new string('=', 80) + "\n");

        // Ejercicio 2: Simulación de línea de espera para atracción de parque
        Console.WriteLine("EJERCICIO 2: Simulación de Línea de Espera - Parque de Diversiones");
        Console.WriteLine("==================================================================\n");
        Ejercicio2();

        Console.WriteLine("\n" + new string('=', 80) + "\n");

        // Ejercicio 3: Asignación de 100 asientos para auditorio
        Console.WriteLine("EJERCICIO 3: Asignación de 100 Asientos de Auditorio");
        Console.WriteLine("====================================================\n");
        Ejercicio3();

        Console.WriteLine("\n" + new string('=', 80));
        Console.WriteLine("FIN DE LA SIMULACIÓN");
    }

    static void Ejercicio1()
    {
        Stopwatch sw = Stopwatch.StartNew();

        Cola cola = new Cola(30);

        // Agregar 30 personas
        for (int i = 1; i <= 30; i++)
        {
            cola.AgregarPersona($"Persona {i}");
        }

        Console.WriteLine("\n--- Personas en la Cola ---");
        cola.ReportarCola();

        Console.WriteLine("\n--- Asignando Asientos ---");
        cola.AsignarAsientos();

        sw.Stop();
        Console.WriteLine($"\nTiempo de ejecución: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Análisis: La cola opera en O(1) para inserción y O(1) para eliminación.");
    }

    static void Ejercicio2()
    {
        Stopwatch sw = Stopwatch.StartNew();

        Cola colaAtraccion = new Cola(50);

        Console.WriteLine("Simulando entrada de personas a la atracción...\n");

        // Simular llegada de personas
        string[] nombres = { "Ana", "Bruno", "Carlos", "Diana", "Enrique", "Fiona", "Gustavo", "Helena", "Iván", "Juana" };

        for (int ronda = 1; ronda <= 5; ronda++)
        {
            Console.WriteLine($"--- Ronda {ronda} de Llegadas ---");
            for (int i = 0; i < 10 && (ronda - 1) * 10 + i < 50; i++)
            {
                string nombre = nombres[i % nombres.Length] + $" (Llegada {(ronda - 1) * 10 + i + 1})";
                colaAtraccion.AgregarPersona(nombre);
            }
        }

        Console.WriteLine("\n--- Primeras 15 Personas en la Atracción ---");
        colaAtraccion.ReportarColaMostrar(15);

        Console.WriteLine("\n--- Asignando lugares en la Atracción (primeros 20) ---");
        colaAtraccion.AsignarAsientosParciales(20);

        sw.Stop();
        Console.WriteLine($"\nTiempo de ejecución: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Ventajas de usar Cola (FIFO): Orden justo, garantiza que los primeros atendidos sean los primeros llegados.");
        Console.WriteLine($"Desventajas: No permite acceso directo a elementos específicos sin desencolar.");
    }

    static void Ejercicio3()
    {
        Stopwatch sw = Stopwatch.StartNew();

        Cola colaAuditorio = new Cola(100);

        Console.WriteLine("Registrando asistentes al congreso en el auditorio...\n");

        // Registrar 100 personas
        for (int i = 1; i <= 100; i++)
        {
            colaAuditorio.AgregarPersona($"Asistente {i}");
            if (i % 20 == 0)
                Console.WriteLine($"Registrados {i} asistentes...");
        }

        Console.WriteLine("\n--- Primeros 10 Asistentes en la Cola ---");
        colaAuditorio.ReportarColaMostrar(10);

        Console.WriteLine("\n--- Asignando primeros 15 Asientos de Auditorio ---");
        colaAuditorio.AsignarAsientosParciales(15);

        sw.Stop();
        Console.WriteLine($"\nTiempo de ejecución: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Complejidad Temporal:");
        Console.WriteLine($"  - Inserción: O(1)");
        Console.WriteLine($"  - Eliminación: O(1)");
        Console.WriteLine($"  - Total para 100 personas: O(100) = O(n)");
    }
}
