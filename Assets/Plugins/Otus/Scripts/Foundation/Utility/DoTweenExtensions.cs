using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace Foundation
{
  public static class DoTweenExtensions
  {
    public static TweenerCore<Color, Color, ColorOptions> DOFade(
      this Graphic target,
      float endValue,
      float duration)
    {
      TweenerCore<Color, Color, ColorOptions> alpha = DOTween.ToAlpha((DOGetter<Color>)(() => target.color),
        (DOSetter<Color>)(x => target.color = x), endValue, duration);

      alpha.SetTarget<TweenerCore<Color, Color, ColorOptions>>((object)target);

      return alpha;
    }

    public static TweenerCore<float, float, FloatOptions> DOFade(
      this CanvasGroup target,
      float endValue,
      float duration)
    {
      TweenerCore<float, float, FloatOptions> t = DOTween.To((DOGetter<float>)(() => target.alpha),
        (DOSetter<float>)(x => target.alpha = x), endValue, duration);

      t.SetTarget<TweenerCore<float, float, FloatOptions>>((object)target);

      return t;
    }
  }
}
