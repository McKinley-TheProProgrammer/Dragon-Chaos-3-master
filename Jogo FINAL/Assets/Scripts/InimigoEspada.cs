using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoEspada : InimigoJoao
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = PlayerDistance();

        isMoving = (distance <= distanceAttack);
        if (isMoving)
        {
            GetComponent<Animator>().SetBool("EnemySpotted", true);
            if ((player.position.x > transform.position.x && sprite.flipX) || (player.position.x < transform.position.x && !sprite.flipX))
            {
                Flip();
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("EnemySpotted", false);
        }
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(speed * 0, rb2d.velocity.y);
        }
        

    }
}
