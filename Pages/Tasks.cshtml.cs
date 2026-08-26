using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetHtmxApp.Models;
using AspNetHtmxApp.Services;

namespace AspNetHtmxApp.Pages;

public class TasksModel(TaskService taskService) : PageModel
{
    private readonly TaskService _taskService = taskService;

    public List<TaskItem> Tasks { get; set; } = [];

    public void OnGet()
    {
        Tasks = _taskService.GetAll();
    }

    // CREATE: hx-post
    public IActionResult OnPostCreate(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Content("<p class=\"error\">Title is required</p>", "text/html");

        var task = _taskService.Create(title);
        return Partial("_TaskItem", task);
    }

    // READ: hx-get (load edit form)
    public IActionResult OnGetEdit(int id)
    {
        var task = _taskService.GetById(id);
        return task is not null
            ? Partial("_TaskEditForm", task)
            : Content("<p class=\"error\">Task not found</p>", "text/html");
    }

    // UPDATE: hx-put (full update)
    public IActionResult OnPutUpdate(int id, string title)
    {
        var task = _taskService.Update(id, title);
        return task is not null
            ? Partial("_TaskItem", task)
            : Content("<p class=\"error\">Task not found</p>", "text/html");
    }

    // PARTIAL UPDATE: hx-patch (toggle complete)
    public IActionResult OnPatchToggle(int id)
    {
        var task = _taskService.ToggleComplete(id);
        return task is not null 
            ? Partial("_TaskItem", task)
            : Content("<p class=\"error\">Task not found</p>", "text/html");
    }

    // DELETE: hx-delete
    public IActionResult OnDeleteRemove(int id)
    {
        var success = _taskService.Delete(id);
        return success 
            ? Content("", "text/html") 
            : Content("<p class=\"error\">Task not found</p>", "text/html");
    }
}
