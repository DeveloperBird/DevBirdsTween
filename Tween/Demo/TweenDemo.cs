using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevBird.Tween;
public class TweenDemo : MonoBehaviour
{
    public List<Transform> cubes = new List<Transform>();

    public bool isTweenDemo;

    void Start()
    {
        if (isTweenDemo)
        {
            Tween.PopShrink(cubes[0], 3, 0.1f, 5);
            Tween.MoveAlongCurve(cubes[1], cubes[1].position + new Vector3(5, 0, 0), 5, 3, new EaseStateSine(EaseType.EaseInEaseOut));
            Tween.Scale(cubes[2], new Vector3(3, 1, 2), 5, new EaseStateQuad(EaseType.EaseOut));
            Tween.Rotate(cubes[3], Quaternion.Euler(250, 100, 50), 5, new EaseStateLinear());
        }
        else
        {
            Tween.Move(cubes[0], cubes[0].position + new Vector3(15, 0, 0), 5, new EaseStateLinear());
            Tween.Move(cubes[1], cubes[1].position + new Vector3(15, 0, 0), 5, new EaseStateQuad(EaseType.EaseInEaseOut));
            Tween.Move(cubes[2], cubes[2].position + new Vector3(15, 0, 0), 5, new EaseStateSine(EaseType.EaseInEaseOut));
            Tween.Move(cubes[3], cubes[3].position + new Vector3(15, 0, 0), 5, new EaseStateCirc(EaseType.EaseInEaseOut));
        }
    }

}
