using Engine.Common;
using Engine.Model.Items.Behaviors;

namespace Engine.Model.Items
{
    public class AItem : IDescribable
    {

        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Level { get; set; }

        public AItem(int Id, string name, int price, int level = 1)
        {
            ItemID = Id;
            Name = name;
            Price = price;
            Level = level;
        }

        public string Description { get; set; }
    }
}