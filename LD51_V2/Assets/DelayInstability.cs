using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayInstability : MonoBehaviour
{
   public float buildTime;
   public float timeCost;
   public float timeCostMult;

   public progressBar buildBar;

   private Button button;

   public timeDialation dilationManager;

   string ButtonText = "Delay instability\nCost: {0} seconds";
   // Start is called before the first frame update
   void Start()
   {
      GetComponentInChildren<Text>().text = string.Format(ButtonText, timeCost);
      GetComponent<EnableAtTimeRemaining>().MinTime = timeCost;
      button = GetComponent<Button>();
   }

   // Update is called once per frame
   void Update()
   {
   }

   public void StartBuilding()
   {
      countdown.Instance.AddTime(-timeCost);
      buildBar.gameObject.SetActive(true);
      buildBar.time = buildTime;
      buildBar.ResetBar();
      buildBar.BarComplete.AddListener(BuildComplete);
      timeCost *= timeCostMult;
      GetComponent<EnableAtTimeRemaining>().MinTime = timeCost;
      GetComponent<EnableAtTimeRemaining>().enabled = false;
      GetComponentInChildren<Text>().text = string.Format(ButtonText, timeCost.ToString("0.0"));
      button.interactable = false;

      dilationManager.dilationPause = true;
   }

   public void BuildComplete()
   {
      GetComponent<EnableAtTimeRemaining>().enabled = true;
      dilationManager.dilationPause = false;
      buildBar.gameObject.SetActive(false);
   }
}
