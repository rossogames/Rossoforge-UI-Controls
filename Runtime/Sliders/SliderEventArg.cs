namespace Rossoforge.UI.Controls.Sliders
{
    public readonly struct SliderEventArg<T> where T : SliderEventsHandler<T>
    {
        public T Slider { get; }
        public float Value { get; }

        public SliderEventArg(T slider, float value)
        {
            Slider = slider;
            Value = value;
        }
    }
}
