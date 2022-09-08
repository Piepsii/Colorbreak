using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventTunnel : MonoBehaviour
{
    public UnityEvent unityEvent;

    public void RaiseEvent()
    {
        unityEvent.Invoke();
    }
}
