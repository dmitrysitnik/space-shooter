using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3      SpawnValues;
    public int          astCount;
    public float        spawnWait;
    public float        startWait;
    public float        waveWait;
    public Text         scoreText;
    private int         score;
    public Text         restartText;
    public Text         gameOverText;
    public static int   countWaves;
    public static float upSpeed;
    public GameObject   boss;
    


    private bool               gameOver;
    private bool               restart;
    public static bool        isBossfight;


    private void Start()
    {
        restartText.text = "";
        restart = false;
        gameOverText.text = "";
        gameOver = false;

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());   
    }
    IEnumerator SpawnWaves()
    {
        
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            if (!isBossfight)
            {
                UpSpeed();
                for (int wave = 1; wave <= astCount; wave++)
                {

                    Vector3 SpawnPosition = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                    Quaternion SpawnRotation = Quaternion.identity;
                    //Случайный угроза из массива угроз
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    //Spawn hazard
                    Instantiate(hazard, SpawnPosition, SpawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(startWait);

                BossSpawn();
            }
            countWaves++;

            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
        }
    }
    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score:" + score.ToString();
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameOver = true;
    }

    public void UpSpeed()
    {
        if (countWaves >= 1)
        {
            upSpeed = upSpeed - 0.25f;
        }
    }
    public void BossSpawn()
    {
        Quaternion spawnPosition = Quaternion.identity;
        Instantiate(boss, new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, 12.0f),spawnPosition);
        isBossfight = true;
    }
}