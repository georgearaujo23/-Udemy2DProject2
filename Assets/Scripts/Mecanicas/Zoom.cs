using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float orthoZoomSpeed = 0.5f;
    public bool liberaZoom;
    public int trava = 1;

    public bool um_click = false;
    public float tempoParaDuploClick;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            if (!um_click)
            {
                um_click = true;
                tempoParaDuploClick = Time.time;
            }
            else
            {
                um_click = false;
                liberaZoom = true;
            }
        }
        

        if (um_click)
        {
            if((Time.time - tempoParaDuploClick) > delay)
            {
                um_click = false;
            }
        }
        
        if(Camera.main.orthographicSize > 5 && trava == 1)
        {
            if (liberaZoom)
            {
                Camera.main.orthographicSize -= orthoZoomSpeed;
                if (Camera.main.orthographicSize == 5)
                {
                    liberaZoom = false;
                    trava = 2;
                }
            }
        }
        else if (Camera.main.orthographicSize < 10 && trava == 2)
        {
            if (liberaZoom)
            {
                Camera.main.orthographicSize += orthoZoomSpeed;
                if (Camera.main.orthographicSize == 10)
                {
                    liberaZoom = false;
                    trava = 1;
                }
            }
        }
    }
}
