using API.Model;

namespace API.Responses.Order
{
    public class ApplyDiscountResponse
    {
        public Discount? ProductDiscount { get; set; }
        public Discount? ServiceDiscount { get; set; }
        public ApplyDiscountResponse(Discount discount)
        {
            if(discount.OrderType == DTOs.OrderTypeDTO.PRODUCT)
            {
                ProductDiscount = discount;
            }
            else
            {
                ServiceDiscount = discount;
            }
        }
    }
}
