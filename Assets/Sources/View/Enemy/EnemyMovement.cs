using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Transform _target;
    private float _speed = 1f;

    public void Init(Transform target)
    {
        _target = target;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 positionDifference = (_target.position - transform.position).normalized;
        Vector3 motion = positionDifference * Time.deltaTime * _speed;
        _characterController.Move(motion);
        transform.LookAt(_target);

        if (_characterController.isGrounded == false)
        {
            Vector3 gravity = Physics.gravity * Time.deltaTime;
            _characterController.Move(gravity);
        }
    }
}