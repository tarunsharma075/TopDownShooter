using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float speed;

    void Update()
    {
        // Move the enemy toward the target
        transform.position = Vector2.MoveTowards(this.transform.position, _target.transform.position, speed * Time.deltaTime);

        // Calculate the direction to the target
        Vector3 direction = _target.transform.position - transform.position;

        // Calculate the angle in degrees needed to rotate toward the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
