using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoConditionEditor : MonoBehaviour
{
   public GameObject conditionPrefab;
   public Transform prefabParent;
   private List<MemoCondition> activeList;

   public void LoadConditionsForMemo(Memo m)
   {
      activeList = m.conditions;

      Toggle RepeatToggle = transform.Find("RepeatableCheckbox").GetComponent<Toggle>();
      RepeatToggle.SetIsOnWithoutNotify(m.Repeatable);
      RepeatToggle.onValueChanged.AddListener((bool state) =>
      {
         m.Repeatable = state;
      });

      Toggle PriorityToggle = transform.Find("PriorityCheckbox").GetComponent<Toggle>();
      PriorityToggle.SetIsOnWithoutNotify(m.Priority);
      PriorityToggle.onValueChanged.AddListener((bool state) =>
      {
         m.Priority = state;
      });

      ReloadList();
   }

   public void ReloadList()
   {
      for (int i = prefabParent.childCount - 1; i >= 0; --i)
      {
         Destroy(prefabParent.GetChild(i).gameObject);
      }


      foreach(MemoCondition cond in activeList)
      {
         AddEditorForCondition(cond);
      }
   }

   public void AddEditorForCondition(MemoCondition cond)
   {
      GameObject go = Instantiate(conditionPrefab, prefabParent);
      TargetResourceDropdown resourceDropdown = go.transform.Find("TargetResource").GetComponent<TargetResourceDropdown>();
      resourceDropdown.SetCurrentDropdown(cond.resource);
      resourceDropdown.SetDropdownChangeEvent((string newRes) =>
      {
         cond.resource = newRes;
         ReloadList();
      });

      Dropdown conditionDropdown = go.transform.Find("ConditionDropdown").GetComponent<Dropdown>();
      conditionDropdown.value = (int)cond.condition;
      conditionDropdown.onValueChanged.AddListener((int i) =>
      {
         cond.condition = (conditional)i;
         ReloadList();
      });

      InputField value = go.transform.Find("ValueField").GetComponent<InputField>();
      value.SetTextWithoutNotify(cond.targetValue.ToString());
      value.onEndEdit.AddListener((string val) =>
      {
         cond.targetValue = int.Parse(val);
         ReloadList();
      });
   }

   public void AddNewCondition()
   {
      activeList.Add(new MemoCondition());
      ReloadList();
   }
}
