namespace API.Models.Requests.Shift
{
    public record StartShiftRequest(
        Guid Id,
        DateTime DateTime)
    { }
}
