using CleanArchitecture.Common.Exceptions.Abstract;

namespace CleanArchitecture.Common.Exceptions.ApiExceptions
{
    public sealed class BadRequestException:BaseException
    {
        public BadRequestException(string message):base(message)
        {
            
        }
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
