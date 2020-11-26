using UnityEngine;
using System; 
using System.Collections.Generic; 
public class RightPlatformEdge : MonoBehaviour
{
    #region Fields
    internal const float DEFAULT_SCALE = 1;
    internal const float PLATFORM_WIDTH = 5;
    internal const float MIN_PLATFORM_SCALE = 10f;
    internal const float MAX_PLATFORM_SCALE = 12f;


    [SerializeField]
    private Transform platform;
    public List<Transform> platforms;
    public GameObject Fire;
    public GameObject Stone;
    internal GameObject obstacle;
    #endregion


    #region Unity lifecycle
    void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
    }

    void OnEnable()
    {
        EventAggregator.OnPlatformEdgeReachedEvent += this.CreateNextPlatform;
    }
    void OnDisable()
    {
        EventAggregator.OnPlatformEdgeReachedEvent -= this.CreateNextPlatform;
    }

    #endregion


    #region Private methods
    private void CreateNextPlatform()
    {
        Transform nextPlatform = Instantiate(platform);
        SetPlatformComponents(nextPlatform);
        float nextScale = UnityEngine.Random.Range(MIN_PLATFORM_SCALE, MAX_PLATFORM_SCALE);
        float distance = UnityEngine.Random.Range(20,25);
        float yscale = UnityEngine.Random.Range(1,1.75f);
        
        float nextPositionX = ((nextScale) * PLATFORM_WIDTH) +
            transform.position.x + distance;
        float obsdist = UnityEngine.Random.Range(0,nextScale*PLATFORM_WIDTH);
        SetPlatformPositionAndTransform(nextPlatform, nextScale, nextPositionX,yscale);
        //int obs = random.Next(1,3);
        var rnd = new System.Random();
        int obs = rnd.Next(1,3);
        if(obs == 1)
        {
            obstacle = Instantiate(Stone);
        }
        else
        {
            obstacle = Instantiate(Fire);
        }
        obstacle.transform.position = new Vector3(
             ((nextScale) * PLATFORM_WIDTH)/2 +
            transform.position.x + distance,
            nextPlatform.transform.position.y+yscale * 5.6f,
            nextPlatform.transform.position.z
        );
        obstacle.transform.localScale = new Vector3
        (
            0.2f,0.2f,1f
        );
        platforms.Add(nextPlatform);
    }


    private void SetPlatformComponents(Transform platform)
    {
        platform.transform.Find("RedSquare").
            GetComponent<SpriteRenderer>().enabled = true;
        platform.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        platform.transform.Find("RightPlatformEdge").
            GetComponent<BoxCollider2D>().enabled = true;
    }

    private void SetPlatformPositionAndTransform(Transform platform, float scale, float coordX,float yscale)
    {
        platform.transform.localScale = new Vector3
            (
            scale,
            yscale,
            platform.transform.localScale.z
            );

        platform.transform.position = new Vector3
            (
            coordX,
            transform.parent.transform.position.y,
            transform.position.z
            );

        platform.Find("RedSquare").localScale = 
            new Vector3(DEFAULT_SCALE / scale, DEFAULT_SCALE, 1f);
    }
    #endregion
}
