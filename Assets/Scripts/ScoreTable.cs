using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text best;
    #endregion


    #region Unity lifecycle
    void OnEnable()
    {
        score.text = ScoreManager.score.ToString();
        best.text = ScoreManager.bestScore.ToString();
    }
    #endregion
}
