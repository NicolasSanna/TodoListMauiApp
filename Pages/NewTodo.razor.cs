using TodoListMauiApp.Models;

namespace TodoListMauiApp.Pages
{
    public partial class NewTodo
    {
        // Déclaration d'une instance de TodoModel pour le nouveau todo
        private TodoModel newTodo = new TodoModel();
        // Déclaration d'une variable pour stocker le message d'erreur
        private string errorMessage = string.Empty;
        // Méthode appelée lors de la soumission valide du formulaire
        private async Task HandleValidSubmit()
        {
            // Vérification si les champs obligatoires sont vides ou blancs
            if (string.IsNullOrWhiteSpace(newTodo.Name) || string.IsNullOrWhiteSpace(newTodo.Description))
            {
                // Définition du message d'erreur si les champs sont vides
                errorMessage = "Name and Description are required.";
                return;
            }

            try
            {
                // Tentative d'ajouter le nouveau todo en utilisant le service TodoService
                await TodoService.AddTodoAsync(newTodo);
                // Redirection vers la liste des tâches après l'ajout réussi
                Navigation.NavigateTo("/fetchdata");
            }
            catch (Exception ex)
            {
                // En cas d'erreur lors de l'ajout du todo, définissez le message d'erreur approprié
                errorMessage = $"An error occurred: {ex.Message}";
            }
        }
    }
}