using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimer : MonoBehaviour
{
   public int MemosPerDay = 12;
   private int currentDay = -1;
   private float timer;
   private int memoCunt;
   Queue<Memo> DailyMemos;

   public GameObject MemoPrefab;
   public Transform MemoParent;

   // Update is called once per frame
   void Update()
   {
      if(currentDay < 0)
      {
         return;
      }

      timer += Time.deltaTime;

      if(timer > 10)
      {
         timer = 0;
         ++memoCunt;
         if(memoCunt > MemosPerDay)
         {
            //Day over, do something
            Debug.Log("Day " + currentDay + " is over");
            currentDay = -1;
         }
         else
         {
            Memo nextMemo = DailyMemos.Dequeue();
            GameObject newMemo = Instantiate(MemoPrefab, MemoParent);
            newMemo.GetComponent<InteractableMemo>().InitializeMemo(nextMemo);
         }
      }
   }

   public void StartDay(int dayNumber)
   {
      timer = 10;
      currentDay = dayNumber;
      DailyMemos = MemoManager.Instance.GetMemosForDay(dayNumber, MemosPerDay);
   }

   private void Start()
   {
      StartDay(0);
   }
}
