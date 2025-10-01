namespace Rossoforge.UI.Controls.Dropdowns
{
    public interface IDropdownValueChangedListener<T> where T : DropdownEventsHandler<T>
    {
        void OnValueChanged(DropdownEventArg<T> eventArg);
    }
}
