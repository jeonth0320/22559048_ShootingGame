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

    public GameObject prefabsExplosion;


    // Update is called once per frame
    // void Update()
    // {

    //  }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();
            scoreManager.nowScore++;
            scoreManager.nowScoreUI.text = "Now Score:" + scoreManager.nowScore;

            if(scoreManager.nowScore > scoreManager.bestScore)
            {
                scoreManager.bestScore = scoreManager.nowScore;
                scoreManager.bestScoreUI.text = "Best Score:" + scoreManager.bestScore;
                PlayerPrefs.SetInt("BestScore", scoreManager.bestScore);
            }

            GameObject explosionObj = Instantiate(prefabsExplosion);
            explosionObj.transform.position = transform.position;
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
