using global::Microsoft.AspNetCore.Components;
using TodoListMauiApp.Models;

namespace TodoListMauiApp.Pages
{
    public partial class EditTodo
    {
        // Déclaration d'un paramètre de page pour l'identifiant de la tâche
        [Parameter]
        public string Id { get; set; }

        // Déclaration d'une variable privée pour stocker la tâche à éditer
        private TodoModel todo;
        // Méthode appelée lors de l'initialisation de la page
        protected override async Task OnInitializedAsync()
        {
            // Convertir la chaîne Id en entier si nécessaire
            if (int.TryParse(Id, out int todoId))
            {
                // Récupérer la tâche à éditer à partir du service TodoService
                todo = await TodoService.GetTodoByIdAsync(todoId);
            }
        }

        // Méthode appelée lors de la soumission réussie du formulaire
        private async Task HandleValidSubmit()
        {
            // Mettre à jour la tâche à l'aide du service TodoService
            await TodoService.UpdateTodoAsync(todo);
            // Naviguer vers la liste des tâches après la mise à jour
            Navigation.NavigateTo("/fetchdata");
        }
    }
}