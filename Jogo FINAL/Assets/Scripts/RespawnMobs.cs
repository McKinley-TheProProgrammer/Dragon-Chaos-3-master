using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMobs : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.StartRespawningMobs();
        }
        else
        {
            GameManager.Instance.StopCoroutine("RespawningMobs");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       GameManager.Instance.StopCoroutine("RespawningMobs");
    }




}
