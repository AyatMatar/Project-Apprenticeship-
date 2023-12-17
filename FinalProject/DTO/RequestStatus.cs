namespace FinalProject.DTO
{
    public class RequestStatus
    {
        public RequestStatus() { }
        public int statusCode { get; set; } //1 success  0 error
        public string message { get; set; }


        public RequestStatus(int statusCode, string message)
        {
            this.message = message;
            this.statusCode = statusCode;
        }

  

    }
}
