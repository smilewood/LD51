using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoList : MonoBehaviour
{
   public GameObject ButtonPrefab;
   public Transform ButtonPatent;
   public MemoEditor memoEditor;

   // Start is called before the first frame update
   void Start()
   {
      foreach(Memo m in MemoManager.Instance.memos)
      {
         AddButtonForMemo(m);
      }
      MemoSelected(MemoManager.Instance.memos[0]);
   }

   private void AddButtonForMemo(Memo m)
   {
      GameObject button = Instantiate(ButtonPrefab, ButtonPatent);
      button.transform.Find("TitleText").GetComponent<Text>().text = m.Title;
      button.transform.Find("BodyText").GetComponent<Text>().text = m.Body;
      button.GetComponent<Button>().onClick.AddListener(() => MemoSelected(m));
   }

   public void MemoSelected(Memo memo)
   {
      Debug.Log("Selected " + memo.Title);
      memoEditor.SetMemoForEdit(memo);
   }

   public void NewMemo()
   {
      Memo newMemo = new Memo();
      MemoManager.Instance.memos.Add(newMemo);
      AddButtonForMemo(newMemo);
   }

   public void RefreshButtonList()
   {
      for (int i = ButtonPatent.childCount - 1; i >= 0; --i)
      {
         Destroy(ButtonPatent.GetChild(i).gameObject);
      }
      foreach (Memo m in MemoManager.Instance.memos)
      {
         AddButtonForMemo(m);
      }
   }
}
