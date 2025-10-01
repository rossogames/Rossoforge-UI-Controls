using TMPro;
using UnityEngine;

namespace Rossoforge.UI.Controls.Dropdowns
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public abstract class DropdownEventsHandler<T> : MonoBehaviour where T : DropdownEventsHandler<T>
    {
        private TMP_Dropdown _dropdown;
        private IDropdownValueChangedListener<T> _valueChangedListener;

        private void Awake()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _valueChangedListener = GetComponentInParent<IDropdownValueChangedListener<T>>(true);
        }

        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(int value)
        {
            var eventArg = new DropdownEventArg<T>((T)this, value);
            _valueChangedListener?.OnValueChanged(eventArg);
        }
    }
}
