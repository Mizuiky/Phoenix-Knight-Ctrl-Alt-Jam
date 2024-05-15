
namespace JAM.Abilites
{
    public interface ICoolDownAbility
    {
        public float CoolDownTime { get; }
        public float ActiveTime { get; }
        public void ValidateCooldown();
    }
}
