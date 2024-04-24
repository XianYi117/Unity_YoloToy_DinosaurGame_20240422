using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemanagerSystem : MonoBehaviour
{
    public GameObject[] monster;
    public GameObject spawnPosition;
    public GameObject nowMonster;
    public float spawnTime;
    float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        int random = Random.Range(0, monster.Length);
        if (timer >= spawnTime )
        {
            
            Instantiate(monster[random], spawnPosition.transform);
            timer = 0;
        }
    }
}
