using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Chapter03DemoModel : PageModel
{
    private static readonly string[] Quotes = [
        "The best code is no code at all.",
        "Simplicity is the ultimate sophistication.",
        "First, solve the problem. Then, write the code.",
        "Code is like humor. When you have to explain it, it is bad."
    ];

    private static readonly string[] Fruits = [
        "Apple", "Apricot", "Banana", "Blueberry", "Cherry",
        "Grape", "Lemon", "Mango", "Orange", "Peach", "Pear",
        "Pineapple", "Raspberry", "Strawberry", "Watermelon"
    ];

    public void OnGet()
    {
    }

    public IActionResult OnGetQuote()
    {
        var quote = Quotes[Random.Shared.Next(Quotes.Length)];
        return Content($"<blockquote>{quote}</blockquote>", "text/html");
    }

    public IActionResult OnGetSearch(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return Content("", "text/html");
        }

        var matches = Fruits
            .Where(f => f.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (matches.Count == 0)
        {
            return Content("<li>No matches found</li>", "text/html");
        }

        var html = string.Join("", matches.Select(f => $"<li>{f}</li>"));
        return Content(html, "text/html");
    }

    public IActionResult OnPostGreet(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Content("<p class=\"error\">Please enter your name.</p>", "text/html");
        }

        return Content($"<p>Hello, <strong>{name}</strong>! Welcome to htmx.</p>", "text/html");
    }
}