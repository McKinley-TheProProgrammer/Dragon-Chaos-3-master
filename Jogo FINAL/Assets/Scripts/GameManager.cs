using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public Transform spawnPoint,enemySpawnPoint;
    public GameObject[] camera;
    public GameObject enemy;

    private void Awake()
    {
        instance = this;
    }

    public void Coroutine()
    {
        StartCoroutine(Destroyed());

    }
    public void StartRespawningMobs()
    {
        StartCoroutine(RespawningMobs());
    }
    public void SfxPlayer(AudioClip sfx)
    {
        AudioSource audio = GetComponent<AudioSource>();
        sfx.frequency.Equals(Random.value);
        audio.PlayOneShot(sfx);
    }
    public void CineEnabled(GameObject camera)
    {
        camera.SetActive(true);
    }
    public void CineDisabled(GameObject camera)
    {
        camera.SetActive(false);
    }

    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(1f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerMovement.Instance.gameObject.SetActive(true);
        
        //CancelInvoke();
    }
    IEnumerator RespawningMobs()
    {
        EnemyManager.Instance.enemies.Add(enemy);
        Instantiate(enemy, EnemyManager.Instance.startRespawningMobsPoint);

        yield return new WaitForSeconds(3f);
    }






}
