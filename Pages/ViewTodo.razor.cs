using global::Microsoft.AspNetCore.Components;
using TodoListMauiApp.Models;

namespace TodoListMauiApp.Pages
{
    public partial class ViewTodo
    {
        [Parameter]
        public string Id { get; set; }
        private TodoModel todo;

        protected override async Task OnInitializedAsync()
        {

            if (int.TryParse(Id, out int todoId))
            {

                todo = await TodoService.GetTodoByIdAsync(todoId);
            }
        }
    }
}