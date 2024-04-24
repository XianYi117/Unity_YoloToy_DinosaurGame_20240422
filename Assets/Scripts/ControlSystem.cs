using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("跳躍力度"), Range(0, 10)]
    public float jump;
    bool isJumping;
    public GamemanagerSystem gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //按下Space按鍵即可跳躍並判斷是否落地
        if(Input.GetKeyDown(KeyCode.Space)&&isJumping==false)
        {
            
            rb.velocity = new Vector2 ( 0, jump );
            isJumping = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;

        if (collision.gameObject.tag == "Mon")
        {
            gm.GameOver();
        }
    }
}
