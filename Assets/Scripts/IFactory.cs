public interface IFactory
{
    T Create<T>(T data);
}
