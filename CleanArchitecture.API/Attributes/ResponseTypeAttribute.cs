using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Attributes
{
    public class ResponseTypeAttribute : ProducesResponseTypeAttribute
    {
        public ResponseTypeAttribute(int statusCode) : base(statusCode)
        {
        }

        public ResponseTypeAttribute(Type type, int statusCode) : base(type, statusCode)
        {
        }

        public ResponseTypeAttribute(Type type, int statusCode, string contentType, params string[] additionalContentTypes) : base(type, statusCode, contentType, additionalContentTypes)
        {
        }
    }
}
