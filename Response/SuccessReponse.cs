namespace FluentValidationDemo.Response
{
    public class SuccessReponse : IResponse
    {
        private readonly string _message;
        private readonly string _status;
        private readonly object _data;

        public SuccessReponse()
        {
            _message = null;
            _status = "Success";
            _data = null;
        }
        public SuccessReponse(string status, object data)
        {
            _message = null;
            _status = status;
            _data = data;
        }
        public SuccessReponse(string status, string message, object data)
        {
            _message = message;
            _status = status;
            _data = data;
        }

        public object GetData() => _data;

        public string GetMessage() => _message; 

        public string GetStatus() => _status;

    }
}
