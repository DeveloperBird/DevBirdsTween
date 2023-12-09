using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevBird.Tween
{
    public class TweenScale : TweenBase<Transform>
    {
        private Vector3 targetSize;
        private Vector3 startSize;

        public TweenScale(Transform targetObject, Vector3 targetSize, float totalDuration, IEaseState easeState, Action onComplete = null)
            : base(totalDuration, easeState, onComplete)
        {
            this.startSize = targetObject.localScale;
            this.TweenObject = targetObject;
            this.targetSize = targetSize;
        }

        //Secondary constructor that allows for predetermined starting size.
        public TweenScale(Transform _targetObject, Vector3 _startSize, Vector3 _targetSize, float _totalDuration, IEaseState easeState, Action _onComplete = null)
            : base(_totalDuration, easeState, _onComplete)
        {
            this.startSize = _startSize;
            this.TweenObject = _targetObject;
            this.targetSize = _targetSize;
        }

        public override void Tween()
        {
            base.Tween();

            TweenObject.localScale = Vector3.Lerp(startSize, targetSize, GetEaseValue);
        }

    }
}