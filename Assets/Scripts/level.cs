using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    public paddle myPaddle;
    private GameObject sheild = null;
    public ball myBall;

    //prefab references
    public GameObject sheildPrefab;
    public GameObject shoot;
    
    public string sceneName = "Game Over";
    

    public float forwardTimeScale = 1f;
    public float backwardTimeScale = 0.4f;
    public float upGravity = 0;
    public float downGravity = 0.5f;

    private void Update() {
        if(isRocket){
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("In If");
                InitiateShoot();
            }
        }
    }

    private int breakableCounts = 0;
    private bool isRocket = false;

    public void IncreaseBreakableCounts(){
        breakableCounts++;
    }

    public void DecreaseBreakableCounts(){
        breakableCounts--;
        if(breakableCounts <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ListenPowerEvents(string power){
        if(power == "rocket"){
            isRocket = true;
            if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[2])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[5];
            }
            else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[1])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[4];
            }
            else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[0])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[3];
            }
        }
        if(power == "shield"){
            if(sheild != null)
            {
                Destroy(sheild);
            }
            sheild = Instantiate(sheildPrefab, sheildPrefab.transform.position, Quaternion.identity);
        }
        if(power == "strech"){
            if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[0])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[1];
            }
            else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[1])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[2];
            }
            
            if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[3])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[4];
            }
            else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[4])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[5];
            }

        }
        if(power == "shrink"){
            if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[2])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[1];
            }
            else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[1])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[0];
            }
            else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[0])
            {
                SceneManager.LoadScene(sceneName);
            }

            if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[5])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[4];
            }
            else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[4])
            {
                myPaddle.GetComponent<SpriteRenderer>().sprite = myPaddle.paddleTypes[3];
            }
            else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[3])
            {
                SceneManager.LoadScene(sceneName);            
            }
        }
        if(power == "plus"){
            for (int i=0; i<myBall.totalBalls; i++)
            {
                ball ballClone = Instantiate(myBall, myBall.transform.position, Quaternion.identity) as ball;
                ballClone.AddVelocity();
            }
        }
        if(power == "forward"){
            Time.timeScale = forwardTimeScale;
        }
        if(power == "backward"){
            Time.timeScale = backwardTimeScale;
        }
        if(power == "power-ball"){
            myBall.GetComponent<SpriteRenderer>().sprite = myBall.ballTypes[1];
            myBall.gameObject.tag = "power-ball";
        }
        if(power == "up"){
            var balls = FindObjectsOfType<ball>();

            for(var i=0; i<balls.Length; i++){
                balls[i].ChangeGravityScale(upGravity);
            }
        }
        if(power == "down"){
            var balls = FindObjectsOfType<ball>();

            for(var i=0; i<balls.Length; i++){
                balls[i].ChangeGravityScale(downGravity);
            }        
        }

        if(power == "stop"){
            SceneManager.LoadScene(sceneName);            
        }
    }

    private void InitiateShoot(){
        if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[3])
        {
            SetShootPrefab(0.57f);
        }
        else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[4])
        {
            SetShootPrefab(0.85f);
        }
        else if (myPaddle.GetComponent<SpriteRenderer>().sprite == myPaddle.paddleTypes[5])
        {
            SetShootPrefab(1.07f);
        }
    }

    void SetShootPrefab(float offset)
    {
        GameObject f1;
        GameObject f2;

        f1 = Instantiate(shoot, new Vector3(myPaddle.transform.position.x + offset,
            myPaddle.transform.position.y, myPaddle.transform.position.z), Quaternion.identity);
        f2 = Instantiate(shoot, new Vector3(myPaddle.transform.position.x - offset,
            myPaddle.transform.position.y, myPaddle.transform.position.z), Quaternion.identity);
        f1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
        f2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
    }
}
