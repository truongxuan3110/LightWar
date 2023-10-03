using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float waitingTime;
    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int maxEnemiesOnScreen;
    public int enemiesOnScreen;
    public int totalEnemies;
    public int enemiesPerSpawn;
    public int currentGold;
    public Text goldText;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = currentGold.ToString();
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
    }
    public void ReduceGold(int amount)
    {
        currentGold -= amount;
    }

    IEnumerator Spawn()
    {
        if (enemiesOnScreen < totalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (enemiesOnScreen < maxEnemiesOnScreen)
                {
                    GameObject newEnemy = Instantiate(enemies[Random.Range(0,4)] as GameObject);
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen++;
                }
            }
            yield return new WaitForSeconds(waitingTime);
            StartCoroutine(Spawn());
        }
    }
}
