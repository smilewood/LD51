using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TargetResourceDropdown : MonoBehaviour
{
   Dropdown target;

   void Awake()
   {
      target = GetComponent<Dropdown>();
      target.AddOptions(ResourceManager.Instance.ResourceTypes.ToList());
   }

   public void SetCurrentDropdown(string current)
   {
      target.value = target.options.FindIndex(option => option.text == current );
   }

   public void SetDropdownChangeEvent(UnityAction<string> action)
   {
      target.onValueChanged.AddListener((int i) => { action(target.options[i].text); });
   }


}
