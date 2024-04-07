using SQLite;
using TodoListMauiApp.Models;

namespace TodoListMauiApp.Services
{
    // Interface définissant les opérations possibles sur les tâches (todos)
    public interface ITodoService
    {
        Task<int> AddTodoAsync(TodoModel todoModel);
        Task<int> DeleteTodoAsync(TodoModel todoModel);
        Task<int> UpdateTodoAsync(TodoModel todoModel);
        Task<List<TodoModel>> GetAllTodosAsync();
        Task<TodoModel> GetTodoByIdAsync(int todoId);
    }

    // Implémentation concrète de l'interface ITodoService
    public class TodoService : ITodoService
    {
        // Connexion SQLite asynchrone utilisée pour interagir avec la base de données
        private readonly SQLiteAsyncConnection _dbConnection;

        // Constructeur qui initialise la connexion à la base de données et crée la table TodoModel si elle n'existe pas
        public TodoService()
        {
            _dbConnection = InitializeDatabase();
            _dbConnection.CreateTableAsync<TodoModel>().Wait();
        }

        // Méthode pour initialiser la connexion à la base de données SQLite
        private SQLiteAsyncConnection InitializeDatabase()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Todo.db");

            // Création et retour de la connexion SQLite
            return new SQLiteAsyncConnection(dbPath);
        }

        // Méthode pour ajouter une tâche (todo) à la base de données
        public async Task<int> AddTodoAsync(TodoModel todoModel)
        {
            return await _dbConnection.InsertAsync(todoModel);
        }

        // Méthode pour supprimer une tâche (todo) de la base de données
        public async Task<int> DeleteTodoAsync(TodoModel todoModel)
        {
            return await _dbConnection.DeleteAsync(todoModel);
        }

        // Méthode pour mettre à jour une tâche (todo) dans la base de données
        public async Task<int> UpdateTodoAsync(TodoModel todoModel)
        {
            return await _dbConnection.UpdateAsync(todoModel);
        }

        // Méthode pour obtenir toutes les tâches (todos) de la base de données
        public async Task<List<TodoModel>> GetAllTodosAsync()
        {
            return await _dbConnection.Table<TodoModel>().ToListAsync();
        }

        // Méthode pour obtenir une tâche (todo) par son identifiant de la base de données
        public async Task<TodoModel> GetTodoByIdAsync(int todoId)
        {
            return await _dbConnection.FindAsync<TodoModel>(todoId);
        }
    }
}