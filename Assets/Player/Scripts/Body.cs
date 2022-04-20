using UnityEngine;
using UnityEngine.U2D.IK;

public class Body : MonoBehaviour {
    [SerializeField] private Animator _animator;
    [SerializeField] private IKManager2D _ikManager;
    [SerializeField] private BodyPart[] _bodyParts;

    public void SetDynamic() {
        _animator.enabled = false;
        _ikManager.enabled = false;

        for (int i = 0; i < _bodyParts.Length; i++) {
            _bodyParts[i].SetDynamic();
        }
    }
}
