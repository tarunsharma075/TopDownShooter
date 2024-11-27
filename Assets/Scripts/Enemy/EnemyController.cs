using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyController : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float speed;
    private int _health = 3;
    private TankController _tank;
    private void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with a Bullet (having BulletLogic component)
        if (collision.gameObject.GetComponent<BulletLogic>() != null)
        {
            _health--;
            SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.EnemyHit);
           

            Destroy(collision.gameObject); 

            if (_health <= 0)
            {
                
                _tank.IncreaseScore();
                SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.EnemyDestroy);
                Destroy(gameObject);
            }
          
            
        }
    }

    void Update()
    {
        // If the target is not set, do nothing
        if (_target == null)
            return;

        // Move the enemy toward the target
        transform.position = Vector2.MoveTowards(this.transform.position, _target.transform.position, speed * Time.deltaTime);

        // Calculate the direction to the target
        Vector3 direction = _target.transform.position - transform.position;

        // Calculate the angle in degrees needed to rotate toward the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void Setplayer(Transform target)
    {
        _target = target;
    }

  public void SetTank(TankController Tank)
    {
        _tank = Tank;
        if (_tank == null)
        {
            Debug.LogError("Tank reference is null!");
        }
    }
}
