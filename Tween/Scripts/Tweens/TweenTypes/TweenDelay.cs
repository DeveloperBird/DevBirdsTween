using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevBird.Tween
{
    /// <summary>
    /// This class exists as a way to add a delay when sequencing tweens together.
    /// </summary>
    public class TweenDelay : TweenBase<object>
    {
        public TweenDelay(float duration, IEaseState easeState = null) : base(duration, easeState) { }

        public override void Tween()
        {
            base.Tween();
        }
    }
}