using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    public List<Item> inventory = new List<Item>();

    public void StoreItemData(int score, int weight)
    {
        inventory.Add(new Item(score, weight));
    }
}
