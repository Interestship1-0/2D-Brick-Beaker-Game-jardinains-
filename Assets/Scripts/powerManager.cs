using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerManager : MonoBehaviour {

    private level levelManager;
   
    private void Start()
    {
        levelManager = FindObjectOfType<level>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Paddle")
        {
            Debug.Log(gameObject.tag);
            levelManager.ListenPowerEvents(gameObject.tag);
            Destroy(gameObject);
        }
            
    }
}
