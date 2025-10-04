using UnityEngine;

namespace Rossoforge.UI.Controls.ProgressBars
{
    [RequireComponent(typeof(ProgressBar))]
    public abstract class ProgressBarEventsHandler<T> : MonoBehaviour where T : ProgressBarEventsHandler<T>
    {
        private ProgressBar _progressBar;
        private IProgressBarValueChangedListener<T> _valueChangedListener;

        protected virtual void Awake()
        {
            _progressBar = GetComponent<ProgressBar>();
            _valueChangedListener = GetComponentInParent<IProgressBarValueChangedListener<T>>(true);
        }

        private void OnEnable()
        {
            _progressBar.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _progressBar.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            var eventArg = new ProgressBarEventArg<T>((T)this, value);
            _valueChangedListener?.OnValueChanged(eventArg);
        }
    }
}
