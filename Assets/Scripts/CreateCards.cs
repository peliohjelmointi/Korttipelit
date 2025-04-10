using System.Collections.Generic; // List löytyy täältä
using UnityEngine;
using UnityEngine.UI;

public class CreateCards : MonoBehaviour
{
    public List<Sprite> cardSprites;
    public List<Card> cards = new List<Card>();

    public Transform cardContainer; // kortit tulevat tämän childeiksi
    public GameObject cardPrefab;

    private void Start()
    {
        foreach (Sprite sprite in cardSprites)
        {
            // 1_1
            string[] parts = sprite.name.Split('_');

            cards.Add(
                new Card(
                    sprite, 
                    int.Parse(parts[0]), 
                    int.Parse(parts[1]))
                );

            //if(parts.Length ==2 
            //    && int.TryParse(parts[0], out int suit) 
            //    && int.TryParse(parts[1], out int value))
            //  ){ }

        }
        ShowCards();
    }

    void ShowCards()
    {
        foreach(Card card in cards)
        {
            GameObject cardObject = Instantiate(cardPrefab, cardContainer);
            
            Image image = cardObject.GetComponent<Image>();
            Button button = cardObject.GetComponent<Button>();

            image.sprite = card.sprite;

            cardObject.name = card.suit.ToString() + " - " + card.value.ToString(); // 1 - 13

        }
    }


}
