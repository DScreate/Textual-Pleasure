namespace Engine.Model.Locations
{
    public class Path
    {
        public double CostToTravel { get; set; }

        public string Description { get; set; }

        public Location StartLocation { get; set; }

        public Location EndLocation { get; set; }

        public bool IsOneWay { get; set; }

        public float DangerLevel { get; set; }

        public Path(Location start, Location end, double cost, bool isOneWay, float danger, string description = "")
        {
            StartLocation = start;
            EndLocation = end;
            CostToTravel = cost;
            IsOneWay = isOneWay;
            DangerLevel = danger;
            Description = description;
        }
    }
}