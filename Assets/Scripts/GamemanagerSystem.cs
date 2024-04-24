using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemanagerSystem : MonoBehaviour
{
    public GameObject[] monster;
    public GameObject spawnPosition;
    public GameObject nowMonster;
    public float spawnTime;
    float timer;
    public GameObject GameOverScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    
    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverScene.SetActive(true);
    }

    public void ReStart()
    {
        SceneManager.LoadScene("遊戲場景");
    }
}
