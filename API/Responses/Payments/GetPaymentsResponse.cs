using API.DTOs;

namespace API.Responses.Payments
{
    public class GetPaymentsResponse
    {
        public List<PaymentDTO> Payments { get; set; }

        public GetPaymentsResponse(List<PaymentDTO> payments)
        {
            Payments = payments;
        }
    }
}
