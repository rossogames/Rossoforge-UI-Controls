namespace Rossoforge.UI.Controls.Sliders
{
    public interface ISliderValueChangedListener<T> where T : SliderEventsHandler<T>
    {
        void OnValueChanged(SliderEventArg<T> eventArg);
    }
}
