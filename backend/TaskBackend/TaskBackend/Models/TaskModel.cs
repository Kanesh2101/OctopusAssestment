using System.ComponentModel.DataAnnotations;

namespace TaskBackend.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        public string description { get; set; }
        public string status { get; set; }

        public string assignedBy { get; set; }
        public string assignedTo { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public string updatedAt { get; set; }
        public string updatedBy { get; set; }

        public string createdAt { get; set; }

        public string createdBy { get; set; }


    }
}
