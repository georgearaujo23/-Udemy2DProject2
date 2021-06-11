using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaPassaroUI : MonoBehaviour
{
    public GameObject passaro;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TiroPassaro", 2f, 2f);
    }

    void TiroPassaro()
    {
        Instantiate(passaro, transform.position, Quaternion.identity);

    }
}
