using System;

namespace TareaSemana5.Ejercicio1
{
    public class Asignatura
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Creditos { get; set; }

        public Asignatura() { }

        public Asignatura(string nombre, string codigo, int creditos)
        {
            Nombre = nombre;
            Codigo = codigo;
            Creditos = creditos;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nombre} ({Creditos} créditos)";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Asignatura asignatura1 = new Asignatura("Matemáticas", "MAT101", 4);
            Asignatura asignatura2 = new Asignatura("Historia", "HIS202", 3);

            Console.WriteLine(asignatura1);
            Console.WriteLine(asignatura2);
        }
    }
}