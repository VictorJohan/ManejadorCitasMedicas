using ManejadorCitasMedicas_MCM_.Componentes;
using MudBlazor;

namespace ManejadorCitasMedicas_MCM_.Utils
{
    public class ResponseDialog
    {
        private IDialogService DialogService { get; set; }

        public ResponseDialog(IDialogService dialogService)
        {
            this.DialogService = dialogService;
        }

        public async Task<bool> ShowQuestion(string pregunta, string titulo = "Alerta")
        {
            var parameters = new DialogParameters { ["Titulo"] = titulo, ["Pregunta"]= pregunta };

            var dialog = DialogService.Show<SiNoDialog>("",parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
               return true;
            }

            return false;
        }
    }
}
