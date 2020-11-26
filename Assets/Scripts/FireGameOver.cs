using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGameOver : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag == "Player")
        {
            GameStateManager.Instance.State = GameStateManager.GameState.GameOverMenu;
            EventAggregator.Game_OnGameOver();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
