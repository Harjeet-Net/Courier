namespace CourierNew
{
    public class FailureResponse
    {
        public string message { get; set; }
        public int status { get; set; }
        public bool success { get; set; }



        public FailureResponse(string Message, int Status, bool Success)
        {
            message = Message;
            status = Status;
            success = Success;
        }
    }
}