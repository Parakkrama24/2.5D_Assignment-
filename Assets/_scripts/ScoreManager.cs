using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    public int score = 0;
    [SerializeField] private TMP_Text GuidText;
    private void Awake()
    {
        // Ensure there's only one instance of ScoreManager
        if (instance == null)
        {
            instance = this;
           
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }
    }

    public void ChangeScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "    Score: " + score;
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned in the inspector.");
        }
    }

    private void Update()
    {
       if(score >= 14)
        {
            GuidText.text = "Reach to Finsh Point";
        }
    }
}
