using EspacioCalculadora;

Calculadora calc = new Calculadora();
bool continuar = true;
Console.WriteLine("Elija una opcion:");
while (continuar)
{
    Console.WriteLine($"Resultado actual: {calc.Resultado}");
    Console.WriteLine("1.Sumar");
    Console.WriteLine("2.Restar");
    Console.WriteLine("3.Multiplicar");
    Console.WriteLine("4.Dividir");
    Console.WriteLine("5.Limpiar");
    Console.WriteLine("6.Salir");
    string opcion = Console.ReadLine();
    double numero = 0;
    if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4")
    {
            Console.WriteLine("Ingrese el numero");
            numero = double.Parse(Console.ReadLine());
    }

    switch (opcion)
    {
        case "1":
            calc.Sumar(numero);
            break;
        case "2":
            calc.Restar(numero);
            break;
        case "3":
            calc.Multiplicar(numero);
            break;    
        case "4":
            calc.Dividir(numero);
            break;    
        case "5":
            calc.Limpiar();
            break;
        case "6":
            continuar = false;
            break;    
    }
}

Console.WriteLine("Calculadora Historial:");
if (calc.Historial.Count == 0)
{
    Console.WriteLine("No se realizo ninguna operacion");
}
else
{
    foreach (Operacion h in calc.Historial)
    {
        h.MostrarOperacion();
    }
}