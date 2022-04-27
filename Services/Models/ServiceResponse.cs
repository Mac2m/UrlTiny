namespace Services.Models
{
    public interface IServiceResponse
    {
        bool Succeeded { get; }
        string ErrorMessage { get; }
    }

    public class ServiceResponse : IServiceResponse
    {
        public ServiceResponse()
        {
            this.Succeeded = true;
        }

        public ServiceResponse(string errorMessage)
        {
            this.Succeeded = false;
            this.ErrorMessage = errorMessage;
        }

        public bool Succeeded
        {
            get; set;
        }

        public string ErrorMessage
        {
            get;
            private set;
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public ServiceResponse(T data)
        {
            this.Data = data;
        }

        public ServiceResponse(string errorMessage) : base(errorMessage)
        {
        }

        public ServiceResponse()
        {

        }

        public T Data { get; set; }
    }

    public class ServiceResponse<T, TObject> : ServiceResponse<T>
    {
        public ServiceResponse(string errorMessage) : base(errorMessage)
        {
        }

        public ServiceResponse(T data, TObject obj) : base(data)
        {
            Object = obj;
        }

        public TObject Object { get; set; }
    }
}