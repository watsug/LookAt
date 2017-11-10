namespace LookAtApi.Interfaces
{
    public interface IVisibleObject
    {
        IVisibleObject Parent { get; }
        object Value { get; }
    }
}
