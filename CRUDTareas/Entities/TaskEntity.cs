namespace CRUDTareas.Entities
{
    public class TaskEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class TaskResult
    {
        public bool status { get; set; }
        public TaskEntity data { get; set; }
        public string message { get; set; }
    }
}