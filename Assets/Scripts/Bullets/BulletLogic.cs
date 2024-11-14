using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed; // Speed of the bullet
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        // Set initial velocity based on the bullet's facing direction
        _rigidbody.velocity = transform.up * _bulletSpeed;
    }
}
