using TodoListMauiApp.Models;

namespace TodoListMauiApp.Pages
{
    public partial class NewTodo
    {
        // D�claration d'une instance de TodoModel pour le nouveau todo
        private TodoModel newTodo = new TodoModel();
        // D�claration d'une variable pour stocker le message d'erreur
        private string errorMessage = string.Empty;
        // M�thode appel�e lors de la soumission valide du formulaire
        private async Task HandleValidSubmit()
        {
            // V�rification si les champs obligatoires sont vides ou blancs
            if (string.IsNullOrWhiteSpace(newTodo.Name) || string.IsNullOrWhiteSpace(newTodo.Description))
            {
                // D�finition du message d'erreur si les champs sont vides
                errorMessage = "Name and Description are required.";
                return;
            }

            try
            {
                // Tentative d'ajouter le nouveau todo en utilisant le service TodoService
                await TodoService.AddTodoAsync(newTodo);
                // Redirection vers la liste des t�ches apr�s l'ajout r�ussi
                Navigation.NavigateTo("/fetchdata");
            }
            catch (Exception ex)
            {
                // En cas d'erreur lors de l'ajout du todo, d�finissez le message d'erreur appropri�
                errorMessage = $"An error occurred: {ex.Message}";
            }
        }
    }
}