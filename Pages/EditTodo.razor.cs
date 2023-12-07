using global::Microsoft.AspNetCore.Components;
using TodoListMauiApp.Models;

namespace TodoListMauiApp.Pages
{
    public partial class EditTodo
    {
        // D�claration d'un param�tre de page pour l'identifiant de la t�che
        [Parameter]
        public string Id { get; set; }

        // D�claration d'une variable priv�e pour stocker la t�che � �diter
        private TodoModel todo;
        // M�thode appel�e lors de l'initialisation de la page
        protected override async Task OnInitializedAsync()
        {
            // Convertir la cha�ne Id en entier si n�cessaire
            if (int.TryParse(Id, out int todoId))
            {
                // R�cup�rer la t�che � �diter � partir du service TodoService
                todo = await TodoService.GetTodoByIdAsync(todoId);
            }
        }

        // M�thode appel�e lors de la soumission r�ussie du formulaire
        private async Task HandleValidSubmit()
        {
            // Mettre � jour la t�che � l'aide du service TodoService
            await TodoService.UpdateTodoAsync(todo);
            // Naviguer vers la liste des t�ches apr�s la mise � jour
            Navigation.NavigateTo("/fetchdata");
        }
    }
}