using UnityEngine;
using System.Collections;

public class LineSegue : MonoBehaviour
{
    [SerializeField] private Transform a1, a2;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        gameObject.GetComponent<LineRenderer>().SetPosition(1, a1.position);
        gameObject.GetComponent<LineRenderer>().SetPosition(2, a2.position);
    }
}
