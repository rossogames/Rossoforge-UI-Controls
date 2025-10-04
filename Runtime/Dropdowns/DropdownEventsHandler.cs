using TMPro;
using UnityEngine;

namespace Rossoforge.UI.Controls.Dropdowns
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public abstract class DropdownEventsHandler<T> : MonoBehaviour where T : DropdownEventsHandler<T>
    {
        protected TMP_Dropdown Dropdown;
        private IDropdownValueChangedListener<T> _valueChangedListener;

        protected virtual void Awake()
        {
            Dropdown = GetComponent<TMP_Dropdown>();
            _valueChangedListener = GetComponentInParent<IDropdownValueChangedListener<T>>(true);
        }

        protected virtual void OnEnable()
        {
            Dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        protected virtual void OnDisable()
        {
            Dropdown.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(int value)
        {
            var eventArg = new DropdownEventArg<T>((T)this, value);
            _valueChangedListener?.OnValueChanged(eventArg);
        }
    }
}
