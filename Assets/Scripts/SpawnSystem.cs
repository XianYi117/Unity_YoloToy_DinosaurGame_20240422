using UnityEngine;

namespace Xian
{
    public class SpawnSystem : MonoBehaviour
    {
        public GameObject[] monster;
        public GameObject spawnPosition;
        public GameObject nowMonster;
        public float spawnTime;
        float timer;

        void Update()
        {
            timer += Time.deltaTime;

            int random = Random.Range(0, monster.Length);
            if (timer >= spawnTime)
            {

                Instantiate(monster[random], spawnPosition.transform);
                timer = 0;
            }
        }
    }
}

