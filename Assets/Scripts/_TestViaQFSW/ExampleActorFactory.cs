using QFSW.QC;
using Services.Factory;
using Services.Factory.Builders;
using Services.Locator;
using UnityEngine;

namespace _TestViaQFSW
{
    public class ExampleActorFactory : MonoBehaviour
    {
        [SerializeField] private EntityConfig _entityConfig;
        [SerializeField] private HeroConfig _heroConfig;
        private IActorFactory _actorFactory;

        private void Start()
        {
            _actorFactory = ServiceLocator.Current.Get<ActorFactory>();
        }

        [Command]
        private void af1_b()
        {
            var builder = _entityConfig.GetBuilder();
            builder.Make();
        }
        
        [Command]
        private void af2_b()
        {
            var builder = _heroConfig.GetBuilder();
            builder.Make();
        }
        
        [Command]
        private void af_ch_old()
        {
            _actorFactory.CreateEntity(_entityConfig, Vector3.zero);
        }
        
        [Command]
        private void af_ch_new()
        {
            _actorFactory.CreateEntity(_heroConfig, Vector3.zero);
        }
    }
}