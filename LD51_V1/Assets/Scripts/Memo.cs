using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;


public class Memo
{
   public string Title = "Title";
   public string Body = "Body Text";

   public List<MemoEffect> effects;
   public List<MemoCondition> conditions;

   public bool Repeatable;
   public bool Priority;

   public Memo(XElement source)
   {
      this.Title = source.Element("Title").Value;
      this.Body = source.Element("Body").Value;

      this.Repeatable = (bool)source.Element("Repeatable");
      this.Priority = (bool)source.Element("Priority");

      effects = new List<MemoEffect>();
      if(source.Element("Effects") is XElement effectXML)
      {
         foreach (XElement effect in effectXML.Elements())
         {
            effects.Add(new MemoEffect(effect));
         }
      }
      conditions = new List<MemoCondition>();
      if(source.Element("Conditions") is XElement conditionXML)
      {
         foreach(XElement condition in conditionXML.Elements())
         {
            conditions.Add(new MemoCondition(condition));
         }
      }
   }

   public Memo()
   {
      effects = new List<MemoEffect>();
      conditions = new List<MemoCondition>();
   }

   public bool AllConditionsMet()
   {
      return conditions.TrueForAll(c => c.ConditionFulfilled());
   }

   public XElement GetXML()
   {
      XElement root = new XElement("Memo");
      root.Add(new XElement("Title", Title));
      root.Add(new XElement("Body", Body));

      root.Add(new XElement("Repeatable", Repeatable));
      root.Add(new XElement("Priority", Priority));

      XElement effectsXML = new XElement("Effects");
      foreach(MemoEffect effect in effects)
      {
         effectsXML.Add(effect.GetXML());
      }
      root.Add(effectsXML);

      XElement conditionsXML = new XElement("Conditions");
      foreach(MemoCondition cond in conditions)
      {
         conditionsXML.Add(cond.GetXML());
      }
      root.Add(conditionsXML);

      return root;
   }


}
