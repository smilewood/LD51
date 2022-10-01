using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoEffectEditor : MonoBehaviour
{
   public GameObject EffectPrefab;
   public Transform PrefabParent;
   public List<MemoEffect> activeEffectList;

   public void LoadListForMemo(List<MemoEffect> list)
   {
      activeEffectList = list;
      ReloadList();
   }

   private void ReloadList()
   {
      for(int i = PrefabParent.childCount - 1; i >= 0; --i)
      {
         Destroy(PrefabParent.GetChild(i).gameObject);
      }

      for(int i = 0; i < activeEffectList.Count; ++i)
      {
         int val = i;
         GameObject go = Instantiate(EffectPrefab, PrefabParent);
         TargetResourceDropdown dropdown = go.GetComponentInChildren<TargetResourceDropdown>();
         dropdown.SetCurrentDropdown(activeEffectList[val].resource);
         dropdown.SetDropdownChangeEvent((string newRes) =>
         {
            activeEffectList[val].resource = newRes;
            ReloadList();
         });

         InputField valuefield = go.transform.Find("ValueField").GetComponent<InputField>();
         valuefield.text = activeEffectList[val].change.ToString();
         valuefield.onEndEdit.AddListener((string newVal) =>
         {
            int newInt = int.Parse(newVal);
            activeEffectList[val].change = newInt;
            ReloadList();
         });

         go.transform.Find("RemoveButton").GetComponent<Button>().onClick.AddListener(() =>
         {
            activeEffectList.RemoveAt(val);
            ReloadList();
         });
      }
   }

   public void AddEffect()
   {
      if(activeEffectList != null)
      {
         activeEffectList.Add(new MemoEffect());
         ReloadList();
      }
   }

}
