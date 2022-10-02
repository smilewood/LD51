using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class improveButton : MonoBehaviour
{
   public Text improveText;
   public Button target;
   public Button timeButton;
   public float cost;
   public float costMult;

   public float baseTime;
   public float improvment;

   private void Start()
   {
      improveText.text = "Upgrade (-" + cost + "s)";
      target.GetComponent<EnableAtTimeRemaining>().MinTime = cost;
      target.onClick.AddListener(ButtonClicked);
      timeButton.onClick.AddListener(timeButtonCLicked);
   }

   public void ButtonClicked()
   {
      countdown.Instance.AddTime(-cost);
      cost *= costMult;
      improveText.text = "Upgrade (-" + cost.ToString("0.0") + "s)";
      target.GetComponent<EnableAtTimeRemaining>().MinTime = cost;
      baseTime += improvment;
   }

   public void timeButtonCLicked()
   {
      countdown.Instance.AddTime(baseTime);
   }
}
