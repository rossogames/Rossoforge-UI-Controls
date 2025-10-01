namespace Rossoforge.UI.Controls.GenericDropDowns
{
    public readonly struct GenericDropdownEventArg<T, R> where T : GenericDropdownEventsHandler<T, R>
    {
        public T Dropdown { get; }
        public int SelectedIndex { get; }
        public R SelectedItem { get; }

        public GenericDropdownEventArg(T dropdown, int selectedIndex, R selectedItem)
        {
            Dropdown = dropdown;
            SelectedIndex = selectedIndex;
            SelectedItem = selectedItem;
        }
    }
}
