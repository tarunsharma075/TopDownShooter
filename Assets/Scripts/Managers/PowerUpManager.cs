using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _border;
    [SerializeField] private  GameObject _thunderViusal;
    [SerializeField] private GameObject _heartVisual;





    public void SetRandomPositionOfPowerUps()
    {
        Bounds bounds = this._border.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);



    }


    private void Start()
    {
        StartCoroutine(PositionActivationBehaviourFireRate());
       
    }

    private IEnumerator PositionActivationBehaviourFireRate()
    {
        while (true)
        {
            _thunderViusal.SetActive(false);
            _heartVisual.SetActive(false);


            yield return new WaitForSeconds(Random.Range(5, 10));
            _thunderViusal.SetActive(true);
            SetRandomPositionOfPowerUps();
            yield return new WaitForSeconds(Random.Range(10, 15));
            _heartVisual.SetActive(true);
            SetRandomPositionOfPowerUps();

            yield return new WaitForSeconds(10);
        }

    }

    
}
