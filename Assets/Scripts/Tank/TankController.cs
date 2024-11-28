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
   // for tank movement abnd rottaion 
    [SerializeField] private float _moveSpeed = 5f; 
    [SerializeField] private float _rotationSpeed = 200f; 

  
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform bulletSpawnPoint; 
    private float fireCooldown ;

    private Rigidbody2D _rigidbody;
    private float _fireTimer = 0f; 
    [SerializeField] private ScoreManager _playerScore;
    [SerializeField] private int _health;
    [SerializeField] private int _maxhealth=100;
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _mainGameScreen;
    [SerializeField] private GameObject _loseGameScreen;
   
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelOne)
        {
            fireCooldown = 0.05f;
        }else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelTwo)
        {
            fireCooldown = 0.04f;
        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelThree)
        {

            fireCooldown = 0.03f;

        }

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
        int scoreIncrease = 0;
        switch (LevelManager.Instance.GetLevel())
        {
            case LevelManager.Level.LevelOne:
                scoreIncrease = 100;
                break;
            case LevelManager.Level.LevelTwo:
                scoreIncrease = 150;
                break;
            case LevelManager.Level.LevelThree:
                scoreIncrease = 200;
                break;
        }
        _playerScore.IncreaseScore(scoreIncrease);
    }
    public  void DecreaseScore()
    {
        int scoreDecrease = 0;
        switch (LevelManager.Instance.GetLevel())
        {
            case LevelManager.Level.LevelOne:
                scoreDecrease = 10;
                break;
            case LevelManager.Level.LevelTwo:
                scoreDecrease = 50;
                break;
            case LevelManager.Level.LevelThree:
                scoreDecrease = 100;
                break;
        }
        _playerScore.DecreaseScore(scoreDecrease);
    }

    private void RefreshHealthBar()
    {
        _healthBar.fillAmount = Mathf.Clamp((float)_health / _maxhealth, 0, 1); // Update health bar
    }

    private IEnumerator PlayerDies()
    {
        SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.TankDestroy);
        SoundManager.Instance.StopBackGroundMusic();
        yield return new WaitForSeconds(2);
        _mainGameScreen.SetActive(false);
        _loseGameScreen.SetActive(true);
       
    }

    public void IncreaseHealth()
    {
        int healthIncrease = 0;
        switch (LevelManager.Instance.GetLevel())
        {
            case LevelManager.Level.LevelOne:
                healthIncrease = 10;
                break;
            case LevelManager.Level.LevelTwo:
                healthIncrease = 20;
                break;
            case LevelManager.Level.LevelThree:
                healthIncrease = 25;
                break;
        }

        _health += healthIncrease;
        if (_health > _maxhealth)
        {
            _health = _maxhealth;
        }
        RefreshHealthBar();
    }
}
