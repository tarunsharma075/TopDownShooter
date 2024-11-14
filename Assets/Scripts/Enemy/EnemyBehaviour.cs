using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] _points; // Enemy will be instantiated at these points
    [SerializeField] private GameObject _enemyPrefab; // Reference to the enemy prefab

    private void Start()
    {
        // Start the enemy instantiation coroutine when the game starts
        StartCoroutine(EnemyInstantiation());
    }

    private IEnumerator EnemyInstantiation()
    {
        // Infinite loop to continuously spawn enemies at intervals
        while (true)
        {
            // Loop through each point and instantiate an enemy after a certain delay
            foreach (Transform point in _points)
            {
                // Instantiate enemy at the given point position with default rotation
                Instantiate(_enemyPrefab, point.position, Quaternion.identity);
                yield return new WaitForSeconds(5f);

            }

            // Wait for 10 seconds before starting the next batch of enemies
            yield return new WaitForSeconds(15f);
        }
    }
}
