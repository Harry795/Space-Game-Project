using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;
    private ScoreScript scoreScript;
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    float invulnAnimTimer=-0;

    SpriteRenderer spriteRend;

     void Start(){
        correctLayer = gameObject.layer;

        //NOTE! This only gets the renderer on the parent objcet.
        // In other words, it doesn't work for children. I.E "Enemy"
        spriteRend = GetComponent<SpriteRenderer>();
        
        if(spriteRend == null){
            Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger!");
        scoreScript = GameObject.Find("ScoreScript").GetComponent<ScoreScript>();
        if (invulnTimer <= 0){
            health--;
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
    }

     void Update(){

        if (invulnTimer > 0){
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if (spriteRend != null){
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);


     }
}
