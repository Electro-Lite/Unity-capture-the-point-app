using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    int red_team = 0;
    int blue_team = 0;
    int brown_team = 0;
    int full_time = 0;
    string current_team="";
    float time = 0;
    int ready_to_flip=0;
    Color brown_color= new Color(0.60f,0.20f,0.00f);
    public UnityEngine.UI.Text red;
    public UnityEngine.UI.Text blue;
    public UnityEngine.UI.Text brown;
    public UnityEngine.UI.Text konec;
    public Camera cam;
    void Awake()
    {
      cam = GetComponent<Camera>();
      cam.backgroundColor=Color.gray;
      red.text="Mustangové: "+red_team;
      blue.text="Mungové: "+blue_team;
      brown.text="Vlci: "+blue_team;
    }
    void change_team(){
      if ((current_team=="") || (current_team=="blue")) {
        current_team="red";
        cam.backgroundColor=Color.red;
      }
      else if (current_team=="red") {
        current_team="brown";
        cam.backgroundColor=brown_color;
      }
      else if (current_team=="brown") {
        current_team="blue";
        cam.backgroundColor=Color.blue;
      }
    }

    // Update is called once per frame
    void Update()
    {
      time+=Time.deltaTime;
       if (Input.touchCount > 0){
         ready_to_flip=1;
       }
      if (time>1) {
        full_time+=1;
        time=0;
        if (ready_to_flip==1) {
          ready_to_flip=0;
          change_team();
        }
        if (current_team=="red") {
          red_team+=1;
          red.text="Mustangové: "+red_team;
        }
        if (current_team=="blue") {
          blue_team+=1;
          blue.text="Mungové: "+blue_team;
        }
        if (current_team=="brown") {
          brown_team+=1;
          brown.text="Vlci: "+brown_team;
        }
      }
      if (full_time>60*15) {
        konec.text="Konec !";
        Time.timeScale=0;
      }
    }
}
