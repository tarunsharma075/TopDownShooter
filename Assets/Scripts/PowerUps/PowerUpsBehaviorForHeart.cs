using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsBehaviorForHeart : MonoBehaviour
{

    [SerializeField] private TankController _tank;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<TankController>() != null) {

            Debug.Log("hit");
            _tank.IncreaseHealth();
            this.gameObject.SetActive(false);
        }
    }
              
}
