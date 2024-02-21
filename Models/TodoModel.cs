using System.ComponentModel.DataAnnotations;
using SQLite;

namespace TodoListMauiApp.Models
{
    public class TodoModel
    {
        // L'attribut [PrimaryKey] indique à SQLite que la propriété est la clé primaire de la table.
        // L'attribut [AutoIncrement] permet à SQLite de générer automatiquement des valeurs uniques pour cette clé primaire.
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // L'attribut [Required] indique que la propriété est obligatoire et ne peut pas être null.
        // Cela est souvent utilisé en conjonction avec des frameworks de validation tels que DataAnnotations.
        //[Required(ErrorMessage = "Le nom est obligatoire")]
        public string Name { get; set; }

        // Une autre propriété pour stocker la description de la tâche.
        //[Required(ErrorMessage = "La description est obligatoire")]
        public string Description { get; set; }
    }
}