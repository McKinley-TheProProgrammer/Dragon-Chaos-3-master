using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies =  new List<GameObject>();

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
