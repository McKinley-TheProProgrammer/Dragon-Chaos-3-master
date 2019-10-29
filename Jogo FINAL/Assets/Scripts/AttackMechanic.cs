using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AttackMechanic : MonoBehaviour
{
    public UnityEvent flipParticles;
    public AudioClip slash,killGuard;
    public Image barraDeAdrenalina;
    public Animator anim;
    //public Animation attack;
    float enemyDamage;
    public BoxCollider2D colisorDireita;
    public BoxCollider2D colisorEsquerda;
    public string enemyTag;
    public string strongerEnemyTag;
    int danoSET = 3;
    public ParticleSystem enemyTraces;
    public Pooling traces;
    Collider2D enemy;

    public Vector3 posicoesNegativadas;
    
    bool canAttack;

    /*static AttackMechanic instance;
    public static AttackMechanic Instance { get { return instance; } }
    public void Awake()
    {
        instance = this;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        colisorDireita.enabled = false;
        colisorEsquerda.enabled = false;
        barraDeAdrenalina.fillAmount = 0f;
        canAttack = true;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && canAttack)
        {
            anim.SetTrigger("Attack");
            canAttack = false;
            if (anim.isInitialized)
            {
                canAttack = true;
            }
        }
        
        
    }
   
    public void TurnColliderOn()
    {
        GameManager.Instance.SfxPlayer(slash);
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
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(enemyTag))
        {
            enemy = collision;
            barraDeAdrenalina.fillAmount += 0.08f;
            if (GetComponentInParent<SpriteRenderer>().flipX == false)
            {
                GameObject podeUsar = traces.GetPooledObject();
                if (podeUsar != null)
                {
                    podeUsar.transform.position = transform.position;
                    podeUsar.SetActive(true);
                }
                //Instantiate(enemyTraces, collision.transform.position, Quaternion.identity);
            }
            else
            {
                GameObject podeUsar = traces.GetPooledObject();
                if (podeUsar != null)
                {
                    podeUsar.transform.position = transform.position;
                    podeUsar.SetActive(true);
                }
                flipParticles.Invoke();
                //Instantiate(enemyTraces, collision.transform.position, Quaternion.identity);
                
            }
            collision.gameObject.GetComponent<Animator>().enabled = false;
            //collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Instance.SfxPlayer(killGuard);
            iTween.PunchScale(collision.gameObject,new Vector2(3,4),1);
            print(collision.gameObject.GetComponent<Renderer>().material.color);
            iTween.ColorTo(collision.gameObject,new Color(0,0,0,0),.5f);
            iTween.PunchPosition(collision.gameObject, iTween.Hash(
               "amount", new Vector3(1, 2, 0),
               "time", .35f,
               "oncomplete", "DeactivateEnemy",
               "oncompletetarget",gameObject));

            //GameObject.FindWithTag(enemyTag).SetActive(false);
           
            //Invoke("Deactivate", .5f);
            //Destroy(collision.gameObject,.5f);
        }
        /*if (collision.gameObject.CompareTag(strongerEnemyTag))
        {
            danoSET--;
            barraDeAdrenalina.fillAmount += 0.05f;
            Instantiate(enemyTraces, transform.position, Quaternion.identity);
            if(danoSET <= 0)
                Destroy(collision.gameObject);
        }*/
    }
    void DeactivateEnemy()
    {
        Debug.Log("fODASE");
        //if (enemy != null)
        //{
            enemy.GetComponent<FollowTarget>().DeactivateThis();
       // }
    }

}
