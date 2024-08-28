using GameTypes;

namespace Game.Logic
{
    public class HealthController : IController
    {
        private float _health;
        private float _currentHealth;

        private DamageCalculate _damageCalculate;
        
        public HealthController(float health)
        {
            _health = health;
        }
        
        public void Init()
        {
            _currentHealth = _health;
            _damageCalculate = new DamageCalculate();
        }

        public void ApplyDamage(float damage, EffectType type)
        {
            
        }

        public HealthController GetController() => this;
    }
}