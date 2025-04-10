using System.Collections.Generic; // List löytyy täältä
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CreateCards : MonoBehaviour
{
    public List<Sprite> cardSprites;
    public List<Card> cards = new List<Card>();

    public Transform cardContainer; // kortit tulevat tämän childeiksi
    public GameObject cardPrefab;

    public Sprite cardBackSprite;

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

        //void-tapa (muuttaa suoraan, ei palauta mitään)
        //ShuffleCards();     // ShuffleCards(cards);

        //tämä palauttaa listana
        cards = ShuffleCards2(cards);

        //käyttäen LINQ-kirjastoa:
        //cards = ShuffleWithLINQ();

        ShowCards();
    }

    List<Card> ShuffleWithLINQ()
    {
        return cards.OrderBy(x => Random.value).ToList();
    }

    List<Card> ShuffleCards2(List<Card> cards) 
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card chosenCard = cards[i]; //aluksi herttaässä
            int rand = Random.Range(i, cards.Count);
            cards[i] = cards[rand];
            cards[rand] = chosenCard;
        }
        return cards;
    }

    void ShuffleCards() // void ShuffleCards(List<Card> cards) jos vie parametrina
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card chosenCard = cards[i]; //aluksi herttaässä
            int rand = Random.Range(i,cards.Count);
            cards[i] = cards[rand];
            cards[rand] = chosenCard;
        }
    }

    void ShowCards()
    {
        foreach (Card card in cards)
        {
            GameObject cardObject = Instantiate(cardPrefab, cardContainer);

            Image image = cardObject.GetComponent<Image>();
            Button button = cardObject.GetComponent<Button>();

            //image.sprite = card.sprite;
            image.sprite = cardBackSprite;

            cardObject.name = card.suit.ToString() + " - " + card.value.ToString(); // 1 - 13

            button.onClick.AddListener(delegate { OnCardClicked(card, image); });

            #region onClick_options
            //button.onClick.AddListener(PrintHelloWorld); //toimii JOS ei parametreja
            //button.onClick.AddListener(PrintMoro);

            //button.onClick.AddListener( () =>
            //{
            //    Print("MORO NÄÄS");
            //});

            //button.onClick.AddListener(delegate{Print("hello");});

            //TEHTÄVÄ: LUO OnCardClicked-metodi, ja vie sille
            // tarvittavat tiedot parametreina.
            // Liitä metodi button.onClick:iin.
            // Funktio kääntää kortin "näkyviin" (asettaa spriten)
            #endregion
        }
    }


    void OnCardClicked(Card card, Image img)
    {
        img.sprite = card.sprite;

        Debug.Log(card.value);
    }

    //void Print(string text)
    //{
    //    print(text);
    //}

    //void PrintHelloWorld()
    //{
    //    print("HELLO WRLOD!");
    //}

    //void PrintMoro()
    //{
    //    print("MORO");
    //}


}
