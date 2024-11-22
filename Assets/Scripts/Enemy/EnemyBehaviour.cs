using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] _points; // Enemy will be instantiated at these points
    [SerializeField] private GameObject _enemyPrefab; // Reference to the enemy prefab
    [SerializeField] private Transform _player; // Reference to the player transform
    [SerializeField] private TankController _tank;

    private void Start()
    {
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
                GameObject enemy = Instantiate(_enemyPrefab, point.position, Quaternion.identity);

                // Set the player's transform as the target in the EnemyController script
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.Setplayer(_player);
                    enemyController.SetTank(_tank);
                }

                yield return new WaitForSeconds(2f);
            }

            // Wait for 5 seconds before starting the next batch of enemies
            yield return new WaitForSeconds(5f);
        }
    }
}
