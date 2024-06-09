using System.Reflection;

namespace API.Extensions.Reference
{
    /// <summary>
    /// Класс с ссылкой на экземпляр Assembly
    /// </summary>
    public static class AssemblyReference
    {
        /// <summary>
        /// Экземпляр Assembly для использование при регистрации сервисов
        /// </summary>
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
