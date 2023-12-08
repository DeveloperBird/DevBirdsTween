using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DevBird.Tween
{
    public class TweenManager : MonoBehaviour
    {
        #region Singleton Instance
        private static TweenManager _instance;

        public static TweenManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TweenManager>();
                    if (_instance == null)
                    {
                        GameObject tweenManagerObject = new GameObject("TweenManager");
                        _instance = tweenManagerObject.AddComponent<TweenManager>();
                    }
                }
                return _instance;
            }
        }
        #endregion

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        private HashSet<ITweenable> Tweens = new HashSet<ITweenable>();

        public void AddTween(ITweenable tween)
        {
            Tweens.Add(tween);

            tween.AddAction(()=> RemoveTween(tween));
        }
        
        public void RemoveTween(ITweenable tween)
        {
            Tweens.Remove(tween);
        }

        void Update()
        {
            if (Tweens.Count == 0) return;

            foreach (var tween in Tweens.ToList())
            {
                tween.Tween();
            }
        }
    }
}
