//using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

namespace Logics.Displaying
{
    public class DamageText : MonoBehaviour
    {
        public event Action<DamageText> ShowComplete;

        [SerializeField] private RectTransform _selfTransform;
        [SerializeField] private TMP_Text _text;

        [Header("Animations")]
        [SerializeField] private float _hideDuration;
        [SerializeField] private float _speedY;

        private float _alpha;
        private float _offsetX;
        private float _offsetY;
        private Transform _target;

        //private CoordinatesUtility _coordinatesUtility;

        public void Show()
        {
            //SetPositionToTarget();

            gameObject.SetActive(true);

            _offsetX = 30.0f;
            _offsetY = 0.0f;

            /*_selfTransform
                .DOPunchScale(Vector3.one * 1.3f, 0.3f);

            DOTween
                .To(x => _alpha = x, 1.0f, 0.0f, _hideDuration)
                .OnUpdate(() =>
                {
                    _text.alpha = _alpha;
                    SetPositionToTarget();
                })
                .OnComplete(() => ShowComplete?.Invoke(this))
                .SetLink(gameObject);*/
        }

        public void Hide() => gameObject.SetActive(false);

        public void SetText(string text) => _text.text = text;
        //public void SetUtility(CoordinatesUtility coordinatesUtility) => _coordinatesUtility = coordinatesUtility;
        public void SetTarget(Transform target) => _target = target;
        public void UpdatePosition(Vector3 position) => _selfTransform.position = position;

        /*private void SetPositionToTarget()
        {
            if (_target == null)
            {
                Hide();
                ShowComplete?.Invoke(this);
                return;
            }

            Vector2 screenPosition = _coordinatesUtility.GetScreenPosition(_target.position);
            screenPosition.y -= _offsetY;
            screenPosition.x += _offsetX;

            _offsetX -= _speedY * Time.fixedDeltaTime;
            _offsetY += _speedY * Time.fixedDeltaTime;

            UpdatePosition(screenPosition);
        }*/

    }
}