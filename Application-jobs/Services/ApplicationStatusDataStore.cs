using Application_jobs.Models;

namespace Application_jobs.Services
{
    public class ApplicationStatusDataStore
    {
        public List<ApplicationStatus> Status { get; set; }

        public ApplicationStatusDataStore Data { get; } = new ApplicationStatusDataStore();

        public ApplicationStatusDataStore() {
            Status = new List<ApplicationStatus>(){
                 new ApplicationStatus(){
                   Id = 1,
                   Description = "Sent",
                   Code= "C01"
                 },
                 new ApplicationStatus()
                 {
                     Id = 2,
                     Description="Interview",
                     Code= "C02"
                 },
                    new ApplicationStatus()
                 {
                     Id = 3,
                     Description="Call",
                     Code= "C03"
                 },
                    new ApplicationStatus()
                 {
                     Id = 4,
                     Description="Not Chosen",
                     Code= "C04"
                 }

            };
        }
    }
}

