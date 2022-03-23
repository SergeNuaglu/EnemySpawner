using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Transform _target;
    private Vector3 _direction;
    private bool _isShoot;
    private const string _targetTag = "Aim";
    private const string _groundTag = "Ground";
    private float _timeBeforeDestroy = 5;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();       
        _target = GameObject.FindGameObjectWithTag(_targetTag).GetComponent<Transform>();
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
        _direction = _target.position - transform.position;
        _isShoot = true;        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject, _timeBeforeDestroy);

        if (collision.collider.gameObject.tag == _groundTag)
        {           
            _isShoot = false;
        }

        if (collision.collider.GetComponent<NavMeshAgent>())
        {
            Destroy(collision.gameObject);
        }
    }
}
