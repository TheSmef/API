namespace API.Models.Requests.Shift
{
    /// <summary>
    /// Модель-запрос начала смены
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника</param>
    /// <param name="Date">Дата начала смены</param>
    /// <param name="Time">Время начала смены</param>
    public record StartShiftRequest(
        Guid Id,
        DateOnly Date,
        TimeOnly Time)
    { }
}
