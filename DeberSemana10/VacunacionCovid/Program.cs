using System;
using System.Collections.Generic;

namespace VacunacionCovid
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1️⃣ Conjunto Universal: 500 ciudadanos
            HashSet<string> ciudadanos = new HashSet<string>();

            for (int i = 1; i <= 500; i++)
            {
                ciudadanos.Add("Ciudadano " + i);
            }

            // 2️⃣ 75 vacunados con Pfizer
            HashSet<string> pfizer = new HashSet<string>();

            for (int i = 1; i <= 75; i++)
            {
                pfizer.Add("Ciudadano " + i);
            }

            // 3️⃣ 75 vacunados con AstraZeneca
            HashSet<string> astraZeneca = new HashSet<string>();

            for (int i = 50; i < 125; i++)
            {
                astraZeneca.Add("Ciudadano " + i);
            }

            // 🔹 Unión (P ∪ A)
            HashSet<string> union = new HashSet<string>(pfizer);
            union.UnionWith(astraZeneca);

            // 🔹 No vacunados U - (P ∪ A)
            HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
            noVacunados.ExceptWith(union);

            // 🔹 Ambas dosis P ∩ A
            HashSet<string> ambasDosis = new HashSet<string>(pfizer);
            ambasDosis.IntersectWith(astraZeneca);

            // 🔹 Solo Pfizer P - A
            HashSet<string> soloPfizer = new HashSet<string>(pfizer);
            soloPfizer.ExceptWith(astraZeneca);

            // 🔹 Solo AstraZeneca A - P
            HashSet<string> soloAstra = new HashSet<string>(astraZeneca);
            soloAstra.ExceptWith(pfizer);

            // 📊 Resultados
            Console.WriteLine("=== RESULTADOS ===\n");

            Console.WriteLine($"No vacunados: {noVacunados.Count}");
            Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
            Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
            Console.WriteLine($"Solo AstraZeneca: {soloAstra.Count}");

            Console.ReadLine();
        }
    }
}
