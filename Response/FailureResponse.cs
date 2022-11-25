using FluentValidation.Results;

namespace FluentValidationDemo.Response
{
    public class FailureResponse: IResponse
    {
        private readonly string _status;
        private readonly string _message;
        private readonly ValidationResult _validationResult;

        public FailureResponse(string status, ValidationResult validationResult)
        {
            _message = null;
            _status = status;
            _validationResult = validationResult;
        }
      
        public ValidationResult GetData() => _validationResult;

        public string GetMessage() => _message;

        public string GetStatus() => _status;
    }
}
