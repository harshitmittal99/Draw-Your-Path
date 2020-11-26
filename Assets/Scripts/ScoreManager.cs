using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Fields
    internal static int score = -1;
    internal static int bestScore = 0;


    internal Text scoreTextView;
    internal string best = "bestScore";
    internal string textTemplate;
    #endregion


    #region Unity lifecycle
    void Start()
    {
        scoreTextView = transform.GetComponent<Text>();
        textTemplate = scoreTextView.text;
        bestScore = PlayerPrefs.GetInt(best);
    }

    void OnEnable()
    {
        EventAggregator.OnIncreaseScoreEvent += IncreaseScore;
    }

    void OnDisable()
    {
        EventAggregator.OnIncreaseScoreEvent -= IncreaseScore;
    }
    #endregion


    #region Public methods
    internal static void ResetScore()
    {
        score = 0;
    }
    #endregion


    #region Private methods
    private void IncreaseScore()
    {
        score += 1;
        scoreTextView.text = string.Format(textTemplate, score.ToString());
        if (score > PlayerPrefs.GetInt(best))
        {
            PlayerPrefs.SetInt(best, score);
            bestScore = PlayerPrefs.GetInt(best);
        }
    }
    #endregion
}