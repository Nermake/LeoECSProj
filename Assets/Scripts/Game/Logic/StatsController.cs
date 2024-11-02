using GameTypes;

namespace Game.Logic
{
    public class StatsController : IController
    {
        private UnitConfig _config;
        private Unit _owner;
        
        private HealthController _healthController;
        private ResistController _resistController;
        private ManaController _manaController;

        public StatsController(UnitConfig config, Unit owner)
        {
            _config = config;
            _owner = owner;
        }
        
        public void Init()
        {
            _healthController = new HealthController(_config.GetUnitResource(UnitResourceType.Health));
            _resistController = new ResistController(_config.GetResists());
            _manaController = new ManaController(_config.GetUnitResource(UnitResourceType.Mana));
        }

        public HealthController GetHealthController() => _healthController;
        public ResistController GetResistController() => _resistController;
        public ManaController GetManaController() => _manaController;
        
        public StatsController GetController() => this;
    }
}