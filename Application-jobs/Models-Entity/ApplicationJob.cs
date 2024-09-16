namespace Application_jobs.Models
{
    public class ApplicationJob
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string JobDescription { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public string SkillRequest { get; set; } = string.Empty;
        public int? Interviews { get; set; }
        
        public bool TecnicTest { get; set; }
        public string? Recruter { get; set; } 
        public DateTime LastUpdateOn { get; set; }
        // clave foranea
        public int StatusId { get; set; }
        public virtual ApplicationStatus StatusRefence { get; set; }
        public virtual Company CompanyRefence { get; set; }

    }
}
