namespace OpenLayersServices.Model
{
    public class Point
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid CoordinateId { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}
