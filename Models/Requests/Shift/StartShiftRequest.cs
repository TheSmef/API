namespace API.Models.Requests.Shift
{
    public record StartShiftRequest(
        Guid Id,
        DateOnly Date,
        TimeOnly Time)
    { }
}
