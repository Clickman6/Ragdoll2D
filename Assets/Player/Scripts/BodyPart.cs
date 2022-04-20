using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BodyPart : MonoBehaviour {
    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetDynamic() {
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
