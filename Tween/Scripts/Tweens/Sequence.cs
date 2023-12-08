using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevBird.Tween
{
    public class Sequence
    {
        private Queue<ITweenable> Tweens = new Queue<ITweenable>();

        public void Append(ITweenable tween)
        {
            if (!Tweens.Contains(tween))
                tween.AddAction(Play);

            Tweens.Enqueue(tween);
        }


        public void AppendInterval(float duration)
        {
            Tweens.Enqueue(new TweenDelay(duration));
        }

        public void Play()
        {
            if (Tweens.Count == 0) return;
            var tween = Tweens.Dequeue();
            TweenManager.Instance.AddTween(tween);
        }
    }
}