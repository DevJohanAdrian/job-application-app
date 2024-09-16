namespace Application_jobs.Models
{
    public class ApplicationStatus
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        // solo para relacion de 1 a muchos
        public virtual ICollection<ApplicationJob> ApplicationReference {get; set;}
    }
}
