using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region Fields
    internal bool isSoundOn;
    internal bool isNeedToHideUI;
    internal Image soundImage;


    [SerializeField]
    private Sprite sndOnImg;
    [SerializeField]
    private Sprite sndOffImg;
    [SerializeField]
    private Canvas canvas;
    #endregion


    #region Properties
    internal bool IsSoundOn
    {
        get
        {
            return isSoundOn;
        }
        set
        {
            isSoundOn = value;
        }
    }

    internal bool IsNeedToHideUI
    {
        get
        {
            return isNeedToHideUI;
        }
        set
        {
            isNeedToHideUI = value;
        }
    }
    #endregion


    #region Unity lifecycle
    void Start()
    {
        IsSoundOn = true;
        IsNeedToHideUI = false;

        transform.Find("Play").GetComponent<Button>().onClick.
            AddListener(delegate () { PlayButton_OnCLick(); });
        transform.Find("Sound").GetComponent<Button>().onClick.
            AddListener(delegate () { SoundButton_OnClick(); });

        soundImage = transform.Find("Sound").GetComponent<Image>();
        soundImage.sprite = sndOnImg;
    }
    #endregion


    #region Event handlers
    private void PlayButton_OnCLick()
    {
        EventAggregator.Game_OnPlayCliсk();
        GameStateManager.Instance.State = GameStateManager.GameState.Game;
    }


    private void SoundButton_OnClick()
    {
        if (IsSoundOn)
        {
            AudioListener.volume = 0;
            soundImage.sprite = sndOffImg;
            IsSoundOn = !IsSoundOn;
        }
        else
        {
            AudioListener.volume = 1;
            soundImage.sprite = sndOnImg;
            IsSoundOn = !IsSoundOn;
        }
    }
    #endregion
}
