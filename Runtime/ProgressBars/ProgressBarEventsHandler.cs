using UnityEngine;

namespace Rossoforge.UI.Controls.ProgressBars
{
    [RequireComponent(typeof(ProgressBar))]
    public abstract class ProgressBarEventsHandler<T> : MonoBehaviour where T : ProgressBarEventsHandler<T>
    {
        protected ProgressBar ProgressBar;
        private IProgressBarValueChangedListener<T> _valueChangedListener;

        protected virtual void Awake()
        {
            ProgressBar = GetComponent<ProgressBar>();
            _valueChangedListener = GetComponentInParent<IProgressBarValueChangedListener<T>>(true);
        }

        protected virtual void OnEnable()
        {
            ProgressBar.onValueChanged.AddListener(OnValueChanged);
        }

        protected virtual void OnDisable()
        {
            ProgressBar.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            var eventArg = new ProgressBarEventArg<T>((T)this, value);
            _valueChangedListener?.OnValueChanged(eventArg);
        }
    }
}
