namespace Engine.Common
{
    public interface IDescribable
    {
        string Description { get; set; }
        string GetDescription();
    }
}