using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchCount : MonoBehaviour {

    [SerializeField] private Text txt;
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0)
        {
            txt.text = Input.touchCount.ToString();
        }
	}
}
