using UnityEngine;
using UnityEngine.UI;
using System;

namespace DevBird.Tween
{
    public class TweenFadeText : TweenBase<Text>
    {
        private float targetAlpha;
        private float startAlpha;

        public TweenFadeText(Text targetText, float targetAlpha, float totalDuration, IEaseState easeState, Action onComplete = null) : base(totalDuration, easeState, onComplete)
        {
            this.TweenObject = targetText;
            this.targetAlpha = targetAlpha;
        }

        public override void Tween()
        {
            base.Tween();

            var TC = TweenObject.color;
            TweenObject.color = new Color(TC.r, TC.g, TC.b,
                Mathf.Lerp(startAlpha, targetAlpha, GetEaseValue));
        }
    }
}
