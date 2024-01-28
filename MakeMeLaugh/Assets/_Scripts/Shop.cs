using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Color error_red = new(255, 78, 78);

    bool initialized = false;

    public List<Item> Boots;
    public List<Item> Fertilizers;
    public List<Item> Seeds;

    public List<Sprite> B_Sprites;
    public List<Sprite> F_Sprites;
    public List<Sprite> S_Sprites;

    public Image B_Sprite;
    public Image F_Sprite;
    public Image S_Sprite;

    public TMP_Text BootNameLabel;
    public TMP_Text FertilizerNameLabel;
    public TMP_Text SeedNameLabel;

    public TMP_Text BootDescLabel;
    public TMP_Text FertilizerDescLabel;
    public TMP_Text SeedDescLabel;

    public TMP_Text BootCostLabel;
    public TMP_Text FertilizerCostLabel;
    public TMP_Text SeedCostLabel;

    public Button bootBuyBtn;
    public Button FertilizerBuyBtn;
    public Button SeedBuyBtn;

    public TMP_Text ErrorLabel;

    GameMaster gamemaster;
    UIManager ui;

    private void Awake()
    {
        gamemaster = GetComponent<GameMaster>();
        ui = GetComponent<UIManager>();
        Boots = new List<Item>();
        Fertilizers = new List<Item>();
        Seeds = new List<Item>();

        if (!initialized)
        {
            InitializeShop();
        }
    }

    public void InitializeShop()
    {
        Item i = null;
        i = new Item("B_1", "Holey Boots", "This is a PoS", 10);
        Boots.Add(i);
        i = new Item("B_2", "Georgie Boots", "You'll float too", 30);
        Boots.Add(i);
        i = new Item("B_3", "Danksoles 9000", "hehe funny 42069", 69);
        Boots.Add(i);
        i = new Item("B_4", "Boots McBootface", "Bootiest Boot to ever Boot", 100);
        Boots.Add(i);
        i = new Item("B_5", "Yeet Feet Express", "Yeetus Fetus Deletus \n- DragonEngineer", 420);
        Boots.Add(i);

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

        initialized = true;
        //UpdateShop();
    }

    public void BuyBoot()
    {
        Item nextBoot = Boots[gamemaster.BootLevel];

        if(gamemaster.gold >= nextBoot.Cost)
        {
            gamemaster.gold -= nextBoot.Cost;
            gamemaster.BootLevel++;
            if (gamemaster.BootLevel >= Boots.Count)
            {
                BootNameLabel.color = error_red;
                BootNameLabel.text = "Sold out";
                BootDescLabel.text = "";
                BootCostLabel.text = "";
                bootBuyBtn.interactable = false;
                B_Sprite.color = new Color(0, 0, 0, 0);
            }
            UpdateShop();
        }
        else
        {
            ErrorLabel.text = "Bro (Gender Neutral), you're broke.";
        }
    }

    public void BuyFertilizer()
    {
        Item nextFertilizer = Fertilizers[gamemaster.FertilizerLevel];

        if (gamemaster.gold >= nextFertilizer.Cost)
        {
            gamemaster.gold -= nextFertilizer.Cost;
            gamemaster.FertilizerLevel++;
            if (gamemaster.FertilizerLevel >= Fertilizers.Count)
            {
                FertilizerNameLabel.color = error_red;
                FertilizerNameLabel.text = "Sold out";
                FertilizerDescLabel.text = "";
                FertilizerCostLabel.text = "";
                FertilizerBuyBtn.interactable = false;
                F_Sprite.color = new Color(0,0,0,0);
            }
            UpdateShop();
        }
        else
        {
            ErrorLabel.text = "Bro (Gender Neutral), you're broke.";
        }
    }

    public void BuySeed()
    {
        Item nextSeed = Seeds[gamemaster.SeedLevel];

        if (gamemaster.gold >= nextSeed.Cost)
        {
            gamemaster.gold -= nextSeed.Cost;
            gamemaster.SeedLevel++;
            if (gamemaster.SeedLevel >= Seeds.Count)
            {
                SeedNameLabel.color = error_red;
                SeedNameLabel.text = "Sold out";
                SeedDescLabel.text = "";
                SeedCostLabel.text = "";
                SeedBuyBtn.interactable = false;
                S_Sprite.color = new Color(0, 0, 0, 0);
            }
            UpdateShop();
        }
        else
        {
            ErrorLabel.text = "Bro (Gender Neutral), you're broke.";
        }
    }

    public void OnEnable()
    {
        UpdateShop();
    }

    public void UpdateShop()
    {
        if(!initialized)
        {
            InitializeShop();
        }

        if(gamemaster.BootLevel < Boots.Count)
        {
            BootNameLabel.text = Boots[gamemaster.BootLevel].Name;
            BootDescLabel.text = Boots[gamemaster.BootLevel].Description;
            BootCostLabel.text = $"$ {Boots[gamemaster.BootLevel].Cost}";
            B_Sprite.sprite = B_Sprites[gamemaster.BootLevel];
        }

        if(gamemaster.FertilizerLevel < Fertilizers.Count)
        {
            FertilizerNameLabel.text = Fertilizers[gamemaster.FertilizerLevel].Name;
            FertilizerDescLabel.text = Fertilizers[gamemaster.FertilizerLevel].Description;
            FertilizerCostLabel.text = $"$ {Fertilizers[gamemaster.FertilizerLevel].Cost}";
            F_Sprite.sprite = F_Sprites[gamemaster.FertilizerLevel];
        }

        if(gamemaster.SeedLevel < Seeds.Count)
        {
            SeedNameLabel.text = Seeds[gamemaster.SeedLevel].Name;
            SeedDescLabel.text = Seeds[gamemaster.SeedLevel].Description;
            SeedCostLabel.text = $"$ {Seeds[gamemaster.SeedLevel].Cost}";
            S_Sprite.sprite = S_Sprites[gamemaster.SeedLevel];
        }

        ui.UpdateUI();
    }
}

public class Item
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