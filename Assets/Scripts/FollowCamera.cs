using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FollowCamera : MonoBehaviour {
    [SerializeField] private Transform _target;

    private void LateUpdate() {
        transform.position = _target.position;
    }
}
