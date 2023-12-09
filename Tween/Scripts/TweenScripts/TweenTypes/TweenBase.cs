using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevBird.Tween
{

    /// <summary>
    /// High level module of the Tweens. Handles increasing the elapsed duration,
    /// and triggering an Action on the Tween's completion.
    /// </summary>
    public abstract class TweenBase<T> : ITweenable
    {
        private float elapsedDuration;
        private float totalDuration;
        private IEaseState easeState;
        private Action onComplete;
        public T TweenObject { get; set; }

        public TweenBase(float totalDuration, IEaseState easeState, Action onComplete = null)
        {
            this.elapsedDuration = 0;
            this.totalDuration = totalDuration;
            this.easeState = easeState;
            this.onComplete = onComplete;
        }

        public void AddAction(Action newAction)
        {
            this.onComplete += newAction;
        }

        public virtual void Tween()
        {
            if (TweenObject == null)
            {
                Debug.LogWarning("Tween Object not found.");

                return;
            }

            IncreaseElapsedTime();

            TriggerOnComplete();
        }

        void IncreaseElapsedTime()
        {
            elapsedDuration += Time.deltaTime;
        }

        public float GetEaseValue
        {
            get
            {
                return easeState.GetValue(GetPercentDuration);
            }
        }

        float GetPercentDuration
        {
            get
            {
                return Mathf.Clamp01(elapsedDuration / totalDuration);
            }
        }

        void TriggerOnComplete()
        {
            var isTweenCompleted = GetPercentDuration == 1;

            if (isTweenCompleted)
            {
                onComplete?.Invoke();
            }
        }
    }
}
