using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace Course.Utility
{
  public static class DoTweenExtensions
  {
    public static TweenerCore<Color, Color, ColorOptions> DOFade(this Graphic target, float endValue, float duration)
    {
      TweenerCore<Color, Color, ColorOptions> t = DOTween.ToAlpha(() => target.color, x => target.color = x, endValue, duration);
      t.SetTarget(target);
      return t;
    }
    
    public static TweenerCore<float, float, FloatOptions> DOFade(this CanvasGroup target, float endValue, float duration)
    {
      TweenerCore<float, float, FloatOptions> t = DOTween.To(() => target.alpha, x => target.alpha = x, endValue, duration);
      t.SetTarget(target);
      return t;
    }
  }
}
