namespace FluentValidationDemo.Response
{
    public abstract class RequestResponse
    {
        public abstract IResponse OnRequest(ResponseType responseType);

    }

    public enum ResponseType
    {
        Success = 1,
        Failure = -1
    }
}
