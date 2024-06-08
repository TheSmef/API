using API.Models.Entity;

namespace API.Models.Requests.Shift
{
    public record EndShiftRequest(
        Guid Id,
        TimeOnly Time)
    { }
}
