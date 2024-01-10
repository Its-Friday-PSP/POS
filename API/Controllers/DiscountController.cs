using API.DTOs;
using API.Model;
using API.Responses.Order;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("discounts")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet("{discountId}")]
        public ActionResult<DiscountDTO> GetDiscount([FromRoute] string discountId)
        {
            var discount = _discountService.GetDiscount(discountId);

            return discount == null ? NotFound() : Ok(discount);
        }

        [HttpGet]
        public ActionResult<IEnumerable<DiscountDTO>> GetDiscounts()
        {
            var discounts = _discountService.GetDiscounts();
            var discountDTOs = _mapper.Map<IEnumerable<Discount>>(discounts);

            return Ok(discountDTOs);
        }

        [HttpPost]
        public ActionResult<DiscountDTO> CreateDiscount([FromBody] DiscountDTO discountDTO)
        {
            var discount = _mapper.Map<Discount>(discountDTO);
            var newDiscount = _discountService.CreateDiscount(discount);

            return newDiscount == null ? NotFound() : Ok(newDiscount);
        }

        [HttpPut("{discountId}")]
        public IActionResult UpdateDiscount([FromRoute] string discountId, DiscountDTO discountDTO)
        {
            var discount = _mapper.Map<Discount>(discountDTO);
            bool success = _discountService.UpdateDiscount(discountId, discount);

            return success ? Ok() : NotFound();
        }

        [HttpGet("checkDiscount/{customerId}/{discountId}")]
        public ActionResult<ApplyDiscountResponse> CheckDiscount([FromRoute] Guid customerId, [FromRoute] string discountId)
        {
            var discount = _discountService.CheckDiscount(customerId, discountId);

            return discount == null ? NotFound() : Ok(new ApplyDiscountResponse(discount));
        }

    }
}
