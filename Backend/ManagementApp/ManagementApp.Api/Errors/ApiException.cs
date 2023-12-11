namespace ManagementApp.Api.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null, string details = null) : base(statusCode)
        {
            Message = message;
            Details = details;
        }

        public string Message { get; set; }
        public string Details { get; set; }
    }
}
