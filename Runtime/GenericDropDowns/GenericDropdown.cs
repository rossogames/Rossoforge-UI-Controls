using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Rossoforge.UI.Controls.GenericDropDowns
{
    [Serializable]
    public class DropdownItemSelectedEvent : UnityEvent<object> { }

    public class GenericDropdown : TMP_Dropdown
    {
        private List<object> items = new();

        [SerializeField] private ScriptableObject[] _dataSource;
        [SerializeField] private string _textMember;
        [SerializeField] private DropdownItemSelectedEvent _onSelectedItemChanged = new();

        public string TextMember
        {
            get => _textMember;
            set => _textMember = value;
        }

        public DropdownItemSelectedEvent OnSelectedItemChanged => _onSelectedItemChanged;

        protected override void Awake()
        {
            base.Awake();
            onValueChanged.AddListener(HandleValueChanged);
        }

        protected override void Start()
        {
            base.Start();
            LoadDataSource();
        }

        public void AddItem<T>(T item)
        {
            items.Add(item);
            options.Add(new OptionData(GetItemText(item)));
            RefreshShownValue();

            if (items.Count == 1)
                HandleValueChanged(0);
        }

        public void AddItems<T>(IEnumerable<T> newItems)
        {
            foreach (var item in newItems)
            {
                items.Add(item);
                options.Add(new OptionData(GetItemText(item)));
            }
            RefreshShownValue();
            HandleValueChanged(0);
        }

        public T GetSelectedItem<T>()
        {
            if (value < 0 || value >= items.Count)
                return default;

            return (T)items[value];
        }

        private string GetItemText(object item)
        {
            if (item == null)
                return "<null>";

            if (string.IsNullOrEmpty(TextMember))
                return item.ToString();

            var type = item.GetType();

            var prop = type.GetProperty(TextMember, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null)
            {
                var val = prop.GetValue(item);
                return val?.ToString() ?? "<null>";
            }

            var field = type.GetField(TextMember, BindingFlags.Public | BindingFlags.Instance);
            if (field != null)
            {
                var val = field.GetValue(item);
                return val?.ToString() ?? "<null>";
            }

            Debug.LogWarning($"Property '{TextMember}' not found in type {item.GetType().Name}. Fallback to ToString().");
            return item.ToString();
        }

        private void HandleValueChanged(int index)
        {
            if (index >= 0 && index < items.Count)
                _onSelectedItemChanged.Invoke(items[index]);
        }

        private void ClearItems()
        {
            items.Clear();
            options.Clear();
            RefreshShownValue();
        }

        private void LoadDataSource()
        {
            if (!Application.isPlaying)
                return;

            if (_dataSource == null || _dataSource.Count() == 0)
                return;

            ClearItems();
            AddItems(_dataSource);
        }
    }
}
