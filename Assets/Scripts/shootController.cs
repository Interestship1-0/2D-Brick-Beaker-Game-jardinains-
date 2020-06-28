using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "breakable" || other.gameObject.tag == "Power") Destroy(gameObject);   
    }
}
