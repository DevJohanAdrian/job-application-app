using Application_jobs.DTOS;
using Application_jobs.Models;
using Application_jobs.Services ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application_jobs.Controllers
{
    [Route("api/[controller]")]
    public class CompayController : ControllerBase // sin soporte a view
    {
      
        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompanies()
        {
            return Ok(CompanyDataStore.Data.Companies);
        }

        
        [HttpPost]
        public ActionResult<CompanyDTO> CreateCompany([FromBody] CompanyDTO company)
        {
            var companyId = CompanyDataStore.Data.Companies.Max(x => x.Id);

            var newCompany = new Company() {
                Id = companyId + 1,
                CompanyName = company.CompanyName,
                Code = company.Code,

            };

            //return CreatedAtAction(nameof(GetMandril),
            //    new { mandrilId = mandrilNuevo.Id },
            //    mandrilNuevo
            //);

            CompanyDataStore.Data.Companies.Add(newCompany);
            return  StatusCode(201, newCompany); ;
        }


        [HttpPut("{companyId}")]
        public ActionResult<CompanyDTO> PutCompany([FromRoute] int companyId, [FromBody] CompanyDTO company)
        {
            var companyToEdit = CompanyDataStore.Data.Companies.FirstOrDefault(company => company.Id == companyId);

            if (companyToEdit == null)
            {
                return NotFound("Company not found.");
            };

            companyToEdit.CompanyName = company.CompanyName;
            companyToEdit.Code = company.Code;
            return Ok();
        }

        [HttpDelete("{companyId}")]
        public ActionResult<CompanyDTO> DeleteCompanyById(int companyId)
        {
            var company = CompanyDataStore.Data.Companies.FirstOrDefault(company => company.Id == companyId);

            if (company == null)
            {
                return NotFound("Company not found.");
            }

            CompanyDataStore.Data.Companies.Remove(company);

            return Ok();
        }



    }
}
