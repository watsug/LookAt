namespace LookAtApi.Interfaces
{
    public interface IVisibleObject
    {
        IVisibleObject Parent { get; }
        ITransformation Transformation { get; }
        bool Final { get; }
        object Value { get; }
    }
}
