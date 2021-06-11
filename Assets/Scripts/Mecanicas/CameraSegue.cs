using UnityEngine;
using System.Collections;

public class CameraSegue : MonoBehaviour
{

    [SerializeField] private Transform paredeE, paredeD, passaro;   

    // Update is called once per frame
    void Update()
    {
        Vector3 posCam = transform.position;
        posCam.x = passaro.position.x;
        posCam.x = Mathf.Clamp(posCam.x, paredeE.position.x, paredeD.position.x);
        transform.position = posCam; 
    }
}
