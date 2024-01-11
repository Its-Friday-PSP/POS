using API.DTOs;
using API.Model;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("taxes")]
    public class TaxController : Controller
    {
        private readonly ITaxService _taxService;
        private readonly IMapper _mapper;
        public TaxController(ITaxService taxService, IMapper mapper)
        {
            _taxService = taxService;
            _mapper = mapper;   
        }

        [HttpGet("{taxId}")]
        public ActionResult<TaxDTO> GetTax(Guid taxId)
        {
            var tax = _taxService.GetTax(taxId);

            if(tax == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<TaxDTO>(tax);

            return Ok(response);
        }

        [HttpGet]
        public ActionResult<TaxDTO> GetTax()
        {
            var taxes = _taxService.GetAllTaxes();
            var response = _mapper.Map<IEnumerable<TaxDTO>>(taxes);

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<TaxDTO> CreateTax([FromBody] TaxDTO taxDto)
        {
            var tax = _mapper.Map<Tax>(taxDto);

            var response = _taxService.CreateTax(tax);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPut("delete/{taxId}")]
        public ActionResult<TaxDTO> DeleteTax([FromRoute] Guid taxId)
        {
            return _taxService.DeleteTax(taxId) ? Ok() : NotFound();
        }

        [HttpPut("update/{taxId}")]
        public ActionResult<TaxDTO> UpdateTax([FromRoute] Guid taxId, [FromBody] TaxDTO taxDto)
        {
            var tax = _mapper.Map<Tax>(taxDto);

            var response = _taxService.UpdateTax(taxId, tax);

            return response == null ? NotFound() : Ok(response);
        }
    }
}
