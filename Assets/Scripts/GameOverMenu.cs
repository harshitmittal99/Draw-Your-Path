using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    #region Fields
    internal const float NEW_PLATFORM_POSITION_X = 2.65f;
    internal const float NEW_PLATFORM_POSITION_Y = -10.5f;

    internal const float NEW_CHARACTER_POSITION_X = 0f;
    internal const float NEW_CHARACTER_POSITION_Y = -4.5f;

    internal const float CAMERA_LAYER = -10;


    #endregion


    #region Unity lifecycle
    void Start () {
        transform.Find("RestartButton").GetComponent<Button>().onClick.
            AddListener(delegate () 
            {
                RestartButton_OnCLick();
            });
    }
    #endregion


    #region Event handlers
    private void RestartButton_OnCLick()
    {
        ScoreManager.ResetScore();
        SceneManager.LoadScene("main");
    }
    #endregion
}
