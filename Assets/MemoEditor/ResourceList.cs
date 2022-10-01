using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceList : MonoBehaviour
{
   public GameObject ButtonPrefab;
   public Transform ButtonPatent;
   private string selected;

   // Start is called before the first frame update
   void Start()
   {
      foreach (string r in ResourceManager.Instance.ResourceTypes)
      {
         AddButtonForResource(r, ResourceManager.Instance[r]);
      }
   }

   private void AddButtonForResource(string r, int val)
   {
      GameObject button = Instantiate(ButtonPrefab, ButtonPatent);
      button.transform.Find("TitleText").GetComponent<Text>().text = r;
      button.transform.Find("ValueText").GetComponent<Text>().text = val.ToString();
      button.GetComponent<Button>().onClick.AddListener(() => ResourceSelected(r));
   }

   public void ResourceSelected(string resource)
   {
      selected = resource;
   }

   public void RemoveResource()
   {
      if (!string.IsNullOrEmpty(selected))
      {
         ResourceManager.Instance.RemoveResource(selected);
         selected = null;
         RefreshButtonList();
      }
   }

   public void RefreshButtonList()
   {
      for (int i = ButtonPatent.childCount - 1; i >= 0; --i)
      {
         Destroy(ButtonPatent.GetChild(i).gameObject);
      }
      foreach (string r in ResourceManager.Instance.ResourceTypes)
      {
         AddButtonForResource(r, ResourceManager.Instance[r]);
      }
   }
}
