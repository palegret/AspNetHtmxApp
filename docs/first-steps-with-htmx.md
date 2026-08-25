# First Steps with htmx

- The way we build web applications is changing.
- Client-side JavaScript frameworks dominate modern development.
- They often introduce complexity that many projects do not need, however.
- State management, bundlers, elaborate frontend tooling consume development time and add maintenance burden.
- htmx is different, it enhances HTML's native capabilities for interactive experiences with minimal JavaScript.
- htmx is integrated with Razor Pages for dynamic web apps without complex frontend framework overhead.
- htmx focuses on server-driven interactions.
- It creates fluid user experiences while keeping app logic where it belongs: on the server.
- It uses declarative attributes to handle AJAX requests, event-driven interactions, and form submissions.
- Your markup stays clean and understandable.
- When combined with Razor Pages, htmx blends server-side rendering with targeted interactivity
- This makes applications efficient and maintainable.

## Understanding the Basics of htmx in Razor Pages

- htmx allows you to send AJAX requests using simple HTML attributes.
- The two most fundamental ones are:
  - `hx-get`: Makes an HTTP GET request to fetch content from the server
  - `hx-post`: Sends a POST request to submit data to the server

### The Handler Naming Convention

- In Razor Pages, the handler query parameter maps to methods in your PageModel.
- The naming convention follows this pattern: `On{HttpMethod}{HandlerName}()`.
  - `handler=Hello` with a GET request calls `OnGetHello()`
  - `handler=Submit` with a POST request calls `OnPostSubmit()`
  - **No** handler parameter with GET calls `OnGet()`
- This convention keeps server-side code organized, giving htmx clear endpoints to call.

## The Request-Response Cycle with htmx

- htmx works like a normal browser request but **without** a full-page reload.
- Here is how a typical request-response cycle flows:
  1. User interaction (clicks a button, types in an input, submits a form)
  2. htmx sends an AJAX request to the specified endpoint
  3. The Razor Page handler processes the request and returns partial HTML
  4. htmx updates the target element with the returned HTML
- You can build dynamic experiences, keeping your app logic centralized in PageModel classes.
- The server remains in control, and the client handles presentation.

## Examining How Partial Updates Work

- In traditional AJAX you manually manipulate the DOM.
- htmx automatically swaps the response into a specified target.
- Two attributes control this behavior:
  - `hx-target` determines which element will be updated
  - `hx-swap` decides how the response is inserted
- `hx-swap` accepts several values:
  - `innerHTML` (default): Replaces the target's inner content
  - `outerHTML`: Replaces the entire target element
  - `beforebegin`: Inserts before the target element
  - `afterbegin`: Inserts inside the target, before its first child
  - `beforeend`: Inserts inside the target, after its last child
  - `afterend`: Inserts after the target element
- Returning only relevant snippets from the server makes updates feel instant and keeps bandwidth usage low.
