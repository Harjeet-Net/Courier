namespace CourierNew.Class
{

    public class Response
    {
        public object data { get; set; }
        public string message { get; set; }
        public int status { get; set; }
        public bool success { get; set; }



        public Response(object Data, string Message, int Status, bool Success)
        {
            data = Data;
            message = Message;
            status = Status;
            success = Success;


        }
    }
}