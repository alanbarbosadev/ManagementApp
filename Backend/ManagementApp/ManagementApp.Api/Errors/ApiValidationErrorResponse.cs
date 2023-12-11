namespace ManagementApp.Api.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse(int statusCode, IEnumerable<string> errors) : base(400)
        {
            Errors = errors;
        }
     
        public IEnumerable<string> Errors { get; set; }
    }
}
