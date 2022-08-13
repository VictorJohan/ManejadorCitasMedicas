using Microsoft.JSInterop;

namespace ManejadorCitasMedicas_MCM_.Utils
{
    public static class IJSExtensions
    {
        public static void Animar403(this IJSRuntime js)
        {
            js.InvokeVoidAsync("animar403");
        }

        public static void SetTitulo(this IJSRuntime js, string titulo)
        {
            js.InvokeVoidAsync("setTitulo", titulo);
        }

    }
}
