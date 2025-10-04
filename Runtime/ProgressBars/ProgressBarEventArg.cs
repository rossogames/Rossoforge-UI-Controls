namespace Rossoforge.UI.Controls.ProgressBars
{
    public readonly struct ProgressBarEventArg<T> where T : ProgressBarEventsHandler<T>
    {
        public T ProgressBar { get; }
        public float Value { get; }

        public ProgressBarEventArg(T progressBar, float value)
        {
            ProgressBar = progressBar;
            Value = value;
        }
    }
}
