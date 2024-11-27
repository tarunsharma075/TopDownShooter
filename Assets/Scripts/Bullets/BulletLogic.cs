using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed; // Speed of the bullet
    
    private Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        // Set initial velocity based on the bullet's facing direction
        _rigidBody.velocity = transform.up * _bulletSpeed;
    }

  

 
}
