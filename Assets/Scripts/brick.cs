using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class brick : MonoBehaviour
{
    public GameObject[] powers;
    public Sprite[] brickSprites;
    private level myLevel = null;
    private gameStauts myGameStatus = null;

    private int maxHits = 0;
    private int timesHits = 0;

    private void Start()
    {
        myLevel = FindObjectOfType<level>();
        myGameStatus = FindObjectOfType<gameStauts>();
        if(gameObject.tag == "breakable" || gameObject.tag == "Power") myLevel.IncreaseBreakableCounts();
        maxHits = brickSprites.Length+1;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "power-ball") {
            Destroy(gameObject);
            myGameStatus.UpdateScore();
        }
        if(other.gameObject.tag == "Ball" || other.gameObject.tag == "shoot") HandleCollision();        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball" || other.gameObject.tag == "shoot") HandleCollision();        
    }
    private void HandleCollision(){
        // If brick is breakable then based on total hits destroy the brick or show new sprite accordingly
        if(gameObject.tag == "breakable" || gameObject.tag == "Power"){
            timesHits++;        // Every time increase the hit

            if(timesHits >= maxHits){           // Destroy if reach to maxHit level
                if(gameObject.tag == "Power"){
                    int index = Random.Range(0, powers.Length-1);
                    Instantiate(powers[index], gameObject.transform.position, Quaternion.identity);
                }   
                Destroy(gameObject);
                myGameStatus.UpdateScore();
                myLevel.DecreaseBreakableCounts();    
            }
            else{   // Render next sprite
                GetComponent<SpriteRenderer>().sprite = brickSprites[timesHits-1];
            }
        } 
    }
}
