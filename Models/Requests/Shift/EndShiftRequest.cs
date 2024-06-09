using API.Models.Entity;

namespace API.Models.Requests.Shift
{
    /// <summary>
    /// Модель-запрос окончания смены
    /// </summary>
    /// <param name="Id">Идентификатор сотрудника</param>
    /// <param name="Time">Время конца смены</param>
    public record EndShiftRequest(
        Guid Id,
        TimeOnly Time)
    { }
}
