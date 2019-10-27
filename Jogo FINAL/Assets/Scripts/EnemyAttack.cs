﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public AudioClip slashEnemy;
    public bool isInRangeLeft;
    public bool enabledAttack;
    public float timer;
    public Transform posAtaque;
    public float raioDeAtaque;
    public BoxCollider2D colisorDireita;
    public BoxCollider2D colisorEsquerda;
    public LayerMask enemies;
    
    Animator ataque;
    void Start()
    {
        enabledAttack = true;
        colisorDireita.enabled = false;
        colisorEsquerda.enabled = false;
        ataque = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D ataque)
    {
        
        if (ataque.CompareTag("Player") && (isInRangeLeft) && ataque.GetComponent<PlayerDamage>().imortal == false)
        {
            Debug.Log("Tei Matei");
            ataque.gameObject.SetActive(false);
            GameManager.Instance.Coroutine();
        }
    }

    void Update()
    {
        //(new Vector2(posAtaque.localPosition.x + (posAtaque.localPosition.x* -33), posAtaque.position.y), raioDeAtaque, enemies);
        isInRangeLeft = Physics2D.OverlapCircle(posAtaque.position, raioDeAtaque, enemies);
       
        
        if (isInRangeLeft)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                enabledAttack = true;
                timer = 0.9f;

            }
            /*if (!enabledAttack)
            {
                timer -= Time.deltaTime;
            }*/
            if (enabledAttack)
            {
                ataque.SetTrigger("Attack");
                enabledAttack = false;
            }
            
        }
    }
    public void TurnColliderOn()
    {
        GameManager.Instance.SfxPlayer(slashEnemy);
        if (gameObject.GetComponentInParent<SpriteRenderer>().flipX == true)
            colisorDireita.enabled = true;
        if (gameObject.GetComponentInParent<SpriteRenderer>().flipX == false)
            colisorEsquerda.enabled = true;
    }
    public void TurnColliderOff()
    {
        colisorDireita.enabled = false;

        colisorEsquerda.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(posAtaque.position, raioDeAtaque);
        
    }
    
}