using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public GameObject pooledObject;
    public int nObjects;

    List<GameObject> listOfDeactivatedParticles = new List<GameObject>();

    public bool vaiCrescer;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < nObjects; i++)
        {
            GameObject particle = Instantiate(pooledObject);
            particle.SetActive(false);
            listOfDeactivatedParticles.Add(particle);
        }
        
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < listOfDeactivatedParticles.Count; i++)
        {
            if (!listOfDeactivatedParticles[i].activeInHierarchy)
            {
                return listOfDeactivatedParticles[i];
            }
        }
        if (vaiCrescer)
        {
            GameObject particle = Instantiate(pooledObject);
            listOfDeactivatedParticles.Add(particle);
            return particle;
        }
        return null;
    }
}
