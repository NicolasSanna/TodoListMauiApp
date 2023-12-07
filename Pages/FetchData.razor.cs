using TodoListMauiApp.Models;

namespace TodoListMauiApp.Pages
{
    public partial class FetchData
    {
        // D�claration d'une variable pour stocker la liste de t�ches
        private List<TodoModel> todos;
        // M�thode appel�e lors de l'initialisation de la page
        protected override async Task OnInitializedAsync()
        {
            // R�cup�ration de la liste de t�ches � partir du service TodoService
            todos = await TodoService.GetAllTodosAsync();
        }

        // M�thode pour supprimer une t�che
        private async Task DeleteTodoAsync(int todoId)
        {
            // R�cup�ration de la t�che � supprimer � partir de l'ID
            var todoToDelete = await TodoService.GetTodoByIdAsync(todoId);
            // V�rification si la t�che � supprimer existe
            if (todoToDelete != null)
            {
                // Appel du service pour supprimer la t�che
                await TodoService.DeleteTodoAsync(todoToDelete);
                // Actualisation de la liste de t�ches apr�s la suppression
                todos = await TodoService.GetAllTodosAsync();
            }
        }

        // M�thode pour rediriger vers la page de modification d'une t�che
        private void UpdateTodoAsync(int todoId)
        {
            // Navigation vers la page d'�dition avec l'ID de la t�che
            Navigation.NavigateTo($"/todo/edit/{todoId}");
        // Autres op�rations si n�cessaires
        }

        // M�thode pour rediriger vers la page de visualisation d'une t�che
        private void ViewTodoAsync(int todoId)
        {
            try
            {
                // Navigation vers la page de visualisation avec l'ID de la t�che
                Navigation.NavigateTo($"/todo/{todoId}");
            // Autres op�rations si n�cessaires
            }
            catch (Exception ex)
            {
                // Gestion des erreurs potentielles
                Console.WriteLine($"An error occurred: {ex.Message}");
            // Autres actions de gestion d'erreur si n�cessaires
            }
        }
    }
}