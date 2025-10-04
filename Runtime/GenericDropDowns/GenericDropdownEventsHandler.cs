using UnityEngine;

namespace Rossoforge.UI.Controls.GenericDropDowns
{
    [RequireComponent(typeof(GenericDropdown))]
    public abstract class GenericDropdownEventsHandler<T, R> : MonoBehaviour where T : GenericDropdownEventsHandler<T, R>
    {
        protected GenericDropdown Dropdown;
        private IGenericDropdownSelectedItemChangedListener<T, R> _selectedItemChangedListener;

        protected virtual void Awake()
        {
            Dropdown = GetComponent<GenericDropdown>();
            _selectedItemChangedListener = GetComponentInParent<IGenericDropdownSelectedItemChangedListener<T, R>>(true);
        }

        protected virtual void OnEnable()
        {
            Dropdown.OnSelectedItemChanged.AddListener(OnSelectedItemChanged);
        }

        protected virtual void OnDisable()
        {
            Dropdown.OnSelectedItemChanged.RemoveListener(OnSelectedItemChanged);
        }

        private void OnSelectedItemChanged(object selectedItem)
        {
            var eventArgs = new GenericDropdownEventArg<T, R>((T)this, Dropdown.value, (R)selectedItem);
            _selectedItemChangedListener?.OnSelectedItemChanged(eventArgs);
        }
    }
}
