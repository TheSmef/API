using API.Models.Errors.Base;
using API.Models.Errors.Response;

namespace API.Models.Errors
{
    /// <summary>
    /// Универсальный класс ошибки
    /// </summary>
    public class Error : IError
    {
        /// <summary>
        /// Ошибка по умолчанию
        /// </summary>
        public static Error ErrorDefault => new Error(string.Empty);
        /// <summary>
        /// Список ошибок
        /// </summary>
        public List<string> Errors { get; set; } = new();
        /// <summary>
        /// Сообщение ошибки
        /// </summary>
        public string Message { get; set; } = string.Empty;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="message">Сообщение ошибки</param>
        public Error(string message)
        {
            this.Message = message;
        }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="message">Сообщение ошибки</param>
        /// <param name="Errors">Список ошибок</param>
        public Error(List<string> Errors, string message)
        {
            this.Errors = Errors;
            this.Message = message;
        }

        public ErrorResponse MapToResponse()
        {
            return new ErrorResponse()
            {
                Message = this.Message,
                Errors = this.Errors,
                Code = 400
            };
        }
    }
}
