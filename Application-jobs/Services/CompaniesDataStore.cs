using Application_jobs.Models;

namespace Application_jobs.Services
{
    public class CompanyDataStore
    {
        public List<Company> Companies { get; set; }
        public static CompanyDataStore Data { get; } = new CompanyDataStore();

        public CompanyDataStore() { 
            Companies = new List<Company>() { 
                new Company()
                {
                    Id = 1,
                    CompanyName = "Test1",
                    Code= "C01"
                },
                    new Company()
                {
                    Id = 2,
                    CompanyName = "Test2",
                    Code= "C02"
                },
                        new Company()
                {
                    Id = 3,
                    CompanyName = "Test3",
                    Code= "C03"
                }
            };
        }
    }
}
