using API.Models.Commands;
using API.Models.Entity;
using API.Models.Errors.Response;
using API.Models.Requests.Shift;
using API.Models.Response;
using API.Utility.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер для взаимодействия с сменами сотрудников
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        /// <summary>
        /// Экземпляр сендера от MediatR
        /// </summary>
        private readonly ISender _sender;
        /// <summary>
        /// Конструктор для контроллера взаимодействия с сменами сотрудников
        /// </summary>
        /// <param name="sender">Экземпляр сендера от MediatR</param>
        public ShiftController(ISender sender)
        {
            _sender = sender;
        }
        /// <summary>
        /// Метод-эндпоинт для начала смены
        /// </summary>
        /// <param name="request">Данные-запрос для начала смены</param>
        /// <returns>Ok или BadRequest при ошибке</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EndpointDescription(ContextConstants.StartShiftDescription)]
        [EndpointSummary(ContextConstants.StartShiftSummary)]
        public async Task<ActionResult> StartShift(StartShiftRequest request)
        {
            var command = new StartShiftCommand(request.Id,
                request.Date,
                request.Time);
            var response = await _sender.Send(command);
            return response.Match<ActionResult>(Ok,
                fail => BadRequest(fail.MapToResponse()));
        }
        /// <summary>
        /// Метод-эндпоинт для конца смены
        /// </summary>
        /// <param name="request">Данные-запрос для конца смены</param>
        /// <returns>Ok или BadRequest при ошибке</returns>
        [HttpPut]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EndpointDescription(ContextConstants.EndShiftDescription)]
        [EndpointSummary(ContextConstants.EndShiftSummary)]
        public async Task<ActionResult> EndShift(EndShiftRequest request)
        {
            var command = new EndShiftCommand(request.Id,
                request.Time);
            var response = await _sender.Send(command);
            return response.Match<ActionResult>(Ok,
                fail => BadRequest(fail.MapToResponse()));
        }
    }
}
