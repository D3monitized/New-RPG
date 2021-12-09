using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Item
{
   public string name; 
   public int value;

   public Item(int val, string _name)
   {
      value = val;
      name = _name;
   }
}
