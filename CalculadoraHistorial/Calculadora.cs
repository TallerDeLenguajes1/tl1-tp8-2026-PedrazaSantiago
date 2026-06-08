namespace EspacioCalculadora;

public enum TipoOperacion
{
    Suma,
    Resta,
    Multiplicacion,
    Division,
    Limpiar
}

public class Operacion
{
    private double resultadoAnterior;
    private double nuevoValor;
    private TipoOperacion operacion;
    private double resultado;
    public double ResultadoAnterior
    {
        get => resultadoAnterior;
    }
    public double NuevoValor
    {
        get => nuevoValor;
    }
    public TipoOperacion OperacionTipo
    {
        get => operacion;
    }
    public double Resultado
    {
        get => resultado;
    }

    public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion, double resultado)
    {
        this.resultadoAnterior = resultadoAnterior;
        this.nuevoValor = nuevoValor;
        this.operacion = operacion;
        this.resultado = resultado;
    }

    public void MostrarOperacion()
    {
        string simbolo = "";
        switch (this.operacion)
        {
            case TipoOperacion.Suma:
                simbolo = "+";
                break;
            case TipoOperacion.Resta:
                simbolo = "-";
                break;
            case TipoOperacion.Multiplicacion:
                simbolo = "*";
                break;
            case TipoOperacion.Division:
                simbolo = "/";
                break;
            case TipoOperacion.Limpiar:
                simbolo = "limpiar";
                break;
        }
        if (this.operacion == TipoOperacion.Limpiar)
        {
            Console.WriteLine("El resultado se restablecio a 0");
        }
        else
        {
            Console.WriteLine($"{this.resultadoAnterior} {simbolo} {this.nuevoValor} = {this.resultado}");
        }
    }
}

public class Calculadora
{
    private double dato = 0;
    private List<Operacion> historial=new List<Operacion>();
    public double Resultado
    {
        get => dato;
    }
    public List<Operacion> Historial
    {
        get => historial;
    }
    public void Sumar(double termino)
    {
        double anterior = dato;
        dato += termino;
        historial.Add(new Operacion(anterior, termino, TipoOperacion.Suma, dato));
    }

    public void Restar(double termino)
    {
        double anterior = dato;        
        dato -= termino;
        historial.Add(new Operacion(anterior, termino, TipoOperacion.Resta, dato));
    }

    public void Multiplicar(double termino)
    {
        double anterior = dato;        
        dato *= termino;
        historial.Add(new Operacion(anterior, termino, TipoOperacion.Multiplicacion, dato));
    }

    public void Dividir(double termino)
    {
        if (termino != 0)
        {
            double anterior = dato;            
            dato /= termino;
            historial.Add(new Operacion(anterior, termino, TipoOperacion.Division, dato));
        }
        else
        {
            Console.WriteLine("No se puede dividor por cero");
        }
    }

    public void Limpiar()
    {
        double anterior = dato;
        dato = 0;
        historial.Add(new Operacion(anterior, 0, TipoOperacion.Limpiar, dato));
    }
}

