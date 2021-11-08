using UnityEngine;

namespace Course.Managers.SceneStateManager.Animation
{
    public interface ICanvasAnimator
    {
        void AnimateAppear(UnityEngine.Canvas canvas, CanvasGroup canvasGroup);
        void AnimateDisappear(UnityEngine.Canvas canvas, CanvasGroup canvasGroup);
    }
}
