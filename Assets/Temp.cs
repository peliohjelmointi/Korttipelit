using UnityEngine;

public class Temp : MonoBehaviour
{
    public Sprite swordImage;

    private void Awake()
    {
        Item sword = new Item("LongSword", swordImage);
    }

}

class Item
{
    string name;
    Sprite image;

    public Item(string name, Sprite image)
    {
        this.name = name;
        this.image = image; 
    }
    
}


