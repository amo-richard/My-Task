using Microsoft.AspNetCore.Components;
using My_Task_.Client.Shared;
using My_Task_.Shared;
using System.Net.Http.Json;


namespace My_Task_.Client.Pages
{
    public partial class Index
    {
        private bool showDetails = false;
        private void CloseDetails()
        {
            showDetails = false;
        }

        private string? DialogName { get; set; }
        private string? DialogDescription { get; set; }

        private char? FirstLetter { get; set; }

        [Inject] public HttpClient Http { get; set; }

        IList<TaskItem> dbItems;

        string? error = "";

        List<string>? FiltedTaskName = new List<string>();

        List<string>? TaskName = new List<string>();

        string message = "";
        
        public void OnInitialized()
        {
            createTask.Update += ReRender;
        }
        public void Dispose()
        {
            createTask.Update -= ReRender;
        }
        public void ReRender()
        {
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                string requestUri = "api/TaskItems";

                dbItems = await Http.GetFromJsonAsync<IList<TaskItem>>(requestUri);
            }
            catch (Exception)
            {
                error = "an error occured";
            }
            if (dbItems != null)
            {
                foreach (TaskItem item in dbItems)
                {
                    if (!string.IsNullOrEmpty(item.TaskItemCategory))
                    {
                        TaskName.Add(item.TaskItemCategory);
                    }
                }
            }
            FiltedTaskName = TaskName.Distinct().ToList();

            if (createTask.NewContent != null)
            {
                foreach (TaskItem Item in createTask.NewContent)
                {
                    dbItems.Add(Item);
                }
            }
        }
    }
}
