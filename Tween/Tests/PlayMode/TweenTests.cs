using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DevBird.Tween;
public class TweenTests
{
    [UnityTest]
    public IEnumerator TweenMoveTest()
    {
        var tweenManager = new GameObject().AddComponent<TweenManager>();
        var objectToMove = new GameObject();
        var targetPosition = new Vector3(5, 5, 5);
        var targetDuration = 2;

        TweenManager.Instance.AddTween(new TweenMove(objectToMove.transform, targetPosition, targetDuration, new EaseStateLinear()));

        yield return new WaitForSeconds(targetDuration);

        Assert.AreEqual(objectToMove.transform.position, targetPosition);
    }

    [UnityTest]
    public IEnumerator TweenScaleTest()
    {
        var tweenManager = new GameObject().AddComponent<TweenManager>();
        var objectToScale = new GameObject();
        var targetScale = new Vector3(5, 5, 5);
        var targetDuration = 2;

        Tween.Scale(objectToScale.transform, targetScale, targetDuration, new EaseStateLinear());

        yield return new WaitForSeconds(targetDuration);

        Assert.AreEqual(objectToScale.transform.localScale, targetScale);
    }

    [UnityTest]
    public IEnumerator TweenRotateTest()
    {
        var tweenManager = new GameObject().AddComponent<TweenManager>();
        var objectToRotate = new GameObject();
        var targetRotation = Quaternion.Euler(5, 5, 5);
        var targetDuration = 2;

        Tween.Rotate(objectToRotate.transform, targetRotation, targetDuration, new EaseStateLinear());

        yield return new WaitForSeconds(targetDuration);

        Debug.Log(targetRotation + " " + objectToRotate.transform.rotation);

        Assert.AreEqual(objectToRotate.transform.rotation, targetRotation);
    }
}
