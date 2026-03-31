using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour

    
{
    public float spd = 1.0f;
    Vector3 direct = Vector3.down;
    // Start is called before the first frame update
    private void Start()
    {
        int rndNum = Random.Range(0, 10);
        if (rndNum < 3)
        {
            GameObject target = GameObject.Find("Character");

            direct = target.transform.position - transform.position;
            direct.Normalize();
        }
    }


    // Update is called once per frame
   // void Update()
   // {
        
  //  }

    private void OnCollisionEnter(Collision collision)
    {
       Destroy(collision.gameObject);

        Destroy(gameObject);
    }
}
