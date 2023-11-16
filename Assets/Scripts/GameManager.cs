using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifesText;
    private string heart = "♥";

    private int score;
    private int playerLives;

    public bool gameOver;
    public GameObject gameOverText;
    void Start()
    {
        gameOverText.SetActive(false);
        score = 0;
        playerLives = 3;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLifes(0);
    }

    public void Update()
    {
        GameOver();
    }
    public void UpdateScore(int scoreAdded)
    {
        score += scoreAdded;
        scoreText.text = $"Score {score}";
    }


    public void UpdateLifes(int quantity)
    {
        playerLives -= quantity;
        UpdateTextMesh();
    }

    private void UpdateTextMesh()
    {
        string lifes = "";
        for (int i = 0; i < playerLives; i++) { lifes += heart; }
        lifesText.text = $"Lifes {lifes}";
    }
    IEnumerator SpawnTarget()
    {
        while(!gameOver)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        } 
    }

    public void GameOver()
    {
        if(playerLives < 1 || score < 0)
        {
            if (score > 0)
            {
                Debug.Log("Score:" +score);
            }
            gameOver = true;
            score = 0;
            UpdateScore(0);
            gameOverText.SetActive(true);
        }
    }
}
