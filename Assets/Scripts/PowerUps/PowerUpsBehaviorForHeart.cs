using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsBehaviorForHeart : MonoBehaviour
{

    [SerializeField] private TankController _tank;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<TankController>() != null) {
            
            _tank.IncreaeHealth();
            this.gameObject.SetActive(false);
        }
    }
              
}
