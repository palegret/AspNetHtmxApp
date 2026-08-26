((document, htmx) => {
  document.body.addEventListener('htmx:beforeRequest', (event) => {
    console.log('Request starting:', event.detail.pathInfo);
  });

  document.body.addEventListener('htmx:afterRequest', (event) => {
    console.log('Request complete:', event.detail.xhr.status);
  });

  document.body.addEventListener('htmx:responseError', (event) => {
    console.error('Request failed:', event.detail.xhr.status);
  });

  document.body.addEventListener('htmx:configRequest', (event) => {
    const token = document.querySelector('input[name="__RequestVerificationToken"]');
    token && event.detail.headers['RequestVerificationToken'] = token.value;
  });

  htmx.logAll();
})(window.document, window.htmx);
