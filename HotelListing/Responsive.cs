namespace HotelListing
{
    public class Responsive
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Responsive(string status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
