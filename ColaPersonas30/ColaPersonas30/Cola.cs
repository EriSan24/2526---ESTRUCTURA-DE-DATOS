using System;
using System.Collections.Generic;

public class Persona
{
    public string Nombre { get; set; }
    public int NumeroAsiento { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
        NumeroAsiento = 0;
    }
}

public class Cola
{
    private Queue<Persona> personas;
    private int asientosDisponibles;
    private int asientoActual;

    public Cola(int asientos)
    {
        personas = new Queue<Persona>();
        asientosDisponibles = asientos;
        asientoActual = 1;
    }

    public void AgregarPersona(string nombre)
    {
        if (asientosDisponibles > 0)
        {
            personas.Enqueue(new Persona(nombre));
            asientosDisponibles--;
        }
        else
        {
            Console.WriteLine($"No hay asientos disponibles para {nombre}.");
        }
    }

    public void AsignarAsientos()
    {
        int contador = 1;
        while (personas.Count > 0)
        {
            Persona persona = personas.Dequeue();
            persona.NumeroAsiento = contador;
            Console.WriteLine($"[Asiento {contador}] {persona.Nombre}");
            contador++;
        }
    }

    public void AsignarAsientosParciales(int cantidad)
    {
        int contador = 1;
        int asignados = 0;
        while (personas.Count > 0 && asignados < cantidad)
        {
            Persona persona = personas.Dequeue();
            persona.NumeroAsiento = contador;
            Console.WriteLine($"[Asiento {contador}] {persona.Nombre}");
            contador++;
            asignados++;
        }
    }

    public void ReportarCola()
    {
        if (personas.Count == 0)
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }

        int posicion = 1;
        foreach (var persona in personas)
        {
            Console.WriteLine($"Posición {posicion}: {persona.Nombre}");
            posicion++;
        }
        Console.WriteLine($"Total en cola: {personas.Count}");
    }

    public void ReportarColaMostrar(int cantidad)
    {
        if (personas.Count == 0)
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }

        int posicion = 1;
        int mostrados = 0;
        foreach (var persona in personas)
        {
            if (mostrados >= cantidad) break;
            Console.WriteLine($"Posición {posicion}: {persona.Nombre}");
            posicion++;
            mostrados++;
        }
        Console.WriteLine($"... y {Math.Max(0, personas.Count - cantidad)} más en la cola");
    }

    public int ObtenerTamanioCola()
    {
        return personas.Count;
    }

    public int ObtenerAsientosDisponibles()
    {
        return asientosDisponibles;
    }
}
