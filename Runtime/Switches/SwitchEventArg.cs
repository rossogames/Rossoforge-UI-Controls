namespace Rossoforge.UI.Controls.Switches
{
    public readonly struct SwitchEventArg<T> where T : SwitchEventsHandler<T>
    {
        public T Switch { get; }
        public bool IsOn { get; }

        public SwitchEventArg(T @switch, bool isOn)
        {
            Switch = @switch;
            IsOn = isOn;
        }
    }
}
