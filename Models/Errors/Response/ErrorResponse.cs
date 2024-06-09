namespace API.Models.Errors.Response
{
    /// <summary>
    /// Универсальная модель ошибки
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Сообщение ошибки
        /// </summary>
        public string Message { get; set; } = string.Empty;
        /// <summary>
        /// Код ошибки
        /// </summary>
        public int Code { get; set; } = 0;
        /// <summary>
        /// Содержание ошибки
        /// </summary>
        public List<string> Errors { get; set; } = [];
    }
}
