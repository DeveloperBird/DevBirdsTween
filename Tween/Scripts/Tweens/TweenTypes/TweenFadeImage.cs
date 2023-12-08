using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DevBird.Tween
{
    public class TweenFadeImage : TweenBase<Image>
    {
        private float targetAlpha;
        private float startAlpha;

        public TweenFadeImage(Image targetImage, float targetAlpha, float totalDuration, IEaseState easeState, Action onComplete = null)
            : base(totalDuration, easeState, onComplete)
        {
            this.TweenObject = targetImage;
            this.targetAlpha = targetAlpha;
            this.startAlpha = targetImage.color.a;
        }


        public override void Tween()
        {
            if (!TweenObject) return;

            base.Tween();

            var TC = TweenObject.color;
            TweenObject.color = new Color(TC.r, TC.g, TC.b,
                Mathf.Lerp(startAlpha, targetAlpha, GetEaseValue));
        }
    }
}
