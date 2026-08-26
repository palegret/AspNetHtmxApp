using AspNetHtmxApp.Models;

namespace AspNetHtmxApp.Services;

public class TaskService
{
    private static readonly List<TaskItem> Tasks = [
        new TaskItem { Id = 1, Title = "Learn htmx basics", IsComplete = true },
        new TaskItem { Id = 2, Title = "Build CRUD operations", IsComplete = false },
        new TaskItem { Id = 3, Title = "Master advanced patterns", IsComplete = false }
    ];

    private static int _nextId = 4;

    public List<TaskItem> GetAll() => [.. Tasks];

    public TaskItem? GetById(int id) => Tasks.FirstOrDefault(t => t.Id == id);

    public TaskItem Create(string title)
    {
        var task = new TaskItem { Id = _nextId++, Title = title };
        Tasks.Add(task);
        return task;
    }

    public TaskItem? Update(int id, string title)
    {
        var task = GetById(id);
        task?.Title = title;        
        return task;
    }

    public TaskItem? ToggleComplete(int id)
    {
        var task = GetById(id);
        task?.IsComplete = !task.IsComplete;
        return task;
    }

    public bool Delete(int id)
    {
        var task = GetById(id);

        if (task is not null)
        {
            Tasks.Remove(task);
            return true;
        }

        return false;
    }
}
