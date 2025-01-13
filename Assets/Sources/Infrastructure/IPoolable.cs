namespace Infrastructure
{
    public interface IPoolable
    {
        public void SetPool(IPool pool);
        public void BackToPool();
    }
}