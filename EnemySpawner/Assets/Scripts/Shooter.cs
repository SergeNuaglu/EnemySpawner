using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Aiming _aim;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private bool _isShoot;
    private float _timeBeforeDestroy = 5;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isShoot = false;
    }

    private void FixedUpdate()
    {
        if (_isShoot)
        {
            _rigidbody.AddForce(_direction.normalized * _speed);
        }
    }

    public void AllowToShoot()
    {
        _rigidbody.isKinematic = false;
        _direction = _aim.transform.position - transform.position;
        _isShoot = true;
    }

    public void SetAim(Aiming aim)
    {
        _aim = aim;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject, _timeBeforeDestroy);

        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isShoot = false;
        }

        if (collision.collider.GetComponent<NavMeshAgent>())
        {
            Destroy(collision.gameObject);
        }
    }
}
