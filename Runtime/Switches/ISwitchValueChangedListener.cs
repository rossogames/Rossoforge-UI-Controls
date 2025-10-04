namespace Rossoforge.UI.Controls.Switches
{
    public interface ISwitchValueChangedListener<T> where T : SwitchEventsHandler<T>
    {
        void OnValueChanged(SwitchEventArg<T> eventArg);
    }
}
