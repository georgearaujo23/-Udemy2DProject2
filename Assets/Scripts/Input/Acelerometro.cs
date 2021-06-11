using UnityEngine;
using System.Collections;

public class Acelerometro : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);
    }
}
