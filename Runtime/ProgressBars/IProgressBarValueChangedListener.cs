namespace Rossoforge.UI.Controls.ProgressBars
{
    public interface IProgressBarValueChangedListener<T> where T : ProgressBarEventsHandler<T>
    {
        void OnValueChanged(ProgressBarEventArg<T> eventArg);
    }
}
