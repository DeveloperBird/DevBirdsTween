using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevBird.Tween
{
    public interface ITweenable
    {
        public void Tween();
        public void AddAction(Action newAction);
    }
}
