using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrapping : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Camera _camera;

    // Boundaries of the screen
    private float _screenWidth;
    private float _screenHeight;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Update()
    {
        // Get screen bounds
        _screenWidth = _camera.orthographicSize * _camera.aspect;
        _screenHeight = _camera.orthographicSize;

        // Get the player's position in world space
        Vector3 playerPosition = transform.position;

        // Check for screen wrapping (X axis)
        if (playerPosition.x > _screenWidth)
        {
            transform.position = new Vector3(-_screenWidth, playerPosition.y, playerPosition.z);
        }
        else if (playerPosition.x < -_screenWidth)
        {
            transform.position = new Vector3(_screenWidth, playerPosition.y, playerPosition.z);
        }

        // Check for screen wrapping (Y axis)
        if (playerPosition.y > _screenHeight)
        {
            transform.position = new Vector3(playerPosition.x, -_screenHeight, playerPosition.z);
        }
        else if (playerPosition.y < -_screenHeight)
        {
            transform.position = new Vector3(playerPosition.x, _screenHeight, playerPosition.z);
        }
    }
}
