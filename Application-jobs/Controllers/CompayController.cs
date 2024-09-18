using Application_jobs.DTOS;
using Application_jobs.Models;
using Application_jobs.Services ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application_jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompayController : ControllerBase // sin soporte a view
    {
        private readonly CompanyService _companyService;
        public CompayController(CompanyService companyService)
        {
            _companyService = companyService;  
        }

        [HttpGet]
        [Route("GetCompanies")]
        public async Task<ActionResult<List<CompanyDTO>>> GetCompanies() {
            var companies = await _companyService.GetCompanies();
            return Ok(companies);
        }


        [HttpPut]
        [Route("UpdateCompany")]
        public async Task<ActionResult<CompanyDTO>> UpdateCompanyById(CompanyDTO company) {
            var companyUpdated = await _companyService.UpdateCompanyById(company);
            return Ok(companyUpdated);
        }

        [HttpPost]
        [Route("SaveCompany")]
        public async Task<ActionResult<CompanyDTO>> SaveCompany(CompanyDTO company) {
            var companySaved = await _companyService.SaveCompany(company);
            return Ok(companySaved);
        }



        // old version
        //[HttpGet]
        //[Route("GetCompanies")]
        //public ActionResult<IEnumerable<CompanyDTO>> GetCompanies()
        //{
        //    return Ok(CompanyDataStore.Data.Companies);
        //}


        //[HttpPost]
        //public ActionResult<CompanyDTO> CreateCompany([FromBody] CompanyDTO company)
        //{
        //    var companyId = CompanyDataStore.Data.Companies.Max(x => x.Id);

        //    var newCompany = new Company() {
        //        Id = companyId + 1,
        //        CompanyName = company.CompanyName,
        //        Code = company.Code,

        //    };

        //    //return CreatedAtAction(nameof(GetMandril),
        //    //    new { mandrilId = mandrilNuevo.Id },
        //    //    mandrilNuevo
        //    //);

        //    CompanyDataStore.Data.Companies.Add(newCompany);
        //    return  StatusCode(201, newCompany); ;
        //}


        //[HttpPut("{companyId}")]
        //public ActionResult<CompanyDTO> PutCompany([FromRoute] int companyId, [FromBody] CompanyDTO company)
        //{
        //    var companyToEdit = CompanyDataStore.Data.Companies.FirstOrDefault(company => company.Id == companyId);

        //    if (companyToEdit == null)
        //    {
        //        return NotFound("Company not found.");
        //    };

        //    companyToEdit.CompanyName = company.CompanyName;
        //    companyToEdit.Code = company.Code;
        //    return Ok();
        //}

        //[HttpDelete("{companyId}")]
        //public ActionResult<CompanyDTO> DeleteCompanyById(int companyId)
        //{
        //    var company = CompanyDataStore.Data.Companies.FirstOrDefault(company => company.Id == companyId);

        //    if (company == null)
        //    {
        //        return NotFound("Company not found.");
        //    }

        //    CompanyDataStore.Data.Companies.Remove(company);

        //    return Ok();
        //}



    }
}
