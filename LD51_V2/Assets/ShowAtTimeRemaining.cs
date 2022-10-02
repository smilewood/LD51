using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAtTimeRemaining : MonoBehaviour
{
   public float time;
   public GameObject target;

   private void Start()
   {
      target.SetActive(false);
   }
   private void Update()
   {
      if (countdown.Instance.remaining < time)
      {
         target.SetActive(true);
         Destroy(this);
      }
   }
}
