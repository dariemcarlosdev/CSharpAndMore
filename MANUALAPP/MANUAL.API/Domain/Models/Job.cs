using System.ComponentModel.DataAnnotations;

namespace MANUAL.API.Models
{
    public class Job
    {   
        [Key]
        public int JobId { get; set; }
        [Required]
        public string JobName { get; set; }
        [MaxLength(50)]
        public string JobDescription { get; set; }

        public Job()
        {

        }

        public Job(string jobName, string jobDescription)
        {
            this.JobName = jobName;
            this.JobDescription = JobDescription;
        }

    }
}