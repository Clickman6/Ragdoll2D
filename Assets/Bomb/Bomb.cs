using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Bomb : MonoBehaviour {
    [SerializeField] private float _explosionRadius;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _effector;
    private Plane _plane;
    private Camera _camera;
    private bool _enableChangePosition = true;

    private void Start() {
        _camera = Camera.main;
        _plane = new Plane(Vector2.up, Vector3.zero);
        _effector.SetActive(false);
    }

    private void Update() {
        if (!_enableChangePosition) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = _camera.ScreenPointToRay(mousePosition);

        _plane.Raycast(ray, out float distance);

        Vector2 point = ray.GetPoint(distance);

        transform.position = Vector2.Lerp(transform.position, point, Time.deltaTime * 20f);
    }

    public void Attack(InputAction.CallbackContext context) {
        if (!context.started) return;

        DisableInput();
        _animator.SetTrigger("Attack");
    }

    public void Explosion() {
        _effector.SetActive(true);

        Body player = FindObjectOfType<Body>();

        if (Vector2.Distance(transform.position, player.transform.position) <= _explosionRadius) {
            player.SetDynamic();
        }

        Invoke(nameof(Reset), 0.25f);
    }

    private void Reset() {
        _effector.SetActive(false);
    }

    public void EnableInput() {
        _enableChangePosition = true;
    }

    public void DisableInput() {
        _enableChangePosition = false;
    }
}
