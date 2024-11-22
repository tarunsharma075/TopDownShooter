using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpeed : MonoBehaviour
{

    [SerializeField] private TankController _tank;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _tank.DecreaseBulletRate();
        this.gameObject.SetActive(false);
    }
}
