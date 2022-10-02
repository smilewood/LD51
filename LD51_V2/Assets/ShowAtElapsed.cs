using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAtElapsed : MonoBehaviour
{
   public GameObject target;
   public float time;
   // Start is called before the first frame update
   void Start()
   {
      target.SetActive(false);
   }

   // Update is called once per frame
   void Update()
   {
      if(countdown.Instance.elapsed > time)
      {
         target.SetActive(true);
         Destroy(this);
      }
   }
}
