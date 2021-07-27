using RegionsDirectory.Common;

namespace RegionsDirectory.Core.Responses
{
    public abstract class BaseResponse<T>
    {
        public CustomerCodes Code { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        protected BaseResponse(T resource)
        {
            Code = CustomerCodes.Ok;
            Message = string.Empty;
            Resource = resource;
        }

        protected BaseResponse(string message, CustomerCodes code)
        {
            Code = code;
            Message = message;
            Resource = default;
        }
    }
}