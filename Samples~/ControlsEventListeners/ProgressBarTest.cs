using Rossoforge.UI.Controls.ProgressBars;
using UnityEngine;

namespace Rossoforge.UI.Popups.UIControls.EventHandlerDemo
{
    public class ProgressBarTest : ProgressBarEventsHandler<ProgressBarTest>
    {
        private void Update()
        {
            if(Input.GetKey(KeyCode.KeypadPlus))
                base.ProgressBar.value += 0.2f * Time.deltaTime;

            if (Input.GetKey(KeyCode.KeypadMinus))
                base.ProgressBar.value -= 0.2f * Time.deltaTime;
        }
    }
}
