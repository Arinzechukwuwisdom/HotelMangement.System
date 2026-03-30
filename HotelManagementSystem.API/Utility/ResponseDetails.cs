namespace HotelManagementSystem.API.Utility
{
    public class ResponseDetails<T>
    {
        public bool IsSuccess {  get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
