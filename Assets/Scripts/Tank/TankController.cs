using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _rotationalspeed;
    [SerializeField] GameObject _bullet;
    //this is the position where our bullet will be instansiated
    private Vector2 _bulletpos;
    // fire rate will let us fire single bullet in half second
    [SerializeField] private float _firerate = 0.5f;
    [SerializeField] private float _nextfire = 0.0f;

    
    void Update()
    {
        // Move the player based on key press
        if (Input.GetKey(KeyCode.W))
        {
            // Move forward in the direction the player is facing
            transform.position += transform.up * _speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Move backward in the direction the player is facing
            transform.position -= transform.up * _speed * Time.deltaTime;
        }

        // Rotate the player based on key press
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -_rotationalspeed * Time.deltaTime); // Rotate clockwise
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, _rotationalspeed * Time.deltaTime); // Rotate counterclockwise
        }

        if (Input.GetKeyDown(KeyCode.Space)&& Time.time>_nextfire){

            _nextfire = Time.time+_firerate;
            Fire();
        }
    }

    private void Fire()
    {
       _bulletpos = this.transform.position;
        Instantiate(_bullet,_bulletpos,this.transform.rotation);
    }
}
