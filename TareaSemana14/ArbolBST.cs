using System;

public class ArbolBST
{
    private Nodo raiz;

    public ArbolBST()
    {
        raiz = null;
    }

    // INSERTAR
    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);

        return nodo;
    }

    // BUSCAR
    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private bool BuscarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return false;

        if (valor == nodo.Valor)
            return true;

        return valor < nodo.Valor
            ? BuscarRec(nodo.Izquierdo, valor)
            : BuscarRec(nodo.Derecho, valor);
    }

    // ELIMINAR
    public void Eliminar(int valor)
    {
        raiz = EliminarRec(raiz, valor);
    }

    private Nodo EliminarRec(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRec(nodo.Derecho, valor);
        else
        {
            // Caso 1: sin hijos
            if (nodo.Izquierdo == null && nodo.Derecho == null)
                return null;

            // Caso 2: un hijo
            if (nodo.Izquierdo == null)
                return nodo.Derecho;
            else if (nodo.Derecho == null)
                return nodo.Izquierdo;

            // Caso 3: dos hijos
            Nodo sucesor = MinimoNodo(nodo.Derecho);
            nodo.Valor = sucesor.Valor;
            nodo.Derecho = EliminarRec(nodo.Derecho, sucesor.Valor);
        }

        return nodo;
    }

    // RECORRIDOS
    public void InOrden() => InOrdenRec(raiz);
    private void InOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrdenRec(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InOrdenRec(nodo.Derecho);
        }
    }

    public void PreOrden() => PreOrdenRec(raiz);
    private void PreOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreOrdenRec(nodo.Izquierdo);
            PreOrdenRec(nodo.Derecho);
        }
    }

    public void PostOrden() => PostOrdenRec(raiz);
    private void PostOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrdenRec(nodo.Izquierdo);
            PostOrdenRec(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    // MÍNIMO Y MÁXIMO
    public int Minimo()
    {
        if (raiz == null) throw new InvalidOperationException("El arbol esta vacio");
        return MinimoNodo(raiz).Valor;
    }

    private Nodo MinimoNodo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;
        return nodo;
    }

    public int Maximo()
    {
        if (raiz == null) throw new InvalidOperationException("El arbol esta vacio");
        Nodo actual = raiz;
        while (actual.Derecho != null)
            actual = actual.Derecho;
        return actual.Valor;
    }

    // ALTURA
    public int Altura()
    {
        return AlturaRec(raiz);
    }

    private int AlturaRec(Nodo nodo)
    {
        if (nodo == null) return -1;

        return 1 + Math.Max(AlturaRec(nodo.Izquierdo), AlturaRec(nodo.Derecho));
    }

    // LIMPIAR
    public void Limpiar()
    {
        raiz = null;
    }
}