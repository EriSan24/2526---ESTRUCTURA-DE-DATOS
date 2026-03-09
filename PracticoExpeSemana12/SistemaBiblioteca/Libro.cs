using System;

class Libro
{
    public int Codigo { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Año { get; set; }

    public Libro(int codigo, string titulo, string autor, int año)
    {
        Codigo = codigo;
        Titulo = titulo;
        Autor = autor;
        Año = año;
    }

    public override string ToString()
    {
        return $"Código: {Codigo} | Título: {Titulo} | Autor: {Autor} | Año: {Año}";
    }
}
