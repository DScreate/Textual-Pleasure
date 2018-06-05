namespace Engine.Model.Character
{
    public abstract class AbstractStat
    {
        public double Value { get; set; }

        public string Name { get; set; }

        public AbstractStat(string inName)
        {
            Name = inName;
        }

        public AbstractStat(double inValue, string inName)
        {
            Value = inValue;
            Name = inName;
        }

    
    }
}