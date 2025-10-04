using TMPro;
using UnityEngine;

namespace Rossoforge.UI.Controls.InputFields
{
    [RequireComponent(typeof(TMP_InputField))]
    public abstract class InputFieldEventsHandler<T> : MonoBehaviour where T : InputFieldEventsHandler<T>
    {
        protected TMP_InputField InputField;
        private IInputFieldValueChangedListener<T> _valueChangedListener;
        private IInputFieldEndEditListener<T> _endEditListener;
        private IInputFieldOnSelectListener<T> _onSelectListener;
        private IInputFieldOnDeselectListener<T> _onDeselectListener;

        protected virtual void Awake()
        {
            InputField = GetComponent<TMP_InputField>();
            _valueChangedListener = GetComponentInParent<IInputFieldValueChangedListener<T>>(true);
            _endEditListener = GetComponentInParent<IInputFieldEndEditListener<T>>(true);
            _onSelectListener = GetComponentInParent<IInputFieldOnSelectListener<T>>(true);
            _onDeselectListener = GetComponentInParent<IInputFieldOnDeselectListener<T>>(true);
        }

        protected virtual void OnEnable()
        {
            InputField.onValueChanged.AddListener(OnValueChanged);
            InputField.onEndEdit.AddListener(OnEndEdit);
            InputField.onSelect.AddListener(OnSelect);
            InputField.onDeselect.AddListener(OnDeselect);
        }

        protected virtual void OnDisable()
        {
            InputField.onValueChanged.RemoveListener(OnValueChanged);
            InputField.onEndEdit.RemoveListener(OnEndEdit);
            InputField.onSelect.RemoveListener(OnSelect);
            InputField.onDeselect.RemoveListener(OnDeselect);
        }

        private void OnValueChanged(string value)
        {
            var eventArg = new InputFieldEventArg<T>((T)this, value);
            _valueChangedListener?.OnValueChanged(eventArg);
        }
        private void OnEndEdit(string value)
        {
            var eventArg = new InputFieldEventArg<T>((T)this, value);
            _endEditListener?.OnEndEdit(eventArg);
        }
        private void OnSelect(string value)
        {
            var eventArg = new InputFieldEventArg<T>((T)this, value);
            _onSelectListener?.OnSelect(eventArg);
        }
        private void OnDeselect(string value)
        {
            var eventArg = new InputFieldEventArg<T>((T)this, value);
            _onDeselectListener?.OnDeselect(eventArg);
        }
    }
}
