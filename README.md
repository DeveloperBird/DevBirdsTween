# DevBirdsTween

DevBirdsTween is a lightweight Unity library crafted to streamline the manipulation of object transforms during runtime. Say goodbye to cumbersome code for basic animations – DevBirdsTween allows you to effortlessly achieve dynamic animations with just a single line of code.

Unlock the potential for seamless object animations, enhance your Unity development workflow, and experience the power of DevBirdsTween for efficient, hassle-free animations.

### Example of Boxes moving using Tween.Move() with different Easing types.

![](https://i.imgur.com/OWhFfgG.gif)

### Example of different animations by chaining together Tweens.

![](https://i.imgur.com/iO3IVGw.gif)

## How to Install
1. Clone the project.
2. Extract the project.
3. Move the **Tween** folder into the **Asset** folder in your Unity project.

## How to Use Tweens
1. Open a new script in Unity.
2. Obtain a reference to the object you wish to Tween.
3. Call the desired Tween method (e.g., Tween.Move()).
4. Populate the required parameters.
5. Execute the method.

### Example Code using Tween

```csharp
using System;

class ExampleClass : MonoBehaviour
{
    void Start()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var targetPosition = new Vector3(15, 25, 10);
        var duration = 5;
        var easeState = new EaseStateSine(EaseType.EaseOut);

        Tween.Move(cube.transform, targetPosition, duration, easeState, () => { Debug.Log("Tween has completed!"); });
        
    }
}
```

In this example, a cube is created and moved to a specified position over a 5-second duration. The cube will ease out, and the message "Tween has completed!" will be logged after the tweening is finished.

## How to create your own Custom Preset Tweens

You can craft your own premade tween methods by adding a method inside the Tween script. Optionally, you can create an extension method to separate your methods from the core library.

Premade tweens involve chaining tweens together. This can be accomplished easily by using the Sequence class. Here is an example of chaining tweens together:
```csharp
        public void PopShrink(Transform targetObject, float expandSize, float shrinkSize, float duration, Action onComplete = null)
        {
            var expandVector = Vector3.Scale((Vector3.one * expandSize), targetObject.localScale);
            var shrinkVector = Vector3.Scale((Vector3.one * shrinkSize), targetObject.localScale);

            var tweenExpand = new TweenScale(targetObject, expandVector, duration * 0.5f, new EaseStateQuad(EaseType.EaseIn));
            var tweenShrink = new TweenScale(targetObject, expandVector, shrinkVector, duration * 0.5f, new EaseStateQuad(EaseType.EaseOut), onComplete);

            var sequence = new Sequence();

            sequence.Append(tweenExpand);
            sequence.Append(tweenShrink);

            sequence.Play();
        }
 ```

In this example we first create a tween and store it as a variable. Next, create a new sequence. This sequence class can hold tweens and will play them in order after calling the Play() method. 
Done! Now you can create methods with premade sequence of tweens for your convenience. 
This "PopShrink" method will scale an object to the first vector and then afterwards to a second vector. An example of using this method is when you want to click on an object and then make it disappear.
It'd be boring to just deactivate the object on click. Instead, we can call the PopShrink method and expand the object and then shrink it to a vector 0. You can also fill in the optional onComplete parameter 
to deactive the object on the Tweens completion. 

## License

DevBirdsTween is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


