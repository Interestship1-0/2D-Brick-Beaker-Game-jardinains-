using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toy : MonoBehaviour{    
    public Sprite toySprite;
    public brick parentBrick;
    private bool isFallen = false;
    private int totalHits = 0;
    Rigidbody2D myRigidbody2D = null;

    public GameObject[] powers;

    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] float deviation = 0.2f;
    [SerializeField] float delay = 1f;
    [SerializeField] int requiredHits = 3;

    void Start()
    {
        StartCoroutine(LateCall());
    }

    private void Update() {
        if(parentBrick == null && !isFallen) enableRigidbody();    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {           
        if(!isFallen){
            enableRigidbody();
        }   

        Vector2 tweakVelocity = new Vector2(Random.Range(0f, deviation), Random.Range(0f, deviation));
        if(isFallen){
            if(other.gameObject.name == "Paddle"){
                totalHits++;
                if(totalHits >= requiredHits){
                    int index = Random.Range(0, powers.Length-1);
                    Instantiate(powers[index], gameObject.transform.position, Quaternion.identity);
                    Destroy(gameObject);
                } 
            }
            myRigidbody2D.velocity += tweakVelocity;
        }        
    }

    private void enableRigidbody(){
        myRigidbody2D.velocity = new Vector2(velocityX, velocityY);
        isFallen = true;
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(delay); 
        GetComponent<SpriteRenderer>().sprite = toySprite;

        gameObject.SetActive(true);
    }
}
