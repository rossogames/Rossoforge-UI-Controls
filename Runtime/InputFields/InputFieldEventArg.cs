namespace Rossoforge.UI.Controls.InputFields
{
    public readonly struct InputFieldEventArg<T> where T : InputFieldEventsHandler<T>
    {
        public T InputField { get; }
        public string Text { get; }

        public InputFieldEventArg(T inputField, string text)
        {
            InputField = inputField;
            Text = text;
        }
    }
}
