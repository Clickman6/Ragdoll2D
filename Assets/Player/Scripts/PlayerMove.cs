using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour {
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    private float _movable;
    private int _flipConst = 1;

    public void OnMove(InputAction.CallbackContext input) {
        _movable = input.ReadValue<float>();

        if (Mathf.Abs(_movable) > 0) {
            _animator.SetTrigger(Walk);
        } else {
            _animator.SetTrigger(Idle);
        }

        if (_movable > 0) {
            _flipConst = 1;
        } else if (_movable < 0) {
            _flipConst = -1;
        }

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(_flipConst);
        transform.localScale = scale;
    }

    // private void FixedUpdate() {
    //     _rb.velocity = new Vector2(_movable * _speed, _rb.velocity.y);
    // }

    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Idle = Animator.StringToHash("Idle");
}
