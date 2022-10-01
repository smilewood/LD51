using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoEditor : MonoBehaviour
{
   private Memo currentMemo;
   
   public InputField TitleField;
   public InputField BodyField;
   public MemoEffectEditor EffectEditor;
   public MemoList memoList;

   private void Start()
   {
      TitleField.onEndEdit.AddListener((string s) => OnTitleValueChange());
      BodyField.onEndEdit.AddListener((string s) => OnBodyValueChange());
   }

   public void SetMemoForEdit(Memo memo)
   {
      currentMemo = memo;

      TitleField.SetTextWithoutNotify(memo.Title);
      BodyField.SetTextWithoutNotify(memo.Body);
      EffectEditor.LoadListForMemo(memo.effects);
   }


   public void OnTitleValueChange()
   {
      currentMemo.Title = TitleField.text;
      memoList.RefreshButtonList();
   }

   public void OnBodyValueChange()
   {
      currentMemo.Body = BodyField.text;
      memoList.RefreshButtonList();
   }



}
