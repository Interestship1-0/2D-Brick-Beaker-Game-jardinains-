using UnityEngine;
using UnityEngine.SceneManagement;
public class ball : MonoBehaviour
{
    [SerializeField] paddle myPaddle = null;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] float deviation = 0.2f;
    [SerializeField] string sceneName = "Game Over";
    public int totalBalls = 0;

    public Sprite[] ballTypes;

    Vector2 paddleToBall;
    bool hasStarted = false;
    Rigidbody2D myRigidbody2D = null;

    // Start is called before the first frame update
    void Start()
    {
        totalBalls++;
        paddleToBall = transform.position - myPaddle.transform.position;
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the game has not started then
        if(!hasStarted) {

            // Lock the ball to paddle
            Vector2 paddlePos = new Vector2(myPaddle.transform.position.x, myPaddle.transform.position.y);
            transform.position = paddlePos + paddleToBall;

            // Launch the ball on click
            if(Input.GetMouseButtonDown(0))
            {
                AddVelocity();
                hasStarted = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Death"){
            SceneManager.LoadScene(sceneName);
        }

        Vector2 tweakVelocity = new Vector2(Random.Range(0f, deviation), Random.Range(0f, deviation));
        if(hasStarted){
            myRigidbody2D.velocity += tweakVelocity;
        }
    }

    public void AddVelocity()
    {
        hasStarted = true;
        myRigidbody2D.velocity = new Vector2(velocityX, velocityY);
    }

    public void ChangeGravityScale(float scale){
        Debug.Log(scale);
        myRigidbody2D.gravityScale = scale;
    }
}
