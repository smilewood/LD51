using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddResource : MonoBehaviour
{
   public ResourceList list;
   public void Add()
   {
      string name = transform.Find("Name").GetComponent<InputField>().text;
      Dropdown drop = transform.Find("type").GetComponent<Dropdown>();
      Enum.TryParse(drop.options[drop.value].text, out ResourceType type);
      int defaultVal = int.Parse(transform.Find("Default").GetComponent<InputField>().text);
      ResourceManager.Instance.AddResource(name, defaultVal, type);

      list.RefreshButtonList();
   }
}
