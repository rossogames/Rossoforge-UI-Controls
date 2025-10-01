namespace Rossoforge.UI.Controls.Dropdowns
{
    public readonly struct DropdownEventArg<T> where T : DropdownEventsHandler<T>
    {
        public T Dropdown { get; }
        public int SelectedIndex { get; }

        public DropdownEventArg(T dropdown, int selectedIndex)
        {
            Dropdown = dropdown;
            SelectedIndex = selectedIndex;
        }
    }
}
