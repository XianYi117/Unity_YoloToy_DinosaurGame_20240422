using UnityEngine;

namespace Xian
{
    /// <summary>
    /// 角色控制系統：控制角色進行動作
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        //剛體組件
        private Rigidbody2D rbody;
        //動畫組件
        private Animator ani;
        [Header("跳躍力度"), Range(0, 10)]
        public float jump;
        bool isJumping;
        [Header("結束畫面")]
        public GameObject gameOverScene;
        // Start is called before the first frame update
        void Start()
        {
            rbody = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
            isJumping = false;
        }

        // Update is called once per frame
        void Update()
        {
            //按下上、space按鍵即可跳躍並判斷是否落地
            if (Input.GetKeyDown(KeyCode.UpArrow) && isJumping == false)
            {

                rbody.velocity = new Vector2(0, jump);
                isJumping = true;
                ani.SetBool("isJump", true);
            }
            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {

                rbody.velocity = new Vector2(0, jump);
                isJumping = true;
                ani.SetBool("isJump", true);
            }
            //判斷 下 鍵值小於0時執行蹲下動畫、大於等於0時關閉蹲下動畫
            float v = Input.GetAxis("Vertical");
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
            //判定當物件觸碰到tag為Mon的物件時
            if(collision.gameObject.CompareTag("Mon"))
            {
                //停止遊戲
                Time.timeScale = 0;
                //將結束畫面顯示
                gameOverScene.SetActive(true);
            }

        }
        
    }
}

