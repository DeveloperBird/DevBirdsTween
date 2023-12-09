using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DevBird.Tween
{
    /// <summary>
    /// Convenience class for users to call Tweening methods.
    /// </summary>
    public static class Tween
    {
        public static void Move(Transform targetObject, Vector3 targetPosition, float duration, IEaseState easeState, Action onComplete = null)
        {
            TweenManager.Instance.AddTween(new TweenMove(targetObject, targetPosition, duration, easeState, onComplete));
        }

        public static void MoveAlongCurve(Transform targetObject, Vector3 targetPosition, float peakHeight, float totalDuration, IEaseState easeState, Action onComplete = null)
        {
            TweenManager.Instance.AddTween(new TweenMoveCurve(targetObject, targetPosition, peakHeight, totalDuration, easeState, onComplete));
        }

        public static void Scale(Transform targetObject, Vector3 targetScale, float duration, IEaseState easeState, Action onComplete = null)
        {
            TweenManager.Instance.AddTween(new TweenScale(targetObject, targetScale, duration, easeState, onComplete));
        }

        public static void Rotate(Transform targetObject, Quaternion targetRotation, float duration, IEaseState easeState, Action onComplete = null)
        {
            TweenManager.Instance.AddTween(new TweenRotate(targetObject, targetRotation, duration, easeState, onComplete));
        }

        public static void FadeText(Text targetText, float targetAlpha, float duration, IEaseState easeState, Action onComplete = null)
        {
            TweenManager.Instance.AddTween(new TweenFadeText(targetText, targetAlpha, duration, easeState, onComplete));
        }

        public static void FadeImage(Image targetImage, float targetAlpha, float duration, IEaseState easeState, Action onComplete = null)
        {
            TweenManager.Instance.AddTween(new TweenFadeImage(targetImage, targetAlpha, duration, easeState, onComplete));
        }


        public static void PopShrink(Transform targetObject, float expandSize, float shrinkSize, float duration, Action onComplete = null)
        {
            var expandVector = Vector3.Scale((Vector3.one * expandSize), targetObject.localScale);
            var shrinkVector = Vector3.Scale((Vector3.one * shrinkSize), targetObject.localScale);

            var tweenExpand = new TweenScale(targetObject, expandVector, duration * 0.5f, new EaseStateQuad(EaseType.EaseIn));
            var tweenShrink = new TweenScale(targetObject, expandVector, shrinkVector, duration * 0.5f, new EaseStateQuad(EaseType.EaseOut), onComplete);

            var sequence = new Sequence();

            sequence.Append(tweenExpand);
            sequence.Append(tweenShrink);

            sequence.Play();
        }

        public static void Shake(Transform targetObject, Quaternion rot1, Quaternion rot2, float duration, int repeatCount = 1, Action onComplete = null)
        {
            var originalRot = targetObject.rotation.eulerAngles;

            var targetRot = originalRot + rot1.eulerAngles;

            var tweenRotate = new TweenRotate(targetObject, Quaternion.Euler(targetRot), duration * 0.25f, new EaseStateLinear());
            var tweenRotate1 = new TweenRotate(targetObject, Quaternion.Euler(originalRot), duration * 0.25f, new EaseStateLinear());
            var tweenRotate2 = new TweenRotate(targetObject, Quaternion.Euler(rot2.eulerAngles), duration * 0.25f, new EaseStateLinear());
            var tweenRotate3 = new TweenRotate(targetObject, Quaternion.Euler(originalRot), duration * 0.25f, new EaseStateLinear(), onComplete);

            var sequence = new Sequence();

            for (int i = 0; i < repeatCount; i++)
            {
                sequence.Append(tweenRotate);
                sequence.Append(tweenRotate1);
                sequence.Append(tweenRotate2);
                sequence.Append(tweenRotate3);
            }

            sequence.Play();
        }

        public static void ShakeInfinite(Transform targetObject, Quaternion firstRotation, Quaternion secondRotation, float duration)
        {
            var originalRot = targetObject.rotation.eulerAngles;

            var targetRot = originalRot + firstRotation.eulerAngles;

            var tweenRotate = new TweenRotate(targetObject, Quaternion.Euler(targetRot), duration * 0.25f, new EaseStateLinear());
            var tweenRotate1 = new TweenRotate(targetObject, Quaternion.Euler(originalRot), duration * 0.25f, new EaseStateLinear());
            var tweenRotate2 = new TweenRotate(targetObject, Quaternion.Euler(secondRotation.eulerAngles), duration * 0.25f, new EaseStateLinear());
            var tweenRotate3 = new TweenRotate(targetObject, Quaternion.Euler(originalRot), duration * 0.25f, new EaseStateLinear());

            var sequence = new Sequence();

            sequence.Append(tweenRotate);
            sequence.Append(tweenRotate1);
            sequence.Append(tweenRotate2);
            sequence.Append(tweenRotate3);

            tweenRotate3.AddAction(() =>
            {
                if (targetObject.gameObject.activeSelf)
                    ShakeInfinite(targetObject, firstRotation, secondRotation, duration);
            });

            sequence.Play();
        }

        public static void Repeat(ITweenable tweenToRepeat, int repeatCount)
        {
            if (repeatCount < 1) return;

            var sequence = new Sequence();

            for (int i = 0; i < repeatCount; i++)
            {
                sequence.Append(tweenToRepeat);
            }

            sequence.Play();
        }

        public static void RepeatInfinite(ITweenable tweenToRepeat)
        {
            tweenToRepeat.AddAction(() => { TweenManager.Instance.AddTween(tweenToRepeat); });

            TweenManager.Instance.AddTween(tweenToRepeat);
        }

    }
}
