using UnityEngine;

public class Card 
{
    public Sprite sprite; //this.sprite viittaa t�h�n
    public int suit;
    public int value;

    public Card(Sprite sprite, int suit, int value)
    {
        this.sprite = sprite;
        this.suit = suit;
        this.value = value;
    }

    // t�nne voisi tehd� funktion, joka palauttaa esim "Ace of Spades"
}
