namespace Rossoforge.UI.Controls.InputFields
{
    public interface IInputFieldValueChangedListener<T> where T : InputFieldEventsHandler<T>
    {
        void OnValueChanged(InputFieldEventArg<T> eventArg);
    }
}
