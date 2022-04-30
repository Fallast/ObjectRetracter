//ObjectRetracter by Brian Gonnet, Argentina

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRetracter : MonoBehaviour
{

   //the following variable is used for checking if the player is sprinting or
   //not and thus changing the object retracting intensity.  you should change
   //its type according to your character controller(whether it is a First
   //Person Controller or a Third Person Controller) as long as it has a function
   //that checks if its sprinting (check getSprinting() in line 79)
   //if your character cannot sprint simply untoggle Sprinting_values in the editor.
   public FirstPersonController character_controller;

   //faces represent the detection areas which are 6 cubes one next to each other forming a rectangle (ObjectRetracter.fbx)
   private face face_1, face_2, face_3, face_4, face_5, face_6;
   public Transform held_object;
   private float responsivnessVal;
   private float responsivness_hideVal;
   public float responsiv_walkingSpeed;
   public bool Sprinting_values = false;
   public float responsiv_sprintingSpeed;
   public float responsiv_hideSpeed;
   public float responsiv_sprintinghideSpeed;
   Vector3 origin, pos_1, pos_3, pos_6, hide;
   private bool active = true;
   public Camera camvel;

    void Start()
    {
       active = true;
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
       print(camvel.velocity);
       //this won't work since i need the overall motion speed and .velocity only gives me position speed over time, i need rotation
       if(Input.GetKeyDown(KeyCode.F) && !active)
       {
          active = true;
          held_object.gameObject.SetActive(true);
       }
       else if(Input.GetKeyDown(KeyCode.F) && active)
          active = false;

       if(active)
       {
          responsivnessVal = responsiv_walkingSpeed;
          responsivness_hideVal = responsiv_hideSpeed;
          if(Sprinting_values)
          {
             if(character_controller.getSprinting())
                responsivnessVal = responsiv_sprintingSpeed;
                responsivness_hideVal = responsiv_sprintinghideSpeed;
          }

          if( face_1.isAvailable() && face_2.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, origin, Time.deltaTime*responsiv_walkingSpeed);
          else if(!face_2.isAvailable() && !face_1.isAvailable() && face_3.isAvailable() && face_6.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, pos_3, Time.deltaTime*responsivnessVal);
          else if(!face_2.isAvailable() && face_1.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, pos_1, Time.deltaTime*responsivnessVal);
          else if(!face_2.isAvailable() && face_3.isAvailable() && face_6.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, pos_3, Time.deltaTime*responsivnessVal);
          else if(face_6.isAvailable())
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, pos_6, Time.deltaTime*responsivnessVal);
          else
             held_object.localPosition = Vector3.Lerp(held_object.localPosition, hide, Time.deltaTime * responsivness_hideVal);
       }
       else
       {
          held_object.localPosition = Vector3.Lerp(held_object.localPosition, hide, Time.deltaTime * responsivness_hideVal);
          if(held_object.localPosition == hide)
             held_object.gameObject.SetActive(false);
       }
    }
}
