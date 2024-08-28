namespace Game.Logic
{
    public class ManaController : IController
    {
        private float _mana;

        public ManaController(float mana)
        {
            _mana = mana;
        }

        public ManaController GetController() => this;
    }
}