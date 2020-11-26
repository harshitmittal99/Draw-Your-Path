using Assets.Scripts;
using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    #region Fields
    private static GameStateManager instance;
    private static GameState state;


    private delegate void GameStateChangedHandler
        (object sender, GameStateChangedArgs GameStateChangedArgs);
    private GameStateChangedHandler OnGameStateChangedEvent;


    internal enum GameState { Menu, Game, GameOverMenu }
    #endregion


    #region Properties
    internal static GameStateManager Instance
    {
        get
        {
            return instance;
        }
    }
    internal  GameState State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
            if (OnGameStateChangedEvent != null)
            {
                OnGameStateChangedEvent(this, new GameStateChangedArgs(state));
            }
        }
    }
    #endregion


    #region Unity lificycle
    void OnEnable()
    {
        OnGameStateChangedEvent += EnableUIItem;
    }

    void OnDisable()
    {
        OnGameStateChangedEvent -= EnableUIItem;
    }

    void Start()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else
        {
            throw new Exception("Instance of GameStateManager is already exist");
        }

        State = GameState.Menu;
    }
    #endregion


    #region Private methods
    private void EnableUIItem(object sender, GameStateChangedArgs gameStateChangedArgs)
    {
        foreach (Transform child in transform)
        {
            if (child.name == gameStateChangedArgs.State.ToString())
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    #endregion
}
