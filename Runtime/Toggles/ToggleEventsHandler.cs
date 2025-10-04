using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Toggles
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ToggleEventsHandler<T> : MonoBehaviour where T : ToggleEventsHandler<T>
    {
        protected Toggle Toggle;
        private IToggleValueChangedListener<T> _valueChangedListener;

        protected virtual void Awake()
        {
            Toggle = GetComponent<Toggle>();
            _valueChangedListener = GetComponentInParent<IToggleValueChangedListener<T>>(true);
        }

        protected virtual void OnEnable()
        {
            Toggle.onValueChanged.AddListener(OnValueChanged);
        }

        protected virtual void OnDisable()
        {
            Toggle.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(bool isOn)
        {
            var eventArg = new ToggleEventArg<T>((T)this, isOn);
            _valueChangedListener?.OnValueChanged(eventArg);
        }
    }
}
