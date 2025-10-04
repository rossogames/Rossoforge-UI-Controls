namespace Rossoforge.UI.Controls.InputFields
{
    public interface IInputFieldOnDeselectListener<T> where T : InputFieldEventsHandler<T>
    {
        void OnDeselect(InputFieldEventArg<T> eventArg);
    }
}
