using System.Collections.Generic;
using Engine.Common;

namespace Engine.Model.Locations
{
    public class Area : IDescribable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        private List<Location> Locations { get; set; }

    }
}