using System.Runtime.InteropServices.Marshalling;
using EspacioTarea;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

tareasPendientes = CargarTareas(5);

int opcion;
bool continuar = true;
do
{
    Console.WriteLine("=== SISTEMA DE CONTROL TO-DO ===");
    Console.WriteLine("1. Marcar tarea pendiente como Realizada");
    Console.WriteLine("2. Buscar tarea pendiente por palabras clave");
    Console.WriteLine("3. Ver listado completo de tareas");
    Console.WriteLine("4. Salir");
    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        switch (opcion)
        {
            case 1:
                TransferirTareaA();
                break;
            case 2:
                BuscarTarea();
                break;
            case 3:
                MostrarHistorial();
                break;
            case 4:
                continuar = false;
                break;
        }
    }
    else
    {
        Console.WriteLine("No es una opcion");
    }
} while (continuar);

List<Tarea> CargarTareas(int cantidad)
{
    List<Tarea> listaGenerada = new List<Tarea>();
    Random rand = new Random();
    string[] Descripciones = { "tarea1", "tarea2", "tarea3", "tarea4", "tarea5" };

    for (int i = 0; i < cantidad; i++)
    {
        int id = i + 1;
        string desc = Descripciones[rand.Next(Descripciones.Length)];
        int duracion = rand.Next(10, 100);
        Tarea nuevaTarea = new Tarea(id, desc, duracion);
        listaGenerada.Add(nuevaTarea);
    }

    return listaGenerada;
}

void TransferirTareaA()
{
    if (tareasPendientes.Count == 0)
    {
        Console.WriteLine("No hay tareas pendientes");
        return;
    }
    foreach (Tarea t in tareasPendientes)
    {
        t.MostrarDetalles();
    }
    Console.WriteLine("Ingrese el ID de la tarea a transferir");
    if (int.TryParse(Console.ReadLine(), out int buscado))
    {
        Tarea encontrada = tareasPendientes.Find(t => t.TareaID == buscado);
        if (encontrada != null)
        {
            tareasPendientes.Remove(encontrada);
            tareasRealizadas.Add(encontrada);
            Console.WriteLine("Tarea transferida");
        }
        else
        {
            Console.WriteLine("No se encontro ninguna tarea con ese ID");
        }
    }
}


void BuscarTarea()
{
    Console.WriteLine("Ingrese la descripcion de la tarea a buscar:");
    string desc = Console.ReadLine().ToLower();
    bool bandera = false;
    foreach (Tarea t in tareasPendientes)
    {
        if (t.Descripcion.ToLower().Contains(desc))
        {
            t.MostrarDetalles();
            bandera = true;
        }
    }
    if (!bandera)
    {
        Console.WriteLine("No se encontro la tarea");
    }
}

void MostrarHistorial()
{
    Console.WriteLine("Listado de las tareas pendientes:");
    if (tareasPendientes.Count == 0)
    {
        Console.WriteLine("No hay tareas pendientes");
    }
    else
    {
        foreach (Tarea t in tareasPendientes)
        {
            t.MostrarDetalles();
        }
    }
    Console.WriteLine("Listado de las tareas realizadas:");
    if (tareasRealizadas.Count == 0)
    {
        Console.WriteLine("No hay tareas realizadas");
    }
    else
    {
        foreach (Tarea t in tareasRealizadas)
        {
            t.MostrarDetalles();
        }
    }
}