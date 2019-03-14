using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{

  void onTriggerEnter2D(Collider2D col){
    Destroy(col.gameObject);
  }

}
