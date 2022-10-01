using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

public enum MemoType
{
   Basic,
}


public class Memo
{
   public string Title = "Title";
   public string Body = "Body Text";
   public MemoType Type = MemoType.Basic;

   public List<MemoEffect> effects;

   public Memo(XElement source)
   {
      this.Title = source.Element("Title").Value;
      this.Body = source.Element("Body").Value;
      Enum.TryParse(source.Element("Type").Value, out this.Type);

      effects = new List<MemoEffect>();
      if(source.Element("Effects") is XElement effectXML)
      {
         foreach (XElement effect in effectXML.Elements())
         {
            effects.Add(new MemoEffect(effect));
         }
      }
   }

   public Memo()
   {
      effects = new List<MemoEffect>();
   }


   public XElement GetXML()
   {
      XElement root = new XElement("Memo");
      root.Add(new XElement("Title", Title));
      root.Add(new XElement("Body", Body));
      root.Add(new XElement("Type", Type));

      XElement effectsXML = new XElement("Effects");
      foreach(MemoEffect effect in effects)
      {
         effectsXML.Add(effect.GetXML());
      }
      root.Add(effectsXML);

      return root;
   }


}
