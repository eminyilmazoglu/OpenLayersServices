using System.ComponentModel.DataAnnotations;

namespace OpenLayersServices.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string DataNumber { get; set; }
        public ICollection<Coordinate> Coordinates { get; set; }
    }
}
