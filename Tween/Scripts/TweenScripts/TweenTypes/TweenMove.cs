using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevBird.Tween
{
    public class TweenMove : TweenBase<Transform>
    {
        private Vector3 targetPosition;
        private Vector3 startPosition;

        public TweenMove(Transform targetObject, Vector3 targetPosition, float totalDuration, IEaseState easeState, Action onComplete = null)
            : base(totalDuration, easeState, onComplete)
        {
            this.startPosition = targetObject.transform.position;
            this.TweenObject = targetObject;
            this.targetPosition = targetPosition;
        }

        public override void Tween()
        {
            base.Tween();

            TweenObject.transform.position = Vector3.Lerp(startPosition, targetPosition, GetEaseValue);
        }
    }
}
