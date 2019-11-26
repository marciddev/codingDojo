using System;
using System.Collections.Generic;

namespace deckofcards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d = new Deck();
            Player p = new Player("Kevin");
            foreach(Card c in d.cards) {
                Console.WriteLine($"{c.stringVal} {c.suit}");
            }
            d.Shuffle();
            Console.WriteLine("**************************************");
            foreach(Card c in d.cards) {
                Console.WriteLine($"{c.stringVal} {c.suit}");
            }
            Console.WriteLine("*****************************************");
            d.Reset();
            foreach(Card c in d.cards) {
                Console.WriteLine($"{c.stringVal} {c.suit}");
            }
            p.Draw(d);
            foreach(Card c in p.Hand) {
                Console.WriteLine($"{c.stringVal} {c.suit} ");
            }
            foreach(Card c in d.cards) {
                Console.WriteLine($"{c.stringVal} {c.suit}");
            }
        }
    }
    class Card {
        public string stringVal;
        public string suit;
        public int val;
    }
    class Deck {
        public List<Card> cards = new List<Card>();
        public Deck() {
            for(int i=0;i<4;i++) {
                for(int j=0;j<13;j++) {
                    Card card = new Card();
                    if(j == 0) {
                        card.stringVal = "Ace";
                    } else if(j == 10) {
                        card.stringVal = "Jack";
                    } else if(j == 11) {
                        card.stringVal = "Queen";
                    } else if(j == 12) {
                        card.stringVal = "King";
                    } else {
                        card.stringVal = $"{j}";
                    }
                    card.val = j;
                    if(i == 0) {
                        card.suit = "Clubs";
                    } else if(i == 1) {
                        card.suit = "Spades";
                    } else if(i == 2) {
                        card.suit = "Hearts";
                    } else if(i == 3) {
                        card.suit = "Diamonds";
                    }
                    cards.Add(card);

                }
            }
        }
        public Card Deal() {
            Card c = cards[cards.Count-1];
            cards.RemoveAt(cards.Count-1);
            return c;
        }
        public void Reset() {
            cards.Clear();
            for(int i=0;i<4;i++) {
                for(int j=0;j<13;j++) {
                    Card card = new Card();
                    if(j == 0) {
                        card.stringVal = "Ace";
                    } else if(j == 10) {
                        card.stringVal = "Jack";
                    } else if(j == 11) {
                        card.stringVal = "Queen";
                    } else if(j == 12) {
                        card.stringVal = "King";
                    } else {
                        card.stringVal = $"{j}";
                    }
                    card.val = j;
                    if(i == 0) {
                        card.suit = "Clubs";
                    } else if(i == 1) {
                        card.suit = "Spades";
                    } else if(i == 2) {
                        card.suit = "Hearts";
                    } else if(i == 3) {
                        card.suit = "Diamonds";
                    }
                    cards.Add(card);

                }
            }
        }
        public List<Card> Shuffle() {
            Random r = new Random();
            for(int i=0;i<cards.Count;i++) {
                int next = (int)r.Next(0,52);
                Card temp = cards[i];
                cards[i] = cards[next];
                cards[next] = temp;
            }
            return cards;
        }
    }
    class Player {
        public string Name;
        public List<Card> Hand = new List<Card>();
        public Player(string n) {
            Name = n;
        }
        public Card Draw(Deck d) {
            Card drawn = d.Deal();
            Hand.Add(drawn);
            return drawn;
        }
        public Card Discard(int index) {
            if(Hand[index] == null) {
                return null;
            } else {
                return Hand[index];
            }
        }
    }
}
