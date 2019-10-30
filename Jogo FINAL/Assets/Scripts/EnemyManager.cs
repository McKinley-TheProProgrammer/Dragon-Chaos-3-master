using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies =  new List<GameObject>();
    public Transform spawnEnemyPoint, enemyPoint;
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
            enemyPoint.GetChild(i).position = spawnEnemyPoint.GetChild(i).position;
            enemyPoint.GetChild(i).gameObject.SetActive(true);
            enemyPoint.GetChild(i).gameObject.GetComponent<Renderer>().material.color = new Color(1.000f, 1.000f, 1.000f, 1.000f);
        }
    }
}
