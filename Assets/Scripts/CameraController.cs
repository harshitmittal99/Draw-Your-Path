using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Fields
    internal static bool isNeedToMove = false;
    #endregion

    internal bool game;

    #region Properties
    internal static bool IsNeedToMove
    {
        get
        {
            return isNeedToMove;
        }
        set
        {
            isNeedToMove = value;
        }

    }
    #endregion


    #region Unity lifecycle
    void OnEnable()
    {
        EventAggregator.OnPlayClickEvent += this.MoveNextPosition;
        EventAggregator.OnGameOverEvent += this.GameOver;
    }


    void OnDisable()
    {
        EventAggregator.OnPlayClickEvent -= this.MoveNextPosition;
        EventAggregator.OnGameOverEvent -= this.GameOver;
    }


    void Awake()
    {
        game = true;
        IsNeedToMove = false;
    }


    void Update()
    {
        if(game)
        {   
        if (IsNeedToMove)
        {
            Camera.main.transform.Translate(new Vector3(0.5f, 0, 0));
        }
        if(GetComponent<Camera>().transform.position.x >GameObject.FindGameObjectWithTag("Player").transform.position.x)
        {
            IsNeedToMove = false;
        }
        else
        {
            IsNeedToMove = true;
        }
        }
        else
        {
            IsNeedToMove = false;
        }
    }
    #endregion

    internal void GameOver ()
    {
        game = false;
    }

    #region Public Methods
    public void MoveNextPosition()
    {
        IsNeedToMove = true;
    }
    #endregion
}
