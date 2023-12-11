namespace ManagementApp.Api.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
    }
}
