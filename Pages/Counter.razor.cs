namespace TodoListMauiApp.Pages
{
    public partial class Counter
    {
        // D�claration du bloc de code C# associ� � cette page Razor.
        private int currentCount = 0;
        // D�claration d'une variable priv�e pour stocker le compteur.
        private void IncrementCount()
        {
            // M�thode appel�e lors du clic sur le bouton.
            // Incr�mente la valeur de currentCount.
            currentCount++;
        }
    }
}