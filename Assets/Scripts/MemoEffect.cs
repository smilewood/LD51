﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class MemoEffect
{
   public string resource;
   public int change;

   public MemoEffect(XElement source)
   {
      this.resource = (string)source.Element("Resource");
      this.change = (int)source.Element("Ammount");
   }

   public MemoEffect()
   {
      resource = ResourceManager.Instance.ResourceTypes.FirstOrDefault();
      change = 0;
   }

   public XElement GetXML()
   {
      XElement result = new XElement("Effect");
      result.Add(new XElement("Resource", resource));
      result.Add(new XElement("Ammount", change));
      return result;
   }
}