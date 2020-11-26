using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Character : MonoBehaviour
{
    #region Fields
    internal static Animator characterAnim;
    public GameObject[] platforms;
    internal AudioSource stepsSource;
    #endregion


    #region Unity lifecycle
    void OnEnable()
    {
        EventAggregator.OnPlayClickEvent += this.StartMove;
        EventAggregator.OnGameOverEvent +=this.GameOver;
        EventAggregator.OnGameOverEvent += this.StopMove;
    }


    void OnDisable()
    {
        EventAggregator.OnPlayClickEvent -= this.StartMove;
        EventAggregator.OnGameOverEvent -=this.GameOver;
        EventAggregator.OnGameOverEvent -= this.StopMove;
    }


    void Awake()
    {
        stepsSource = GetComponent<AudioSource>();
        characterAnim = GetComponent<Animator>();
    }


    void FixedUpdate () {
       // SlopeCheck();
        if (characterAnim.GetBool("isWalking"))
        {

            Walking();
            platforms = GameObject.FindGameObjectsWithTag("Platform");

            if(transform.position.x >= platforms[platforms.Length - 1].transform.position.x)
            {
                EventAggregator.Character_OnPlatformEdgeReached();
                EventAggregator.Score_OnIncrease();
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if(transform.position.y < -9f)
        {
            GameStateManager.Instance.State = GameStateManager.GameState.GameOverMenu;
            EventAggregator.Game_OnGameOver();
        }
    }
    #endregion
   /* void SlopeCheck()
    {
        Vector2 checkpos = new Vector2(transform.position.x,transform.position.y) - new Vector2(0f,1.1f);
        VerticalSlope(checkpos);
    }
    void VerticalSlope(Vector2 checkpos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkpos,Vector2.down,0.1f);
        if(hit)
        {
            x = Vector2.Angle(Vector2.left,hit.normal);
            Debug.DrawLine(hit.point,hit.normal,Color.red,5.0f);
        }


    }*/
    void Update()
    {

    }

    void GameOver()
    {
        Destroy(transform.gameObject);
    }

    #region Public methods
    internal static void SetCharacterAnim(bool isWalking)
    {
        characterAnim.SetBool("isWalking", isWalking);
    }


    internal void Walking()
    {
        Vector3 currCharPos = transform.position;
        transform.GetComponent<Rigidbody2D>().position = new Vector3((currCharPos.x + 8f*Time.deltaTime), currCharPos.y, currCharPos.z);
    }


    internal void StartMove()
    {
        SetCharacterAnim(true);
        stepsSource.Play();
    }


    internal void StopMove()
    {
        SetCharacterAnim(false);
        stepsSource.Stop();
    }
    #endregion
}
