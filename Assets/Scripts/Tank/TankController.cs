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
    [SerializeField] private int _maxhealth=100;
    [SerializeField] private Image _healthbar;
    [SerializeField] private GameObject _mainGameScreen;
    [SerializeField] private GameObject _losegamescreen;
    [SerializeField] private GameObject _textForSpaceHitInstructions;




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

            if(LevelManager.Instance.GetLevel() == LevelManager.Level.LevelOne){
                _health -= 10;
            }else if(LevelManager.Instance.GetLevel() == LevelManager.Level.LevelTwo)
            {
                _health -= 15;
            }else if(LevelManager.Instance.GetLevel() == LevelManager.Level.LevelThree)
            {
                _health -= 20;
            }
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

        float moveInput = Input.GetAxisRaw("Vertical");


        float rotationInput = Input.GetAxisRaw("Horizontal");


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
        if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelOne)
        {
            _playerscore.IncreaseScore(100); // Increase score
        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelTwo)
        {
            _playerscore.IncreaseScore(150); 
        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelThree)
        {
            _playerscore.IncreaseScore(200); 
        }
        
    }

    private void DecreaseScore()
    {
        if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelOne)
        {
            _playerscore.DecreaseScore(10); // Decrease score
        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelTwo)
        {
            _playerscore.DecreaseScore(50); // Decrease score
        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelThree)
        {
            _playerscore.DecreaseScore(100); // Decrease score
        }
       
    }

    private void RefreshHealthBar()
    {
        _healthbar.fillAmount = Mathf.Clamp((float)_health / _maxhealth, 0, 1); // Update health bar
    }

    //public  void DecreaseBulletRate()
    //{
    //    // for a given amount of time the rate of fire will be decrease
    //    StartCoroutine(BulletRateDecrease());
    //}

    //private IEnumerator BulletRateDecrease()
    //{
    //    fireCooldown = 0.02f;
    //    _textForSpaceHitInstructions.SetActive(true);
    //    yield return new WaitForSeconds(3f);
    //    fireCooldown = defaultFireCooldown;
    //    _textForSpaceHitInstructions.SetActive(false);
        
    //}
    private IEnumerator PlayerDies()
    {
        SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.TankDestroy);
        SoundManager.Instance.StopBackGroundMusic();
        yield return new WaitForSeconds(2);
        _mainGameScreen.SetActive(false);
        _losegamescreen.SetActive(true);
        Time.timeScale = 0;
    }

    public  void IncreaeHealth()
    {
        if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelOne)
        {
            _health += 10;
        }else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelTwo)
        {
            _health += 20;
        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelThree)
        {
            _health += 25;
        }
            RefreshHealthBar();
        if (_health > _maxhealth) { 
        _health= _maxhealth;
            RefreshHealthBar() ;
        
        }
    }
}
