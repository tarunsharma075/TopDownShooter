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
    [SerializeField] private float _moveSpeed = 5f; 
    [SerializeField] private float _rotationSpeed = 200f; 

    [Header("Bullet Settings")]
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform bulletSpawnPoint; 
    [SerializeField] private float defaultFireCooldown = 0.5f; 
    private float fireCooldown = 0.5f; 

    private Rigidbody2D _rigidbody;
    private float _fireTimer = 0f; 
    [SerializeField] private ScoreManager _playerscore;
    [SerializeField] private int _health;
    [SerializeField] private int _maxhealth;
    [SerializeField] private Image _healthbar;
    [SerializeField] private GameObject _mainGameScreen;
    [SerializeField] private GameObject _losegamescreen;
    
 

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
            RefreshHealthBar();
            SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.TankCollison);
            this.transform.position = new Vector3(this.transform.position.x - 2, this.transform.position.y - 2, this.transform.position.z);
           
           
            DecreaseScore();

           
            if (_health <= 0)
            {
                StartCoroutine(PlayerDies());
                
               
            }
        }
    }
    private void HandleMovement()
    {

        float moveInput = Input.GetAxis("Vertical");


        float rotationInput = Input.GetAxis("Horizontal");


        _rigidbody.velocity = transform.up * moveInput * _moveSpeed;


        transform.Rotate(Vector3.forward, -rotationInput * _rotationSpeed * Time.deltaTime);



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
        SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.TankFiring);

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
    private IEnumerator PlayerDies()
    {
        SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.TankDestroy);
        SoundManager.Instance.StopBackGroundMusic();
        yield return new WaitForSeconds(2);
        _mainGameScreen.SetActive(false);
        _losegamescreen.SetActive(true);
        Time.timeScale = 0;
    }
}
