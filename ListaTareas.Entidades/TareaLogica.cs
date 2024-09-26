using ListaTareas.Entidades;

namespace ListaTareas.Logica;

public interface ITareaLogica
{
    List<Tarea> ObtenerTareas();
    void AgregarTarea(Tarea tarea);
    void EliminarTarea(int idTarea);

    void EditarTarea(Tarea tarea);

    void CompletarTarea(int idTarea);
    Tarea ObtenerTareaPorId(int idTarea);
}
public class TareaLogica : ITareaLogica
{

    public static List<Tarea> tareas;



    public List<Tarea> ObtenerTareas()
    {
        if (tareas == null) {
            tareas = new List<Tarea>();

        tareas.Add(new Tarea { IdTarea = 1, Descripcion = "Tarea 1", Completada = false });
    }
        return tareas;
    }

    public void AgregarTarea(Tarea tarea)
    {
        tarea.IdTarea = tareas.Count == 0 ? 1 : tareas.Max(v => v.IdTarea) + 1;
        tarea.Completada = false;
        tareas.Add(tarea);
    }

    public void EliminarTarea(int idTarea)
    {
        tareas.RemoveAll(t => t.IdTarea == idTarea);
    }

    public void CompletarTarea(int idTarea)
    {
        var tarea = tareas.FirstOrDefault(t => t.IdTarea == idTarea);
        if (tarea != null)
            tarea.Completada = true;
    }

    public void EditarTarea(Tarea tarea)
    {
        var tareaEditar = tareas.FirstOrDefault(t => t.IdTarea == tarea.IdTarea);
        if (tareaEditar != null)
        {
            tareaEditar.Descripcion = tarea.Descripcion;
        }
    }

    public Tarea ObtenerTareaPorId(int idTarea)
    {
        return tareas.FirstOrDefault(t => t.IdTarea == idTarea);
    }
}
