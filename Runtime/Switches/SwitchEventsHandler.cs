using UnityEngine;

namespace Rossoforge.UI.Controls.Switches
{
    [RequireComponent(typeof(Switch))]
    public abstract class SwitchEventsHandler<T> : MonoBehaviour where T : SwitchEventsHandler<T>
    {
        private Switch _switch;
        private ISwitchValueChangedListener<T> _valueChangedListener;

        private void Awake()
        {
            _switch = GetComponent<Switch>();
            _valueChangedListener = GetComponentInParent<ISwitchValueChangedListener<T>>(true);
        }

        private void OnEnable()
        {
            _switch.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _switch.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(bool isOn)
        {
            var eventArg = new SwitchEventArg<T>((T)this, isOn);
            _valueChangedListener?.OnValueChanged(eventArg);
        }
    }
}
