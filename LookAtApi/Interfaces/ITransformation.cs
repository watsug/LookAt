namespace LookAtApi.Interfaces
{
    public interface ITransformation
    {
        string Name { get; }
        IVisibleObject DoTransformation(IVisibleObject obj);
    }
}
