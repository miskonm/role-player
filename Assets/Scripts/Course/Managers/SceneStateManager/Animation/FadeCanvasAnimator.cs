using Course.Base;
using Course.Utility;
using UnityEngine;

namespace Course.Managers.SceneStateManager.Animation
{
    public sealed class FadeCanvasAnimator : AbstractService<ICanvasAnimator>, ICanvasAnimator
    {
        public float AppearDuration = 1.0f;
        public float DisappearDuration = 1.0f;

        public void AnimateAppear(UnityEngine.Canvas canvas, CanvasGroup canvasGroup)
        {
            canvasGroup.DOFade(1.0f, AppearDuration);
        }

        public void AnimateDisappear(UnityEngine.Canvas canvas, CanvasGroup canvasGroup)
        {
            canvasGroup.DOFade(0.0f, DisappearDuration);
        }
    }
}
