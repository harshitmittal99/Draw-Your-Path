using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LoopBackground : MonoBehaviour
{
    #region Fields
    internal const float BACKGROUND_WIDTH = 45;
    [SerializeField]
    public Transform BackGroundImg;
    internal Transform NewBg;
    public List<Transform> bgPics;
    #endregion


    #region Unity lifecycle
    void Start()
    {
        bgPics.Add(GameObject.FindGameObjectWithTag("Background").transform);
        NewBg = Instantiate(BackGroundImg);
        NewBg.transform.position = new Vector3(
            bgPics[0].transform.position.x+BACKGROUND_WIDTH,
            bgPics[0].transform.position.y,
            bgPics[0].transform.position.z
        );
        bgPics.Add(NewBg);
    }


    void Update()
    {
        if (Camera.main.transform.position.x >
            bgPics[bgPics.Count-1].transform.position.x)
        {
            NewBg = Instantiate(BackGroundImg);
            NewBg.transform.position = new Vector3(
                bgPics[bgPics.Count-1].transform.position.x+BACKGROUND_WIDTH,
                bgPics[bgPics.Count-1].transform.position.y,
                bgPics[bgPics.Count-1].transform.position.z
            );
            bgPics.Add(NewBg);
        }
    }
    #endregion
}


