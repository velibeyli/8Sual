namespace _8Sual.Wrappers
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string[] Errors { get; set; }
        public Guid RequestId { get; set; } = Guid.NewGuid();
    }
}
