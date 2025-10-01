using UnityEngine;

namespace Rossoforge.UI.Controls.GenericDropDowns
{
    [RequireComponent(typeof(GenericDropdown))]
    public abstract class GenericDropdownEventsHandler<T, R> : MonoBehaviour where T : GenericDropdownEventsHandler<T, R>
    {
        private GenericDropdown _dropdown;
        private IGenericDropdownSelectedItemChangedListener<T, R> _selectedItemChangedListener;

        private void Awake()
        {
            _dropdown = GetComponent<GenericDropdown>();
            _selectedItemChangedListener = GetComponentInParent<IGenericDropdownSelectedItemChangedListener<T, R>>(true);
        }

        private void OnEnable()
        {
            _dropdown.OnSelectedItemChanged.AddListener(OnSelectedItemChanged);
        }

        private void OnDisable()
        {
            _dropdown.OnSelectedItemChanged.RemoveListener(OnSelectedItemChanged);
        }

        private void OnSelectedItemChanged(object selectedItem)
        {
            var eventArgs = new GenericDropdownEventArg<T, R>((T)this, _dropdown.value, (R)selectedItem);
            _selectedItemChangedListener?.OnSelectedItemChanged(eventArgs);
        }
    }
}
