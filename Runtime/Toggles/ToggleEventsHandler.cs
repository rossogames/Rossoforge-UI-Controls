using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Toggles
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ToggleEventsHandler<T> : MonoBehaviour where T : ToggleEventsHandler<T>
    {
        private Toggle _toggle;
        private IToggleValueChangedListener<T> _valueChangedListener;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _valueChangedListener = GetComponentInParent<IToggleValueChangedListener<T>>(true);
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(bool isOn)
        {
            var eventArg = new ToggleEventArg<T>((T)this, isOn);
            _valueChangedListener?.OnValueChanged(eventArg);
        }
    }
}
