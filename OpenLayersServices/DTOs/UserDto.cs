using OpenLayersServices.Model;

namespace OpenLayersServices.DTOs
{
    public class UserDto
    {
        public Coordinates coordinates { get; set; }
        public string userName { get; set; }
        public string dataNumber { get; set; }
    }
}
