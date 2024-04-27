using UnityEngine;

namespace Xian
{
    
    /// <summary>
    /// 角色控制系統：控制角色進行動作
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        // 剛體組件
        private Rigidbody2D rbody;
        // 動畫組件
        private Animator ani;
        [Header("跳躍力度"), Range(0, 10)]
        public float jump;
        [Header("蹲下速度"), Range(0, 10)]
        public float squatSpeed;
        bool isJumping;
        bool isSquatting;
        [Header("結束畫面")]
        public GameObject gameOverScene;
        // 添加了 BoxCollider2D 引用，用於控制角色的碰撞器
        public BoxCollider2D boxCollider;

        // 添加了蹲下時和站立時的 Collider 大小變數
        Vector2 standingSize;
        Vector2 crouchingSize = new Vector2(0.1727118f, 0.1698162f);

        // 添加了蹲下時和站立時的 Collider 中心點偏移變數
        Vector2 standingOffset;
        Vector2 crouchingOffset = new Vector2(0.009711877f, -0.0790083f);

        private void Awake()
        {
            // 在 Awake 中獲取組件，以確保按鈕事件能夠正確註冊
            rbody = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
            isJumping = false;
            isSquatting = false;

            // 獲取初始的站立時 Collider 的大小和中心點偏移
            standingSize = boxCollider.size;
            standingOffset = boxCollider.offset;
        }

        // Update is called once per frame
        void Update()
        {
            // 按下上、space按鍵即可跳躍並判斷是否落地
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && !isJumping)
            {
                Jump();
            }

            // 判斷 下 鍵值小於0時執行蹲下動畫、大於等於0時關閉蹲下動畫
            float v = Input.GetAxis("Vertical");
            if (v < 0)
            {
                Squat();
            }
            else
            {
                StandUp();
            }
        }

        // 新增的函數，處理跳躍功能
        public void Jump()
        {
            rbody.velocity = new Vector2(0, jump);
            isJumping = true;
            ani.SetBool("isJump", true);

        }

        // 新增的函數，處理蹲下功能
        public void Squat()
        {
            Debug.Log("呼叫成功");
            if (!isSquatting)
            {
                // 蹲下時降低速度
                rbody.velocity /= squatSpeed;
                isSquatting = true;
                ani.SetBool("isSquat", true);

                // 蹲下時設置 Collider 的大小和中心點偏移
                boxCollider.size = crouchingSize;
                boxCollider.offset = crouchingOffset;
            }
        }

        // 新增的函數，處理站起來功能
        public void StandUp()
        {
            if (isSquatting)
            {
                // 站起來時恢復速度
                rbody.velocity *= squatSpeed;
                isSquatting = false;
                ani.SetBool("isSquat", false);

                // 站起來時恢復 Collider 的大小和中心點偏移
                boxCollider.size = standingSize;
                boxCollider.offset = standingOffset;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            isJumping = false;
            ani.SetBool("isJump", false);
            // 判定當物件觸碰到tag為Mon的物件時
            if (collision.gameObject.CompareTag("Mon"))
            {
                // 停止遊戲
                Time.timeScale = 0;
                // 將結束畫面顯示
                gameOverScene.SetActive(true);
            }
        }

    }
}

