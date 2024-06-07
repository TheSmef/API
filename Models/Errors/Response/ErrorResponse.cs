namespace API.Models.Errors.Response
{
    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public int Code { get; set; } = 0;
        public List<string> Errors { get; set; } = [];
    }
}
