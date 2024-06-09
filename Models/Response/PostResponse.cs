using API.Extensions.Enums;
using API.Models.Entity;

namespace API.Models.Response
{
    /// <summary>
    /// Модель-ответ с информацией о должности
    /// </summary>
    /// <param name="Post">Должность</param>
    public record PostResponse(PostEnum Post)
    {
        /// <summary>
        /// Должность в виде строки
        /// </summary>
        public string PostString => Post.GetStringValue();
    }
}
