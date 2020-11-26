using UnityEngine;

public class EventAggregator : MonoBehaviour
{
    #region Fields
    public delegate void EventContainer();


    internal static event EventContainer OnPlayClickEvent;
    internal static event EventContainer OnPlatformEdgeReachedEvent;
    internal static event EventContainer OnGameOverEvent;
    internal static event EventContainer OnIncreaseScoreEvent;
    #endregion


    #region Private methods 
    private static void CallIfNotNull(EventAggregator.EventContainer eventName)
    {
        if (eventName != null)
        {
            eventName();
        }
    }
    #endregion


    #region Event handlers




    internal static void Game_OnPlayCliсk()
    {
        CallIfNotNull(OnPlayClickEvent);
    }

    internal static void Character_OnPlatformEdgeReached()
    {
        CallIfNotNull(OnPlatformEdgeReachedEvent);
    }

    internal static void Game_OnGameOver()
    {
        CallIfNotNull(OnGameOverEvent);
    }

    internal static void Score_OnIncrease()
    {
        CallIfNotNull(OnIncreaseScoreEvent);
    }
    #endregion
}
