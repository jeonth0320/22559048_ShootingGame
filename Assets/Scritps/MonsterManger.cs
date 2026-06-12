using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManger : MonoBehaviour
{
    //오브젝트 풀 크기
    public int poolSize = 10;

    //오브젝트 풀장
    //GameObject[] monsterObjectPool;
    public List<GameObject> monsterObjectPool;


    //출현위치들.....
    public Transform[] spawnPoints;

    public GameObject prefabMonster;

    float nowTime;

    float minTime = 1f;
    float maxTime = 5f; 

    public float createTime = 1f;

    private void Start()
    {
        //몬스터 담을 오브젝트 풀을 지정한 크기만큼으로 만든다. 
        // monsterObjectPool = new GameObject[poolSize];
        monsterObjectPool = new List<GameObject>();


        //오브젝트 풀에 몬스터를 차례대로 반복적으로 넣기
        for (int i=0; i<poolSize; i++)
        {
            //프리펩에서 몬스터를 복사
            GameObject monster = Instantiate(prefabMonster);

            //오브젝트 풀에 몬스터를 넣기
            //monsterObjectPool[i] = monster;
            monsterObjectPool.Add(monster);

            //비활성화
            monster.SetActive(false);
        }

    }



    private void Update()
    { 
        nowTime += Time.deltaTime;

        if (nowTime > createTime)
        {
            //몬스터 풀장에 false 있는지 확인, 왜냐 있으면 false 
            if(monsterObjectPool.Count > 0)
            {
                //다 false 첫번째를 사용
                GameObject monster = monsterObjectPool[0];
                monsterObjectPool.Remove(monster);

                //위치
                int index = Random.Range(0, spawnPoints.Length);

                monster.transform.position = spawnPoints[index].position;
                //활성화
                monster.SetActive(true);
                nowTime = 0;
                createTime = Random.Range(minTime, maxTime);
            } else
            {

                //프리펩에서 몬스터를 복사
                GameObject monster = Instantiate(prefabMonster);

                //오브젝트 풀에 몬스터를 넣기
                //monsterObjectPool[i] = monster;
                monsterObjectPool.Add(monster);

                //비활성화
                monster.SetActive(false);
            }
        } 

    }
}
