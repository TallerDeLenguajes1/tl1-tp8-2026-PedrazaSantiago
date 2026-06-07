namespace EspacioTarea;

public class Tarea
{
    private int tareaID;
    private string descripcion;
    private int duracion;
    public int TareaID
    {
        get => tareaID;
        set => tareaID=value;
    }
    public string Descripcion
    {
        get => descripcion;
        set => descripcion=value;
    }
    
    public int Duracion
    {
        get => duracion;
        set
        {
            if (value >= 10 && value <= 100)
            {
                duracion = value;
            }
            else
            {
                duracion = 10;
            }
        }
    }

    public Tarea(int tareaID, string descripcion, int duracion)
    {
        this.tareaID = tareaID;
        this.descripcion = descripcion;
        this.duracion = duracion;
    }

    public void MostrarDetalles()
    {
        Console.WriteLine($"[ID: {this.tareaID}] - {this.descripcion} ({this.duracion} min)");
    }

}