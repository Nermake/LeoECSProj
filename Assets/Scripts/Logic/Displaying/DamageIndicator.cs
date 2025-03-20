using System.Collections.Generic;
using UnityEngine;

namespace Logics.Displaying
{
    public class DamageIndicator : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;
        [SerializeField] private DamageText _damageTextPrefab;

        //private CoordinatesUtility _coordinatesUtility;

        private Queue<DamageText> _damageIndicatorPool = new();
        private int _poolSize;


        // public void Inject(IServicesLocator locator)
        // {
        //     _levelEvents = locator.GetServices<ILevelEvents>();
        //     _levelEvents.LevelLoaded += OnLevelLoaded;
        //
        //     _coordinatesUtility = locator.GetServices<CoordinatesUtility>();
        //
        //     _poolSize = locator.GetServices<GameInstance>().GameConstants.PoolSizeUI;
        //     CreatePool();
        // }

        private void OnLevelLoaded()
        {
            CreatePool();
        }

        public void ShowDamageOnDisplay(float damage, Transform target)
        {
            DamageText widget = GetDamageText();

            widget.SetText(Mathf.RoundToInt(damage).ToString());
            widget.SetTarget(target);
            widget.ShowComplete += ReturnToPool;
            widget.Show();
        }

        public void ShowHealthOnDisplay(float health, Transform target)
        {
            DamageText widget = GetDamageText();

            widget.SetText("<color=green>" + Mathf.RoundToInt(health).ToString());
            widget.SetTarget(target);
            widget.ShowComplete += ReturnToPool;
            widget.Show();
        }

        public DamageText GetDamageText()
        {
            return _damageIndicatorPool.Count > 0 
                ? _damageIndicatorPool.Dequeue() 
                : CreateWidget();
        }

        public void ReturnToPool(DamageText damageText)
        {
            damageText.ShowComplete -= ReturnToPool;
            damageText.Hide();
            _damageIndicatorPool.Enqueue(damageText);
        }

        private void CreatePool()
        {
            for (int i = 0; i < _poolSize; ++i)
            {
                DamageText widget = CreateWidget();
                widget.Hide();
                _damageIndicatorPool.Enqueue(widget);
            }
        }

        private DamageText CreateWidget()
        {
            var widget = Instantiate(_damageTextPrefab, _container);
            //widget.SetUtility(_coordinatesUtility);

            return widget;
        }

        // private void OnDestroy()
        // {
        //     if (_levelEvents != null)
        //     {
        //         _levelEvents.LevelLoaded -= OnLevelLoaded;
        //     }
        // } // todo
    }
}