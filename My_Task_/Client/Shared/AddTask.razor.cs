using Microsoft.AspNetCore.Components;
using My_Task_.Shared;
using System.Net.Http.Json;

namespace My_Task_.Client.Shared
{
    partial class AddTask
    {
        [Inject] public HttpClient Http { get; set; }
        [Inject] private NavigationManager navigation { get; set; }
        IList<TaskItem> NewData = new List<TaskItem>();

        public bool ClickState = false;
        bool TaskType = false;
        string ClickClass = "";
        string TimeClass = "";
        string error = "Save";
        string Shrink = "";
        string ShowParent = "";
        string HideSubtask = "";
        string HideCategory = "";
        string ShrinkHeight = "";
        string ActivateSubTask = "";

        protected override void OnInitialized()
        {   
            UpdateShow.Onchange += StateHasChanged;
            createTask.Update += StateHasChanged;

            


        }

        public void Dispose()
        {
            UpdateShow.Onchange -= StateHasChanged;
            createTask.Update-= StateHasChanged;
        }

        public async void UpdateNewData()
        {
            string? DateStart = StartDate.ToString();
            string? DateEnd = EndDate.ToString();
            string? TaskStartTime = TaskTimeStart.ToString();
            string? TaskEndTime = TaskTimeEnd.ToString();

            if (!string.IsNullOrWhiteSpace(TaskName) && !string.IsNullOrWhiteSpace(TaskCat) && !string.IsNullOrWhiteSpace(
                TaskDescription))
            {
                createTask.AddToNewContent(new TaskItem
                {
                    TaskItemName = TaskName,
                    TaskItemCategory = TaskCat,
                    TaskItemDescription = TaskDescription,
                    TaskItemStart = DateStart,
                    TaskItemEnd = DateEnd,
                    TaskItemParent = TaskP
                });

                TaskType = true;
                ShowParent = TaskType ? "show-parent" : "";
                HideCategory = TaskType ? "hide-category" : "";
                HideSubtask = TaskType ? "hide-category" : "";
                ShrinkHeight = TaskType ? "" : "shrink-height";
                TimeClass = TaskType ? "" : "add-time";
                Shrink = TaskType ? "" : "shrink";

                TaskItem CurrentData = new TaskItem
                {
                    TaskItemName = TaskName,
                    TaskItemCategory = TaskCat,
                    TaskItemDescription = TaskDescription,
                    TaskItemStart = DateStart,
                    TaskItemEnd = DateEnd,
                    TaskItemParent = TaskP
                };

                TaskP = createTask.NewContent[0].TaskItemName;
                TaskName = string.Empty;
                TaskCat = createTask.NewContent[0].TaskItemCategory;
                TaskDescription = string.Empty;
                DateStart = null;
                DateEnd = null;
                string requestUri = "api/TaskItems";

                try
                {
                    var results = await Http.PostAsJsonAsync(requestUri, CurrentData);

                    if (results.IsSuccessStatusCode)
                    {
                       
                    }
                }
                catch (Exception er)
                {
                    error = er.ToString();
                }

            }
        }

        public void ChangeClick()
        {
            ClickState = ClickState ? !ClickState : !ClickState;
            ClickClass = ClickState ? "click" : ""; 
            TimeClass = ClickState ? "add-time" : ""; 
            Shrink = ClickState ? "shrink" : "";
            ShrinkHeight = ClickState ? "shrink-height" : ""; 
            ActivateSubTask = ClickState ? "subtast-activated" : ""; 
        }


       /* public async void UpdateDataBase()
        {
            
            if(NewData == null)
            {
                createTask.AddToNewContent(new TaskItem { TaskItemName = TaskName, TaskItemCategory = TaskCat, TaskItemDescription = TaskDescrition, TaskItemStart = DateStart, TaskItemEnd = DateEnd });
            }

            else if (NewData != null)
            {
                try
                {
                    string requestUri = "api/TaskItems";
                        foreach(TaskItem Item in NewData)
                    {
                        var responce = await Http.PostAsJsonAsync(requestUri, Item);

                        if (responce.IsSuccessStatusCode)
                        {
                            error = "success";
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = ex.ToString();
                }
            }
            else
            {
                error = "is empty";
            }
            createTask.UpdateData();
        }*/
    }
}
