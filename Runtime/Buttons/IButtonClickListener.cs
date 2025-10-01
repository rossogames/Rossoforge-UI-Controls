namespace Rossoforge.UI.Controls.Buttons
{
    public interface IButtonClickListener<T> where T : ButtonEventsHandler<T>
    {
        void OnClick(ButtonEventArg<T> eventArg);
    }
}
