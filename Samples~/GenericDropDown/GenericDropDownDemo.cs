using Rossoforge.UI.Controls.GenericDropDowns;
using UnityEngine;

namespace Rossoforge.UI.Popups.GenericDropDownDemo
{
    public class GenericDropDownDemo : MonoBehaviour
    {
        [SerializeField] private GenericDropdown dropdown;

        private void Start()
        {
            var people = new[]
            {
                new Person { Name = "Alice", Age = 25 },
                new Person { Name = "Bob", Age = 30 }
            };

            dropdown.TextMember = "Name";
            dropdown.AddItems(people);
        }

        public class Person
        {
            public string Name;// { get; set; }
            public int Age;// { get; set; }
        }
    }
}