using Logic.View;
using QFSW.QC;
using Services.Factory;
using Services.Factory.Builders;
using Services.Locator;
using UnityEngine;
using Voody.UniLeo;

namespace _TestViaQFSW
{
    public class ExampleActorFactory : MonoBehaviour
    {
        [SerializeField] private HeroConfig _heroConfig;
        [SerializeField] Transform _spawnPoint;
        
        private IActorFactory _actorFactory; // todo
        private ActorView _view;

        private void Start()
        {
            _actorFactory = ServiceLocator.Current.Get<ActorFactory>();
            _actorFactory = new ActorFactory(WorldHandler.GetWorld());
        }
        
        [Command]
        private void af_ch()
        {
            _actorFactory.CreateEntity(_heroConfig, _spawnPoint.position);
        }
    }
}