using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

public class MemoManager : MonoBehaviour
{
   private static MemoManager instance;
   public static MemoManager Instance
   {
      get
      {
         if(instance == null)
         {
            GameObject go = new GameObject("MemoManager");
            instance = go.AddComponent<MemoManager>();
         }
         return instance;
      }
   }

   public const string xmlFileName = "Memos.xml";

   public List<Memo> memos;

   // Start is called before the first frame update
   private void Awake()
   {
      TextAsset text = Resources.Load<TextAsset>(Path.GetFileNameWithoutExtension(xmlFileName));
      XElement root = XDocument.Parse(text.ToString()).Root;
      memos = new List<Memo>();
      if (root.Element("Memos") is XElement memotXML)
      {
         foreach (XElement memo in memotXML.Elements())
         {
            Memo newMemo = new Memo(memo);
            memos.Add(newMemo);
         }
      }

      ResourceManager.Instance.LoadXML(root.Element("Resources"));

      Debug.Log("Loaded " + memos.Count + " memos");
   }
   private void Start()
   {
      DontDestroyOnLoad(this);
      
   }

   private void OnApplicationQuit()
   {
      SaveMemos();
   }


   public void SaveMemos()
   {
#if UNITY_EDITOR
      XElement root = new XElement("Root");
      XElement memos = new XElement("Memos");

      foreach(Memo memo in this.memos)
      {
         memos.Add(memo.GetXML());
      }

      root.Add(memos);

      root.Add(ResourceManager.Instance.GetXML());
      
      XDocument temp = new XDocument(root);
      string path = Application.dataPath + "/Resources/" + xmlFileName;
      File.WriteAllText(path, temp.ToString());
      AssetDatabase.Refresh();

      Debug.Log("Saved " + this.memos.Count + " Memos");
#else
      //throw new System.InvalidOperationException("Save Memo only works in the unity editor");
#endif

   }
}
