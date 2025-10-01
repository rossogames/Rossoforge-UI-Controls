using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Sliders
{
    [RequireComponent(typeof(Slider))]
    public abstract class SliderEventsHandler<T> : MonoBehaviour where T : SliderEventsHandler<T>
    {
        private Slider _slider;
        private ISliderValueChangedListener<T> _valueChangedListener;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _valueChangedListener = GetComponentInParent<ISliderValueChangedListener<T>>(true);
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            var eventArg = new SliderEventArg<T>((T)this, value);
            _valueChangedListener?.OnValueChanged(eventArg);
        }
    }
}
