namespace Rossoforge.UI.Controls.InputFields
{
    public interface IInputFieldEndEditListener<T> where T : InputFieldEventsHandler<T>
    {
        void OnEndEdit(InputFieldEventArg<T> arg);
    }
}