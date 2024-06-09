using API.Models.Errors;
using API.Models.Errors.Base;
using Bogus.Bson;

namespace API.Utility.Result
{
    /// <summary>
    /// Класс отображающий результат операции
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Конструктор результата
        /// </summary>
        /// <param name="isSuccess">Флаг успешности операции</param>
        /// <param name="error">Ошибка операции</param>
        protected internal Result(bool isSuccess, IError error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
        /// <summary>
        /// Флаг успеха операции
        /// </summary>
        public bool IsSuccess { get; }
        /// <summary>
        /// Флаг провала операции
        /// </summary>
        public bool IsFailure => !IsSuccess;
        /// <summary>
        /// Ошибка операции
        /// </summary>
        public IError Error { get; }
        /// <summary>
        /// Метод создания успешного результата
        /// </summary>
        /// <returns>Успешный <see cref="Result"/></returns>
        public static Result Success() => new(true, Models.Errors.Error.ErrorDefault);
        /// <summary>
        /// Метод создания результата с ошибкой
        /// </summary>
        /// <param name="error">Ошибка результата</param>
        /// <returns><see cref="Result"/> с ошибкой</returns>
        public static Result Failure(IError error) => new(false, error);
        /// <summary>
        /// Метод сопоставления результата
        /// </summary>
        /// <typeparam name="T">Тип данных, который должен вернуть метод</typeparam>
        /// <param name="onSuccess">Метод, который выполниться, если результат успешен</param>
        /// <param name="onFailure">Метод, который выполниться при результате с ошибкой</param>
        /// <returns></returns>
        public T Match<T>(
            Func<T> onSuccess,
            Func<IError, T> onFailure)
        {
            return IsSuccess ? onSuccess() : onFailure(Error);
        }
    }
    /// <summary>
    /// Класс отображающий результат операции с типом <typeparamref name="TValue"/>
    /// </summary>
    /// <typeparam name="TValue">Тип возвращаемый при успехе операции</typeparam>
    public class Result<TValue> : Result
    {
        /// <summary>
        /// Значение результата
        /// </summary>
        private readonly TValue? _value;
        /// <summary>
        /// Конструктор результата
        /// </summary>
        /// <param name="isSuccess">Флаг успешности операции</param>
        /// <param name="error">Ошибка операции</param>
        /// <param name="value">Значение результата</param>
        protected internal Result(TValue? value, bool isSuccess, IError error)
            : base(isSuccess, error)
        {
            _value = value;
        }
        public static Result<TValue> Create(TValue? value) => value is not null ? Success(value) : Failure(Models.Errors.Error.ErrorDefault);
        /// <summary>
        /// Метод создания успешного результата
        /// </summary>
        /// <returns>Успешный <see cref="Result{TValue}"/></returns>
        public static Result<TValue> Success(TValue value) => new(value, true, Models.Errors.Error.ErrorDefault);
        /// <summary>
        /// Метод создания результата с ошибкой
        /// </summary>
        /// <param name="error">Ошибка результата</param>
        /// <returns><see cref="Result{TValue}"/> с ошибкой</returns>
        public new static Result<TValue> Failure(IError error) => new(default, false, error);
        /// <summary>
        /// Свойство доступа к значению результата
        /// </summary>
        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException();
        /// <summary>
        /// Оператор конвертации значения в результат
        /// </summary>
        /// <param name="value">Значение, которое автоматически будет переведено в результат</param>
        public static implicit operator Result<TValue>(TValue? value) => Create(value);
    }

}
