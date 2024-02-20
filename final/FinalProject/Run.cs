using System;

public class Run
{
    Player _pc = new Player();
    List<Item> _stock = new List<Item>();
    Random rnd = new Random();

    public Run(Player pc)
    {
        _pc = pc;
    }

    public void Start()
    {
        BackStock();

/* In the end the amount & type of encounters will be randomized,
    but for now to test each encounter I am just running each in order */
        ShopEncounter shop = new ShopEncounter(_pc, _stock);
        shop.Start();

        EnemyEncounter enemyEncounter = new EnemyEncounter(_pc);
        enemyEncounter.Start();

        SpecialEncounter specialEncounter = new SpecialEncounter(_pc);
        specialEncounter.Start();
    }
    
    private void BackStock()
    {
        Item healthPotion = new Item("Health Potion", 5, "A small, clean vial filled with a sweet looking red potion.");
        healthPotion.SetHeal(5);
        _stock.Add(healthPotion);
        Item teddyBear = new Item("Teddy Bear", 2, "An abandoned teddy bear. It seems to look at you with its lonely plastic eyes.");
        _stock.Add(teddyBear);

        Item chestplate = new Item("Leather Chestplate", 10, "A simple leather chestplate. Good for blocking attacks!");
        chestplate.SetDefense(5);
        _stock.Add(chestplate);

        Item quarterStaff = new Item("Quarter Staff", 7, "A sturdy, well made quarterstaff. Deadly in the right hands.");
        quarterStaff.SetDmg(4);
        _stock.Add(quarterStaff);
    }
}