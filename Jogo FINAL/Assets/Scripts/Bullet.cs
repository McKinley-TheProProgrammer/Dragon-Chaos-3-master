using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    
    int speed = 7;
    public GameObject player;
    public Transform posPlayer;
    public Vector2 alvo;

    private void Start()
    {
        posPlayer = PlayerMovement.Instance.transform;

        alvo = new Vector2(posPlayer.position.x, posPlayer.position.y);
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Player") && player.GetComponent<PlayerDamage>().imortal == false)
        {
            DestroiBala();
            hit.gameObject.SetActive(false);
            GameManager.Instance.Coroutine();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvo, speed * Time.deltaTime);
        if (transform.position.x == alvo.x && transform.position.y == alvo.y)
            DestroiBala();
    }
    void DestroiBala()
    {
        Destroy(gameObject);
    }
}
