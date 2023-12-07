namespace TodoListMauiApp.Pages
{
    public partial class Counter
    {
        // Déclaration du bloc de code C# associé à cette page Razor.
        private int currentCount = 0;
        // Déclaration d'une variable privée pour stocker le compteur.
        private void IncrementCount()
        {
            // Méthode appelée lors du clic sur le bouton.
            // Incrémente la valeur de currentCount.
            currentCount++;
        }
    }
}