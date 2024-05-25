

using System.ComponentModel.DataAnnotations;

namespace OpenLayersServices.Model
{
    public class Coordinate
    {
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; } // "Polygon"
        public ICollection<Point> Points { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
