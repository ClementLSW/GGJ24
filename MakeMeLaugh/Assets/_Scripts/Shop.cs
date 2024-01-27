using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Item> Boots;
    public List<Item> Fertilizers;
    public List<Item> Seeds;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void InitializeShop()
    {
        Boots.Add(new Item("B_1", "Holey Boots", "This is a PoS", 10));
        Boots.Add(new Item("B_2", "Georgie Boots", "You'll float too", 30));
        Boots.Add(new Item("B_3", "Danksoles 9000", "hehe funny 42069", 69));
        Boots.Add(new Item("B_4", "Boots McBootface", "Bootiest Boot to ever Boot", 100));
        Boots.Add(new Item("B_5", "Yeet Feet Express", "Yeetus Fetus Deletus \n- DragonEngineer", 420));

        Fertilizers.Add(new Item("F_1", "Last Night's Left over", "Dinner wasn't the best...", 10));
        Fertilizers.Add(new Item("F_2", "Last Night's Dinner", "This was what you managed to eat", 30));
        Fertilizers.Add(new Item("F_3", "Fermented Tater", "Is this considered cannibalism?", 69));
        Fertilizers.Add(new Item("F_4", "Soylent Green", "On second thought, Last night's dinner wasn't too bad", 100));
        Fertilizers.Add(new Item("F_5", "Actual Nitrate Fertilizers", "I ran out of joke fertilizer ideas \n- Clement", 420));

        Seeds.Add(new Item("S_1", "Basic Potat", "Its a potato...", 10));
        Seeds.Add(new Item("S_2", "Couch Potato", "For legal reasons, please do not yeet your lazy friend", 30));
        Seeds.Add(new Item("S_3", "Mashed Potato", "How does it even grow???", 69));
        Seeds.Add(new Item("S_4", "Not a Potato", "Potatoes, Tomatoes", 100));
        Seeds.Add(new Item("S_5", "Baked Potato", "BLAZE IT", 420));
    }
}

public class Item : MonoBehaviour
{
    public string ID;
    public string Name;
    public string Description;
    public int Cost;

    public Item(string id, string name, string desc, int cost)
    {
        ID = id;
        Name = name;
        Description = desc;
        Cost = cost;
    }
}