namespace Rossoforge.UI.Controls.Buttons
{
    public readonly struct ButtonEventArg<T> where T : ButtonEventsHandler<T>
    {
        public T Button { get; }

        public ButtonEventArg(T button)
        {
            Button = button;
        }
    }
}
