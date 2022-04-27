//ObjectRetracter by Brian Gonnet

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRetracter : MonoBehaviour
{

   public GameObject fps;
   FirstPersonController my_fps;
   private face face_1, face_2, face_3, face_4, face_5, face_6;
   public Transform held_object;
   private float responsivnessVal;
   public float responsiv_walkingVal;
   public float responsiv_sprintingVal;
   public float responsiv_hideSpeed;
   Vector3 origin, pos_1, pos_3, pos_6, hide;
   private bool active = true;

    void Start()
    {
       active = true;
       my_fps = fps.GetComponent<FirstPersonController>();
       origin = pos_1 = pos_3 = pos_6 = hide = held_object.localPosition;
       pos_1[0] = .1f;
       pos_1[2] = pos_6[2] = hide[2] =  -.30f;
       pos_3[0] = pos_6[0] =  .30f;
       pos_3[2] = -.18f;
       hide[1] = -.47f;
       face_1 = GetComponentsInChildren<face>()[0];
       face_2 = GetComponentsInChildren<face>()[1];
       face_3 = GetComponentsInChildren<face>()[2];
       face_4 = GetComponentsInChildren<face>()[3];
       face_5 = GetComponentsInChildren<face>()[4];
       face_6 = GetComponentsInChildren<face>()[5];
    }

    private void state()
    {
       print("face_1; " + face_1.isAvailable());
       print("face_2; " + face_2.isAvailable());
       print("face_3; " + face_3.isAvailable());
       print("face_4; " + face_4.isAvailable());
       print("face_5; " + face_5.isAvailable());
       print("face_6; " + face_6.isAvailable());
    }

    public bool isActive()
    {
       return active;
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.F) && !active)
       {
          active = true;
          held_object.gameObject.SetActive(true);
       }
       else if(Input.GetKeyDown(KeyCode.F) && active)
          active = false;

       if(active)
       {
          if(my_fps.getSprinting())
             responsivnessVal = responsiv_sprintingVal;
          else
             responsivnessVal = responsiv_walkingVal;
          //mi caso base es quedarme en 2 osea no hacer nada
          if( face_1.isAvailable() && face_2.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, origin, Time.deltaTime*responsivnessVal);
          else if(!face_2.isAvailable() && !face_1.isAvailable() && face_3.isAvailable() && face_6.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, pos_3, Time.deltaTime*responsivnessVal);
          else if(!face_2.isAvailable() && face_1.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, pos_1, Time.deltaTime*responsivnessVal);
          else if(!face_2.isAvailable() && face_3.isAvailable() && face_6.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, pos_3, Time.deltaTime*responsivnessVal);
          else if(face_6.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, pos_6, Time.deltaTime*responsivnessVal);
          else
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, hide, Time.deltaTime * responsiv_hideSpeed);
       }
       else
       {
          held_object.localPosition = Vector3.Lerp(held_object.localPosition, hide, Time.deltaTime * responsiv_hideSpeed);
          if(held_object.localPosition == hide)
             held_object.gameObject.SetActive(false);
       }
    }
}
