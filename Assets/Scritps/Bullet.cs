using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float spd = 3.5f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * spd *  Time.deltaTime);
    }
}
