using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    [SerializeField] public float screenWidthInUnits = 16f;
    [SerializeField] public float minX = 1f;
    [SerializeField] public float maxX = 15f;
    public Sprite[] paddleTypes;   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePos, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePos, minX, maxX);
        transform.position = paddlePos;       
    }
}
