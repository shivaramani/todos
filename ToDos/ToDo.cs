using System;
namespace ToDos
{
    public class ToDo
    {
        public string Id { get; set; }
        public string Task { get; set; }
        public string TaskDescription { get; set; }
        public string User { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
