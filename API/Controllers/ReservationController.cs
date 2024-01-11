using API.Exceptions;
using API.Model;
using API.Requests.Reservation;
using API.Responses.Reservation;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GetReservationsRespone>> GetAllReservationTimes()
        {
            return Ok(_reservationService.GetAllFreeReservations());
        }

        [HttpGet("services/{serviceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<GetReservationsRespone>> GetFreeReservationTimesPerService([FromRoute] GetServiceReservationTimesRequest request)
        {
            var times = _reservationService.GetFreeReservationsFromService(request.ServiceId);
            return times == null ? NotFound() : Ok(times);
        }

        [HttpGet("employees/{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<GetReservationsRespone>> GetFreeReservationTimesPerEmployee([FromRoute] GetEmployeeReservationTimesRequest request)
        {
            var times = _reservationService.GetFreeReservationsFromEmployee(request.EmployeeId);
            return times == null ? NotFound() : Ok(times);
        }

        [HttpPost("services/{serviceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InsertReservationToServiceResponse> InsertReservationToService([FromRoute] InsertReservationToServiceRequest request, Guid serviceId)
        {
            var service = _reservationService.InsertReservationToService(_mapper.Map<ServiceTimeSlots>(request.TimeSlots), serviceId);
            return service == null ? NotFound() : Ok(service);
        }

        [HttpPost("employees/{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InsertReservationToEmployeeResponse> InsertReservationToEmployee([FromRoute] InsertReservationToEmployeeRequest request, Guid employeeId)
        {
            var service = _reservationService.InsertReservationToEmployee(_mapper.Map<ServiceTimeSlots>(request.TimeSlots), employeeId);
            return service == null ? NotFound() : Ok(service);
        }

        [HttpPost("customer/{timeSlotId}/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult MakeReservation([FromRoute] AddCustomerToTheReservationRequest request)
        {
            try
            {
                _reservationService.MakeReservation(request.TimeSlotId, request.CustomerId);
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(((int)ex.StatusCode), ex.Message);
            }

            return Ok();
        }
    }
}
