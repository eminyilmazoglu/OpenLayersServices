namespace OpenLayersServices.DTOs
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public object result { get; set; }
    }
}
