using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeDialation : MonoBehaviour
{
   public float dilationFactor;
   public float dialationRate;

   private float timer;
   public Text dilationRateText;
   // Start is called before the first frame update
   void Start()
   {

   }
   public bool dilationPause = false;
   // Update is called once per frame
   void Update()
   {
      if (!dilationPause)
      {
         timer += Time.deltaTime;
      }
      if(timer > 12)
      {
         timer = 0;
         dilationFactor = (dilationFactor + dialationRate) * 1.1f;
         countdown.Instance.dilationRate = dilationFactor;
         dilationRateText.text = "Dilation Effect: " + dilationFactor.ToString("0.000");
      }
   }
}
