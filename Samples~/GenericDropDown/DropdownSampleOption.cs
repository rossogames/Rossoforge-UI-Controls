using UnityEngine;

namespace Rossoforge.UI.Popups.GenericDropDownDemo
{
    [CreateAssetMenu(fileName = nameof(DropdownSampleOption), menuName = "Rossoforge/Popups/GenericDropDownDemo/DropdownSampleOption")]
    public class DropdownSampleOption : ScriptableObject
    {
        public int Id;
        public string Label;
        public Sprite Icon;
    }
}