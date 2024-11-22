using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class TankController : MonoBehaviour
{
    [Header("Tank Movement Settings")]
    [SerializeField] private float moveSpeed = 5f; // Speed of tank movement
    [SerializeField] private float rotationSpeed = 200f; // Speed of tank rotation

    [Header("Bullet Settings")]
    [SerializeField] private GameObject bulletPrefab; // Prefab for the bullet
    [SerializeField] private Transform bulletSpawnPoint; // Where bullets spawn
    [SerializeField] private float defaultFireCooldown = 0.5f; // Keep track of the default fire cooldown
    private float fireCooldown = 0.5f; // Time between each bullet fire

    private Rigidbody2D _rigidbody;
    private float _fireTimer = 0f; // Timer to handle fire cooldown
    [SerializeField] private ScoreManager _playerscore;
    [SerializeField] private int _health;
    [SerializeField] private int _maxhealth;
    [SerializeField] private Image _healthbar;
    [SerializeField] private GameObject _mainGameScreen;
    [SerializeField] private GameObject _losegamescreen;
    [SerializeField] private EnemyController _enemycontroller;
 

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

      

    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
          
            _health -= 10; 
            this.transform.position = new Vector3(this.transform.position.x - 2, this.transform.position.y - 2, this.transform.position.z);

            RefreshHealthBar(); 
            DecreaseScore();

           
            if (_health <= 0)
            {
                
                _mainGameScreen.SetActive(false); 
                _losegamescreen.SetActive(true); 
                Time.timeScale = 0;
            }
        }
    }

    private void HandleMovement()
    {
        
        float moveInput = Input.GetAxis("Vertical");

       
        float rotationInput = Input.GetAxis("Horizontal");

       
        _rigidbody.velocity = transform.up * moveInput * moveSpeed;

    
        transform.Rotate(Vector3.forward, -rotationInput * rotationSpeed * Time.deltaTime);
    }

    private void HandleShooting()
    {  _fireTimer += Time.deltaTime;   
        if (Input.GetKeyDown(KeyCode.Space) && _fireTimer >= fireCooldown)
        { FireBullet();
          _fireTimer = 0f;
        }
    }

    private void FireBullet()
    {  
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);  
    }

    public void IncreaseScore()
    {
        _playerscore.IncreaseScore(10); // Increase score
    }

    private void DecreaseScore()
    {
        _playerscore.DecreaseScore(5); // Decrease score
    }

    private void RefreshHealthBar()
    {
        _healthbar.fillAmount = Mathf.Clamp((float)_health / _maxhealth, 0, 1); // Update health bar
    }

    public  void DecreaseBulletRate()
    {
        // for a given amount of time the rate of fire will be decrease
        StartCoroutine(BulletRateDecrease());
    }

    private IEnumerator BulletRateDecrease()
    {
        fireCooldown = 0.02f;
        yield return new WaitForSeconds(2f);
        fireCooldown = defaultFireCooldown;
    }
}
