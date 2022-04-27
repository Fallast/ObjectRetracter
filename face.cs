using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class face : MonoBehaviour
{
   bool state;

   void Start()
   {
      state = true;
   }

    public bool isAvailable()
    {
       return state;
    }

    void OnTriggerStay(Collider col)
    {
       state = false;
    }

    void OnTriggerExit(Collider col)
    {
       state = true;
    }
}
