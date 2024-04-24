using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    //剛體組件
    private Rigidbody2D rbody;
    //動畫組件
    private Animator ani;
    [Header("跳躍力度"), Range(0, 10)]
    public float jump;
    bool isJumping;
    public GamemanagerSystem gm;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        ani= GetComponent<Animator>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //按下上、space按鍵即可跳躍並判斷是否落地
        if(Input.GetKeyDown(KeyCode.UpArrow)&&isJumping==false)
        {
            
            rbody.velocity = new Vector2 ( 0, jump );
            isJumping = true;
            ani.SetBool("isJump", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {

            rbody.velocity = new Vector2(0, jump);
            isJumping = true;
            ani.SetBool("isJump", true);
        }
        float v = Input.GetAxis("Vertical");
        print($"垂直{v}");
        if (v < 0)
        {
            ani.SetBool("isSquat", true);
        }
        else
        {
            ani.SetBool("isSquat", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        ani.SetBool("isJump", false);
    }
}
