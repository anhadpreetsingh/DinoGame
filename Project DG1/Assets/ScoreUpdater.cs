using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public float score = 0;
    [SerializeField] DinoController player;
    [SerializeField] float scoreFactor;
    public bool speedIncreased = false;

    public Text highScore;
    AudioSource audioSource;

    Text text;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        text = GetComponent<Text>();

        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void Update()
    {
        score = (int) (scoreFactor * Time.timeSinceLevelLoad);
        scoreFactor += Time.deltaTime/10;

        text.text = score.ToString();
        
        if(score!=0 && score % 100 == 0 && !speedIncreased)
        {
            player.speed += 0.5f;
            speedIncreased = true;
            audioSource.Play();

        }

        if(score % 100 != 0)
        {
            speedIncreased = false;
        }

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int) score);
            highScore.text = "High Score: " + score.ToString();
        }
        
    }

    private void ResetSpeedIncreased()
    {
        speedIncreased = false;
    }
}
