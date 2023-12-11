namespace ManagementApp.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
            HResult = 404;
        }
    }
}
