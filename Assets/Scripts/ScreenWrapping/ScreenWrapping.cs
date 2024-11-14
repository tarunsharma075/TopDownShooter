using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrapping : MonoBehaviour
{

    private Rigidbody2D _playerigidbody;



    private void Awake()
    {
        _playerigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float _rightsideofscreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float _leftsideofscreen = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).x;
        float _topofthescreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float _bottonofthescreen = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).y;
        Vector3 _playerpos = Camera.main.WorldToScreenPoint(this.transform.position);

        if (_playerpos.x > Screen.width)
        {
            this.transform.position = new Vector2(_leftsideofscreen, this.transform.position.y);
        }
        else if (_playerpos.x <= 0)
        {
            this.transform.position = new Vector2(_rightsideofscreen, this.transform.position.y);
        }
        else if (_playerpos.y > Screen.height)
        {
            this.transform.position = new Vector2(this.transform.position.x, _bottonofthescreen);
        }
        else if (_playerpos.y <= 0)
        {
            this.transform.position = new Vector2(this.transform.position.x, _topofthescreen);
        }


    }

}

