using System;
using System.Linq;
using System.Xml.Linq;

public enum conditional
{
   Equal = 0,
   GreaterThen = 1,
   LessThen = 2,
}


public class MemoCondition
{
   public string resource;
   public conditional condition;
   public int targetValue;

   public bool ConditionFulfilled()
   {
      switch (condition)
      {
         case conditional.Equal:
         {
            return ResourceManager.Instance[resource] == targetValue;
         }
         case conditional.GreaterThen:
         {
            return ResourceManager.Instance[resource] > targetValue;
         }
         case conditional.LessThen:
         {
            return ResourceManager.Instance[resource] < targetValue;
         }
      }
      return false;
   }

   public MemoCondition(XElement source)
   {
      this.resource = (string)source.Element("Resource");
      Enum.TryParse(source.Element("Condition").Value, out condition);
      this.targetValue = (int)source.Element("Target");
   }

   public MemoCondition()
   {
      this.resource = ResourceManager.Instance.ResourceTypes.FirstOrDefault();
      this.condition = conditional.Equal;
      this.targetValue = 0;
   }

   public XElement GetXML()
   {
      XElement root = new XElement("Condition");
      root.Add(new XElement("Resource", this.resource));
      root.Add(new XElement("Condition", this.condition));
      root.Add(new XElement("Target", this.targetValue));
      return root;
   }

}