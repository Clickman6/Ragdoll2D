using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimationEvents : MonoBehaviour {
    [SerializeField] private UnityEvent[] _onEvent;

    public void OnEvent(int index) {
        _onEvent[index].Invoke();
    }
}
