using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetHtmxApp.Pages;

/**
 * When working with htmx, the HX-Request header helps differentiate between 
 * standard and htmx-triggered requests. You can check this in your backend 
 * code to return different responses depending on whether the request 
 * originated from htmx.
 */

public class IndexModel : PageModel
{
    bool IsHtmxRequest => Request.Headers.ContainsKey("HX-Request");

    public IActionResult OnGetHello()
    {        
        return IsHtmxRequest 
            ? Content("<strong>Hello, htmx!</strong>", "text/html") 
            : Page();
    }
}
