using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static Rossoforge.Extensions.RectTransformExtensions;

namespace Rossoforge.UI.Controls.Switches
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Switch : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private bool _interactable = true;
        [SerializeField] private bool _isOn;

        [SerializeField] private SwitchImages _images;
        [SerializeField] private SwitchLabels _labels;
        [SerializeField] private CanvasGroup _canvasGroup;

        private const float margin = -10;
        private const float widgth = 86;

        public UnityEvent<bool> onValueChanged;

        public bool Interactable
        {
            get => _interactable;
            set
            {
                if (_interactable != value)
                {
                    _interactable = value;
                    UpdateInteractivleView();
                }
            }
        }

        public bool IsOn
        {
            get => _isOn;
            set
            {
                if (_isOn != value)
                {
                    _isOn = value;
                    UpdateToggleView();
                    onValueChanged.Invoke(value);
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!Interactable)
                return;

            this.IsOn = !this.IsOn;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            EditorApplication.delayCall += () =>
            {
                if (this == null)
                    return;

                UpdateToggleView();
                UpdateInteractivleView();
            };
        }
#endif 

        private void UpdateToggleView()
        {
            var recTransform = (RectTransform)_images.toggle.transform;

            _images.backgroundOn.gameObject.SetActive(this.IsOn);
            _images.backgroundOff.gameObject.SetActive(!this.IsOn);
            _labels.labelOn.gameObject.SetActive(this.IsOn);
            _labels.labelOff.gameObject.SetActive(!this.IsOn);

            if (this.IsOn)
            {
                recTransform.SetAnchor(RectTransformAnchorHorizontal.Right, RectTransformAnchorVertical.Middle);
                recTransform.SetRightMargin(margin);
                recTransform.SetWidth(widgth);
            }
            else
            {
                recTransform.SetAnchor(RectTransformAnchorHorizontal.Left, RectTransformAnchorVertical.Middle);
                recTransform.SetLeftMargin(margin);
                recTransform.SetWidth(widgth);
            }
        }

        private void UpdateInteractivleView()
        {
            _canvasGroup.interactable = _interactable;
            _canvasGroup.blocksRaycasts = _interactable;
            _canvasGroup.alpha = _interactable ? 1f : 0.5f;
        }
    }
}