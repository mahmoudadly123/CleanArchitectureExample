using CleanArchitecture.Common.Exceptions.Abstract;

namespace CleanArchitecture.Common.Exceptions.ApiExceptions
{
    public class NotFoundException:BaseException
    {
        public NotFoundException(string name, object value) : base($"{name} = {value} is not found")
        {

        }

        public NotFoundException(string message) : base(message)
        {

        }
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
       
    }
}
