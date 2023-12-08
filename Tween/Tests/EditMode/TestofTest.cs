using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestofTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestofTestSimplePasses()
    {
        // Arrange (setup)
        int a = 2;
        int b = 3;

        // Act (execute)
        int result = a + b;

        // Assert (verify)
        Assert.AreEqual(5, result);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestofTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
