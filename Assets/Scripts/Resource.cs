public enum ResourceType
{
   Pile,
   Scale,
   Flag
}

public class Resource
{
   public Resource(ResourceType type, int value)
   {
      this.type = type;
      this.value = value;
      this.defaultValue = value;
   }

   public readonly ResourceType type;
   public int value;
   public int defaultValue;
}