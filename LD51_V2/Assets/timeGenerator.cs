using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeGenerator : MonoBehaviour
{
   public float generationTime;
   public float addedTime;

   public float TimeCost;
   public float TimeMult;
   public float TimeAdded;

   public float PowerCost;
   public float PowerMult;
   public float PowerAdded;

   public progressBar bar;


   private Text SpeedText;
   private EnableAtTimeRemaining speedButton;
   private Text PowerText;
   private EnableAtTimeRemaining powerButton;

   public Text TimerText;

   // Start is called before the first frame update
   void Start()
   {
      GameObject SpeedButton = transform.Find("SpeedButton").gameObject;
      speedButton = SpeedButton.GetComponent<EnableAtTimeRemaining>();
      speedButton.MinTime = TimeCost;
      SpeedText = SpeedButton.GetComponentInChildren<Text>();
      SpeedText.text = "Speed (" + TimeCost.ToString("0.0") + "s)";
      SpeedButton.GetComponent<Button>().onClick.AddListener(() =>
      {
         IncreaseSpeed();
      });


      GameObject PowerButton = transform.Find("PowerButton").gameObject;
      powerButton = PowerButton.GetComponent<EnableAtTimeRemaining>();
      powerButton.MinTime = PowerCost;
      PowerText = PowerButton.GetComponentInChildren<Text>();
      PowerText.text = "Quantity (" + PowerCost.ToString("0.0") + "s)";
      PowerButton.GetComponent<Button>().onClick.AddListener(() =>
      {
         IncreasePower();
      });

      bar.time = generationTime;
      bar.BarComplete.AddListener(() => { countdown.Instance.AddTime(addedTime); });
   }

   private void IncreaseSpeed()
   {
      countdown.Instance.AddTime(-TimeCost);
      generationTime -= TimeAdded;
      bar.time = generationTime;
      TimeCost *= TimeMult;
      speedButton.MinTime = TimeCost;
      SpeedText.text = "Speed (" + TimeCost.ToString("0.0") + "s)";
   }

   private void IncreasePower()
   {
      countdown.Instance.AddTime(-PowerCost);
      addedTime += PowerAdded;
      PowerCost *= PowerMult;
      powerButton.MinTime = PowerCost;
      PowerText.text = "Quantity (" + PowerCost.ToString("0.0") + "s)";
      TimerText.text = "+" + addedTime.ToString("0.0") + " second";
   }
}
