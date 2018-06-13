using System.Collections.Generic;

namespace Engine.Model.Locations
{
    public class Area
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        private List<Location> Locations { get; set; }

    }
}