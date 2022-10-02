using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class progressBar : MonoBehaviour
{
   public bool fill = true;
   public bool repeats = false;
   public float time;
   private float timer = 0;
   private RectTransform bar;
   private Vector2 targetWidth;

   public UnityEvent BarComplete;

   // Start is called before the first frame update
   void Start()
   {
      bar = transform.Find("FillBar").GetComponent<RectTransform>();
      targetWidth = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 1f);
   }

   // Update is called once per frame
   void Update()
   {
      timer += Time.deltaTime;
      if (fill)
      {
         bar.sizeDelta = Vector2.Lerp(new Vector2(0f, 1f), targetWidth, timer / time);
      }
      else
      {
         bar.sizeDelta = Vector2.Lerp( targetWidth, new Vector2(0f, 1f),timer / time);
      }

      if(timer > time)
      {
         //complete
         BarComplete.Invoke();
         if (repeats)
         {
            timer = 0;
         }
      }
   }

   public void ResetBar()
   {
      timer = 0;
      BarComplete = new UnityEvent();
   }
}
