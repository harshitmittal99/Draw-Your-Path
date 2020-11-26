using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Game : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgecollider;
    public List<Vector2> mousePos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateLine();
            GetComponent<AudioSource>().Play();
        }
        else if(Input.GetMouseButton(0))
        {
            Vector2 tempmousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tempmousePos,mousePos[mousePos.Count -1])>0.1f)
            {
                updateLine(tempmousePos);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            GetComponent<AudioSource>().Stop();
            currLine.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }
    void CreateLine()
    {
        currLine = Instantiate(linePrefab,Vector3.zero,Quaternion.identity);
        lineRenderer = currLine.GetComponent<LineRenderer>();
        edgecollider = currLine.GetComponent<EdgeCollider2D>();
        mousePos.Clear();   
        mousePos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        mousePos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0,mousePos[0]);
        lineRenderer.SetPosition(1,mousePos[1]);
        edgecollider.points = mousePos.ToArray();
    }
    void updateLine(Vector2 newmousePos)
    {
        mousePos.Add(newmousePos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1,newmousePos);
        edgecollider.points = mousePos.ToArray();
    }
}