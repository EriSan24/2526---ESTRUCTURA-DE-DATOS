using System;
using System.Collections.Generic;
using System.Linq;

class Traductor
{
    static void Main(string[] args)
    {
        // Diccionario bilingüe bidireccional (Inglés -> Español)
        Dictionary<string, string> diccionarioIngEs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"child", "niño"},
            {"eye", "ojo"},
            {"woman", "mujer"},
            {"place", "lugar"},
            {"work", "trabajo"},
            {"week", "semana"},
            {"case", "caso"},
            {"point", "punto"},
            {"government", "gobierno"},
            {"company", "empresa"}
        };

        // Diccionario inverso (Español -> Inglés)
        Dictionary<string, string> diccionarioEsIng = CrearDiccionarioInverso(diccionarioIngEs);

        int opcion;

        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("3. Ver diccionario completo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Error: Ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionarioIngEs, diccionarioEsIng);
                    break;

                case 2:
                    AgregarPalabra(diccionarioIngEs, diccionarioEsIng);
                    break;

                case 3:
                    MostrarDiccionario(diccionarioIngEs);
                    break;

                case 0:
                    Console.WriteLine("\nSaliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }

    static Dictionary<string, string> CrearDiccionarioInverso(Dictionary<string, string> diccionario)
    {
        Dictionary<string, string> inverso = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var par in diccionario)
        {
            inverso[par.Value] = par.Key;
        }
        return inverso;
    }

    static void TraducirFrase(Dictionary<string, string> diccionarioIngEs, Dictionary<string, string> diccionarioEsIng)
    {
        Console.Write("\nIngrese una frase: ");
        string? frase = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(frase))
        {
            Console.WriteLine("Error: La frase no puede estar vacía.");
            return;
        }

        string[] palabras = frase.Split(' ');
        string resultado = "";
        char[] puntuacion = { ',', '.', ';', ':', '¡', '!', '¿', '?' };

        foreach (string palabra in palabras)
        {
            // Extraer puntuación al final
            string palabraLimpia = palabra.Trim();
            string puntuacionFinal = "";

            while (palabraLimpia.Length > 0 && puntuacion.Contains(palabraLimpia[palabraLimpia.Length - 1]))
            {
                puntuacionFinal = palabraLimpia[palabraLimpia.Length - 1] + puntuacionFinal;
                palabraLimpia = palabraLimpia.Substring(0, palabraLimpia.Length - 1);
            }

            // Intentar traducir de Inglés a Español
            if (diccionarioIngEs.ContainsKey(palabraLimpia))
            {
                resultado += diccionarioIngEs[palabraLimpia] + puntuacionFinal + " ";
            }
            // Intentar traducir de Español a Inglés
            else if (diccionarioEsIng.ContainsKey(palabraLimpia))
            {
                resultado += diccionarioEsIng[palabraLimpia] + puntuacionFinal + " ";
            }
            else
            {
                resultado += palabra + " ";
            }
        }

        Console.WriteLine("Traducción: " + resultado.Trim());
    }

    static void AgregarPalabra(Dictionary<string, string> diccionarioIngEs, Dictionary<string, string> diccionarioEsIng)
    {
        Console.Write("\nIngrese la palabra en inglés: ");
        string? ingles = Console.ReadLine()?.ToLower().Trim();

        if (string.IsNullOrWhiteSpace(ingles))
        {
            Console.WriteLine("Error: La palabra no puede estar vacía.");
            return;
        }

        Console.Write("Ingrese la traducción en español: ");
        string? español = Console.ReadLine()?.ToLower().Trim();

        if (string.IsNullOrWhiteSpace(español))
        {
            Console.WriteLine("Error: La traducción no puede estar vacía.");
            return;
        }

        if (!diccionarioIngEs.ContainsKey(ingles))
        {
            diccionarioIngEs.Add(ingles, español);
            diccionarioEsIng.Add(español, ingles);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }

    static void MostrarDiccionario(Dictionary<string, string> diccionario)
    {
        Console.WriteLine("\n========== DICCIONARIO (Inglés -> Español) ==========");
        foreach (var par in diccionario.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{par.Key,-20} -> {par.Value}");
        }
        Console.WriteLine($"\nTotal de palabras: {diccionario.Count}");
    }
}
