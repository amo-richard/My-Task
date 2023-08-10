
using My_Task_.Shared;
namespace My_Task_.Client.Shared;

public class CreateTask
{

    public List<TaskItem>? NewContent = new List<TaskItem>();
    public event Action? Update;
    private void UpdateData() => Update();

    public void AddToNewContent(TaskItem NewItem)
    {
        NewContent.Add(NewItem);
        UpdateData();
    }
}