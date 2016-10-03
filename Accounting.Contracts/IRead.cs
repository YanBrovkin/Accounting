namespace Accounting.Contracts
{
    public interface IRead<in S, out T>
    {
        T Get(S spec);
    }
}
