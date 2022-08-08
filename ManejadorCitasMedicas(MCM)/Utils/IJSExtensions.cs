using Microsoft.JSInterop;

namespace ManejadorCitasMedicas_MCM_.Utils
{
    public static class IJSExtensions
    {
        public static void Animar403(this IJSRuntime js)
        {
            js.InvokeVoidAsync("animar403");
        }
    }
}
