using API.Models.Commands;
using API.Models.Entity;
using API.Models.Errors.Base;
using API.Models.Errors.Response;
using API.Models.Queries;
using API.Models.Requests.Employee;
using API.Models.Response;
using API.Utility.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер для взаимодействия с сотрудниками
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Экземпляр сендера от MediatR
        /// </summary>
        private readonly ISender _sender;
        /// <summary>
        /// Конструктор контроллера взаимодействия с сотрудниками
        /// </summary>
        /// <param name="sender">Экземпляр сендера от MediatR</param>
        public EmployeeController(ISender sender)
        {
            _sender = sender;
        }
        /// <summary>
        /// Метод-эндпоинт для добавления сотрудника
        /// </summary>
        /// <param name="request">Данные-запрос для добавления сотрудника</param>
        /// <returns>Добавленный пользователь в виде модели ответа или BadRequest при ошибке</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        [EndpointDescription(ContextConstants.AddEmployeeDescription)]
        [EndpointSummary(ContextConstants.AddEmployeeSummary)]
        public async Task<ActionResult<EmployeeResponse>> Add(AddEmployeeRequest request)
        {
            var command = new AddEmployeeCommand(
                request.LastName,
                request.FirstName,
                request.MiddleName,
                request.Post
                );
            var response = await _sender.Send(command);
            return response.Match<ActionResult<EmployeeResponse>>(() => Ok(response.Value),
            fail => BadRequest(fail.MapToResponse()));
        }
        /// <summary>
        /// Метод-эндпоинт для изменение данных сотрудника
        /// </summary>
        /// <param name="request">Данные-запрос для изменение данных сотрудника</param>
        /// <returns>Изменённый пользователь в виде модели ответа или BadRequest при ошибке</returns>
        [HttpPut]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        [EndpointDescription(ContextConstants.UpdateEmployeeDescription)]
        [EndpointSummary(ContextConstants.UpdateEmployeeSummary)]
        public async Task<ActionResult<EmployeeResponse>> Update(UpdateEmployeeRequest request)
        {
            var command = new UpdateEmployeeCommand(
                request.Id,
                request.LastName,
                request.FirstName,
                request.MiddleName,
                request.Post
                );
            var response = await _sender.Send(command);
            return response.Match<ActionResult<EmployeeResponse>>(() => Ok(response.Value),
                fail => BadRequest(fail.MapToResponse()));
        }
        /// <summary>
        /// Метод-эндпоинт для удаления данных сотрудника
        /// </summary>
        /// <param name="request">Данные-запрос для удаления данных сотрудника</param>
        /// <returns>Ok или BadRequest при ошибке</returns>
        [HttpDelete]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EndpointDescription(ContextConstants.DeleteEmployeeDescription)]
        [EndpointSummary(ContextConstants.DeleteEmployeeSummary)]
        public async Task<ActionResult> Delete(DeleteEmployeeRequest request)
        {
            var command = new DeleteEmployeeCommand(request.Id);
            var response = await _sender.Send(command);
            return response.Match<ActionResult>(Ok,
                fail => BadRequest(fail.MapToResponse()));
        }
        /// <summary>
        /// Метод-эндпоинт для получения данных о сотрудниках с статистикой смен
        /// </summary>
        /// <param name="request">Данные-запрос для получения данных о сотрудниках, в реалиях запроса опциональны</param>
        /// <returns>Коллекция пользователей с статистикой или BadRequest при ошибке</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ICollection<EmployeeWithStatsResponse>), StatusCodes.Status200OK)]
        [EndpointDescription(ContextConstants.GetEmployeesDescription)]
        [EndpointSummary(ContextConstants.GetEmployeesSummary)]
        public async Task<ActionResult<ICollection<EmployeeWithStatsResponse>>> GetEmployees([FromQuery]GetEmployeesRequest request)
        {
            var command = new GetEmployeesQuery(request.PostEnum);
            var response = await _sender.Send(command);
            return response.Match<ActionResult<ICollection<EmployeeWithStatsResponse>>>(() => Ok(response.Value),
                fail => BadRequest(fail.MapToResponse()));
        }
        /// <summary>
        /// Метод-запрос для получения данных о должностях
        /// </summary>
        /// <returns>Список должностей</returns>
        [HttpGet("Posts")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ICollection<PostResponse>), StatusCodes.Status200OK)]
        [EndpointDescription(ContextConstants.GetPostsDescription)]
        [EndpointSummary(ContextConstants.GetEmployeesSummary)]
        public ActionResult<ICollection<PostResponse>> GetPosts()
        {
            return Ok(Enum.GetValues(typeof(PostEnum)).Cast<PostEnum>().Select(x => new PostResponse(x)));
        }
    }
}
