using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TPosition : MonoBehaviour
{
    [SerializeField] private Text txt;
    private Touch toque;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            toque = Input.GetTouch(0);
            if(toque.phase == TouchPhase.Began)
            {
                if(toque.position.x > (Screen.width / 2))
                {
                    txt.text = "Lado Direito";
                }
                else
                {
                    txt.text = "Lado Esquerdo";
                }
            }
        }
    }
}
