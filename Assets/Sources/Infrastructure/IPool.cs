namespace Infrastructure
{
    public interface IPool
    {
        public void Release(IPoolable item);
    }
}