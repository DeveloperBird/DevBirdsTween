using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevBird.Tween
{
    public class TweenRotate : TweenBase<Transform>
    {
        private Quaternion targetRot;
        private Quaternion startRot;

        public TweenRotate(Transform targetObject, Quaternion targetRot, float totalDuration, IEaseState easeState, Action onComplete = null)
            : base(totalDuration, easeState, onComplete)
        {
            this.TweenObject = targetObject;
            this.startRot = targetObject.rotation;
            this.targetRot = targetRot;
        }
        public override void Tween()
        {
            base.Tween();

            TweenObject.rotation = Quaternion.Lerp(startRot, targetRot, GetEaseValue);
        }
    }
}