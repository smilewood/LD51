using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using UnityEngine;

public class ResourceManager
{
   private static ResourceManager instance;
   public static ResourceManager Instance
   {
      get
      {
         if(instance == null)
         {
            instance = new ResourceManager();
         }
         return instance;
      }
   }

   Dictionary<string, Resource> resources;

   private ResourceManager()
   {
      resources = new Dictionary<string, Resource>
      {
         { "Day", new Resource(ResourceType.Pile, 0) }
      };
   }

   public IEnumerable<string> ResourceTypes
   {
      get
      {
         return resources.Keys;
      }
   }

   public int this[string key]
   {
      get
      {
         return resources[key].value;
      }
      set
      {
         switch (resources[key].type)
         {
            case ResourceType.Pile:
            {
               resources[key].value = value;
               break;
            }
            case ResourceType.Scale:
            {
               resources[key].value = value > 0 ? (value < 100 ? value : 100) : 0;
               break;
            }
            case ResourceType.Flag:
            {
               resources[key].value = value <= 0 ? 0 : 1;
               break;
            }
         }
      }
   }

   public void AddResource(string resource, int change, ResourceType type = ResourceType.Pile)
   {
      if (!resources.ContainsKey(resource))
      {
         resources.Add(resource, new Resource(type, change));
      }
      else
      {
         resources[resource].value += change;
      }
   }

   public void RemoveResource(string resource)
   {
      resources.Remove(resource);
   }


   public XElement GetXML()
   {
      XElement root = new XElement("Resources");
      foreach(string res in resources.Keys.Where((r)=> r != "Day"))
      {
         XElement resource = new XElement(res);
         resource.Add(new XElement("Type", resources[res].type));
         resource.Add(new XElement("DefaultValue", resources[res].defaultValue));
         root.Add(resource);
      }
      return root;
   }
   public void LoadXML(XElement source)
   {
      if(source is XElement element)
      {
         foreach (XElement res in element.Elements())
         {
            Enum.TryParse(res.Element("Type").Value, out ResourceType resType);
            resources.Add(res.Name.LocalName, new Resource(resType, (int)res.Element("DefaultValue")));
         }
      }
      Debug.Log("Loaded " + resources.Count + " resources");
   }
}
