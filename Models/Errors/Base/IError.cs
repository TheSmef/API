using API.Models.Errors.Response;

namespace API.Models.Errors.Base
{
    /// <summary>
    /// Интерфейс для обрабтки ошибок
    /// </summary>
    public interface IError
    {
        /// <summary>
        /// Метод для перевода ошибки в универсальную модель
        /// </summary>
        /// <returns>Универсальная информативная модель ошибки</returns>
        public ErrorResponse MapToResponse();
    }
}
