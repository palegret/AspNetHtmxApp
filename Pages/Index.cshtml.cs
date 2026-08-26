using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private static readonly string[] Messages = [
        "Hello, World!",
        "Welcome to htmx!",
        "Dynamic content is fun!",
        "Server-side rendering rocks!",
        "No JavaScript framework needed!"
    ];

    public void OnGet()
    {
    }

    public IActionResult OnGetMessage()
    {
        var nextMessageIndex = Random.Shared.Next(Messages.Length);
        var message = Messages[nextMessageIndex];
        return Content($"<p>{message}</p>", "text/html");
    }

    public IActionResult OnPostSubmit(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Content("<p class=\"error\">Please enter your name.</p>", "text/html");

        return Content($"<p class=\"success\">Thank you, {name}!</p>", "text/html");
    }

    public IActionResult OnPostAddItem(string item)
    {
        return Content($"<li>{item}</li>", "text/html");
    }
}
