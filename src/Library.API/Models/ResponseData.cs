namespace Library.API.Models
{
    public class ResponseData<T>
    {
        
        public T? Data { get; private set; }

        public bool Success { get; set; }

        public string? ErrorMessage { get; set; }

        public ResponseData(T? data, string errorMessage = "", bool success = true) 
        {
            this.Data = data;
            this.ErrorMessage = errorMessage;
            this.Success = success;
        }
    }
}
