using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EnableAtTimeRemaining : MonoBehaviour
{
   private Button target;
   public float MinTime;

   // Start is called before the first frame update
   void Start()
   {
      target = GetComponent<Button>();
   }

   // Update is called once per frame
   void Update()
   {
      if(target.interactable && countdown.Instance.remaining < MinTime)
      {
         target.interactable = false;
      }
      if (!target.interactable && countdown.Instance.remaining > MinTime)
      {
         target.interactable = true;
      }
   }
}
