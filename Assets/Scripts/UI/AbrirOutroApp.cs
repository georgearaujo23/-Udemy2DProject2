using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirOutroApp : MonoBehaviour
{
  

    public void EventoClick()
    {
        Application.OpenURL("market://details?id=com.nianticlabs.pokemongo");
    }

}
