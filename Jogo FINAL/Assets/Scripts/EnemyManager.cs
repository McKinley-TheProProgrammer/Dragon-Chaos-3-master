using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies =  new List<GameObject>();
    public Transform spawnEnemyPoint, enemyPoint, startRespawningMobsPoint;
    static EnemyManager instance;
    public static EnemyManager Instance { get { return instance; } }
    
    
    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            enemies.Add(child.gameObject);
        }
    }
    
    public void SetEnemyToSpawn()
    {
        for (int i = 0; i < enemyPoint.childCount; i++)
        {
            //Debug.Log(i);
            if(spawnEnemyPoint.childCount >= spawnEnemyPoint.childCount)
            {
                enemyPoint.GetChild(i).position = spawnEnemyPoint.GetChild(Random.Range(0,spawnEnemyPoint.childCount)).position;
            }else
            {
                enemyPoint.GetChild(i).position = spawnEnemyPoint.GetChild(i).position;
            }
            enemyPoint.GetChild(i).gameObject.SetActive(true);
            iTween.ColorTo(transform.GetChild(i).gameObject, Color.white, .1f);
            enemyPoint.GetChild(i).gameObject.GetComponent<Animator>().enabled = true;
            //iTween.ColorTo(enemyPoint.GetChild(i).gameObject, new Color(0, 0, 0, 255), .5f);
        }
    }
    
}
