namespace Engine.Model.Locations
{
    public class HostileLocation : Location
    {
        public HostileLocation(string name, string description) : base(name, description)
        {

        }

        public int DangerLevel { get; set; }
    }
}