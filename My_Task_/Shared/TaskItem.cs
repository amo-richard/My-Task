namespace My_Task_.Shared
{
    public class TaskItem
    {
        public int? TaskItemId { get; set; }
        public string? TaskItemCategory { get; set; }
        public string? TaskItemParent { get; set; }
        public string? TaskItemName { get; set; }
        public string? TaskItemDescription { get; set; }
        public string? TaskItemStart { get; set; }
        public string? TaskItemEnd { get; set; }
        public string? TaskItemStartTime { get; set; }
        public string? TaskItemEndTime { get; set; }
        public int TaskItemStatus { get; set; } = 1;
        public bool NoSubTask { get; set; } = false;
        public bool IsCompeted { get; set; } = false;
        public bool TaskItemRepeat { get; set; } = false;
    }
}
