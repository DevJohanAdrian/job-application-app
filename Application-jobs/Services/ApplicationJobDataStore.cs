using Application_jobs.Models;

namespace Application_jobs.Services
{
    public class ApplicationJobDataStore
    {
        public List<ApplicationJob> Applications { get; set; }
        public ApplicationJobDataStore Data { get; } = new ApplicationJobDataStore();
        public ApplicationJobDataStore() {
            Applications = new List<ApplicationJob>() {
                new ApplicationJob(){
                    Id = 1,
                    CreationDate = DateTime.Now,
                    JobDescription = "Java, c# and javascript",
                    CompanyId = 1,
                    SkillRequest ="Java, c# and javascript",
                    Interviews = 3,
                    StatusId = 1,
                    TecnicTest = true,
                    LastUpdateOn = DateTime.Now,
                }
            };
        }
    }
}
