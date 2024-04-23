using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [Header("場景移動速度"), Range(0,10)]
    public float movementSpeed;
    [Header("場景重生位置"), Tooltip("場景消失後重新生成的位置")]
    public float startPosition;
    [Header("場景消失位置"), Tooltip("場景移動後卸載的位置")]
    public float endPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector2( transform.position.x -movementSpeed * Time.deltaTime, transform.position.y );

        if( transform.position.x <= endPosition) 
        {
            transform.position = new Vector2( startPosition,transform.position.y );
        }
    }
}
