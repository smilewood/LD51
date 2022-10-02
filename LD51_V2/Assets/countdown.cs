using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
   private static countdown instance;
   public static countdown Instance
   {
      get
      {
         return instance;
      }
   }


   public float remaining = 10;

   public float elapsed = 0;

   public float dilationRate = 0;

   public GameObject GameOverScreen;
   public Text ResultsCounter;

   Text counter;

   // Start is called before the first frame update
   void Awake()
   {
      instance = this;
      counter = GetComponent<Text>();
   }

   // Update is called once per frame
   void Update()
   {
      //if (Input.GetKeyDown(KeyCode.S))
      //{
      //   elapsed += 5;
      //}
      //if (Input.GetKeyDown(KeyCode.D))
      //{
      //   remaining += 50;
      //}

      if (remaining <= 0)
      {
         //game over
         counter.text = "Game Over";
         GameOverScreen.SetActive(true);
         ResultsCounter.text = (elapsed - 10f).ToString("0.00") + " Seconds";
         return;
      }
      remaining -= Time.deltaTime * (1 + dilationRate);
      elapsed += Time.deltaTime;
      string remainingString = remaining.ToString("0.00");
      int index = remainingString.IndexOf(".");
      counter.text = remainingString.Substring(0, index) + ":" + remainingString.Substring(index + 1);
   }

   public void AddTime(float amount)
   {
      remaining += amount;
      //Debug.Log("Adding " + amount + "sec");
   }
}
