
namespace JAM.Pools
{
    public interface IPoolable
    {
        public void Init();
        public void Activate();
        public void Deactivate();
    }
}