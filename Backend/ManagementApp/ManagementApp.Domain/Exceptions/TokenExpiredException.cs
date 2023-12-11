namespace ManagementApp.Domain.Exceptions
{
    public class TokenExpiredException : Exception
    {
        public TokenExpiredException() : base("Token expired!")
        {
            HResult = 401;
        }
    }
}
