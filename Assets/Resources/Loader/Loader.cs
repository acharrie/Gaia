﻿using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{

    public const string cardLoaderPath = "Loader/cards";
    public const string deckLoaderPath = "Loader/decks";
    public const string deckCardLoaderPath = "Loader/deck_cards";

    void Start() 
    {
        CardContainer cc = CardContainer.Load(cardLoaderPath);
        DeckContainer dc = DeckContainer.Load(deckLoaderPath);
        DeckCardContainer dcc = DeckCardContainer.Load(deckCardLoaderPath);

        foreach (Card card in cc.cards)
        {
            InstantiateCard(card.name, card.level, card.power, card.lifePoints, card.description);
        }

        foreach (Deck deck in dc.decks)
        {
            Debug.Log(deck.name);
        }

        foreach (DeckCard deckCard in dcc.deckCards)
        {
            Debug.Log(deckCard.name);
        }
	}

    private GameObject InstantiateCard(string name, int level, int power, int lifePoints, string description)
    {

        GameObject cardGameObject = (GameObject)Instantiate(Resources.Load("Card/Card"));
        cardGameObject.transform.SetParent(GameObject.Find("HAND").transform);
        cardGameObject.GetComponent<CardUI>().setLabels(name, level, power, lifePoints, description);

        return cardGameObject;
    }

}