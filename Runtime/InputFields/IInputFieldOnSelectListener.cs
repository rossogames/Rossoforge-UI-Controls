namespace Rossoforge.UI.Controls.InputFields
{
    public interface IInputFieldOnSelectListener<T> where T : InputFieldEventsHandler<T>
    {
        void OnSelect(InputFieldEventArg<T> eventArg);
    }
}
