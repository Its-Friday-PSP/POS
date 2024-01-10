using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Order
{
    public class AddTipRequest
    {
        public TipDTO Tip { get; set; }
    }
}
