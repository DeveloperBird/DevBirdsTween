using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevBird.Tween
{
    public class TweenMoveCurve : TweenBase<Transform>
    {
        private Vector3 targetPosition;
        private Vector3 startPosition;
        private float peakHeight;

        public TweenMoveCurve(Transform targetObject, Vector3 targetPosition, float peakHeight, float totalDuration, IEaseState easeState, Action onComplete = null)
            : base(totalDuration, easeState, onComplete)
        {
            this.TweenObject = targetObject;
            this.targetPosition = targetPosition;
            this.peakHeight = peakHeight;
            this.startPosition = targetObject.position;
        }

        public override void Tween()
        {
            base.Tween();

            float yOffset = peakHeight * Mathf.Sin(GetEaseValue * Mathf.PI);

            TweenObject.transform.position = Vector3.Lerp(startPosition, targetPosition, GetEaseValue) + new Vector3(0, yOffset, 0);
        }

    }
}
