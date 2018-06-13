using Engine.Model.Items.Behaviors;

namespace Engine.Model.Items
{
    public class AItem
    {
        public string Name { get; set; } 
        public AItem(string name)
        {
            Name = name;
        }
    }
}