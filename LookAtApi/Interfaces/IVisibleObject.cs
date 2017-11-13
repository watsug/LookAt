namespace LookAtApi.Interfaces
{
    public interface IVisibleObject
    {
        IVisibleObject Parent { get; }
        ITransformation Transformation { get; }
        object Value { get; }
    }
}
