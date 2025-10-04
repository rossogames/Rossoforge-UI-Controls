namespace Rossoforge.UI.Controls.Toggles
{
    public readonly struct ToggleEventArg<T> where T : ToggleEventsHandler<T>
    {
        public T Toggle { get; }
        public bool IsOn { get; }

        public ToggleEventArg(T toggle, bool isOn)
        {
            Toggle = toggle;
            IsOn = isOn;
        }
    }
}
