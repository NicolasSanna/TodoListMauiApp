using TodoListMauiApp.Models;

namespace TodoListMauiApp.Pages
{
    public partial class FetchData
    {
        // Déclaration d'une variable pour stocker la liste de tâches
        private List<TodoModel> todos;
        // Méthode appelée lors de l'initialisation de la page
        protected override async Task OnInitializedAsync()
        {
            // Récupération de la liste de tâches à partir du service TodoService
            todos = await TodoService.GetAllTodosAsync();
        }

        // Méthode pour supprimer une tâche
        private async Task DeleteTodoAsync(int todoId)
        {
            // Récupération de la tâche à supprimer à partir de l'ID
            var todoToDelete = await TodoService.GetTodoByIdAsync(todoId);
            // Vérification si la tâche à supprimer existe
            if (todoToDelete != null)
            {
                // Appel du service pour supprimer la tâche
                await TodoService.DeleteTodoAsync(todoToDelete);
                // Actualisation de la liste de tâches après la suppression
                todos = await TodoService.GetAllTodosAsync();
            }
        }

        // Méthode pour rediriger vers la page de modification d'une tâche
        private void UpdateTodoAsync(int todoId)
        {
            // Navigation vers la page d'édition avec l'ID de la tâche
            Navigation.NavigateTo($"/todo/edit/{todoId}");
        // Autres opérations si nécessaires
        }

        // Méthode pour rediriger vers la page de visualisation d'une tâche
        private void ViewTodoAsync(int todoId)
        {
            try
            {
                // Navigation vers la page de visualisation avec l'ID de la tâche
                Navigation.NavigateTo($"/todo/{todoId}");
            // Autres opérations si nécessaires
            }
            catch (Exception ex)
            {
                // Gestion des erreurs potentielles
                Console.WriteLine($"An error occurred: {ex.Message}");
            // Autres actions de gestion d'erreur si nécessaires
            }
        }
    }
}