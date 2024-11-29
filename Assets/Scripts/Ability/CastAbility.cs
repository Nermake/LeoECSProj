namespace Ability
{
    public class CastAbility : Ability 
    {
        protected float _castTime;
        protected float _castTimer;

        public void SetCastTime(float castTime)
        {
            _castTime = castTime;
        }
        
        public virtual void Cast(){}
    }
}