[![Build status](https://ci.appveyor.com/api/projects/status/n1iwqupmc7rrr94t?svg=true)](https://ci.appveyor.com/project/Elgolfin/pokerbot)

PokerBot
========

A small standalone console application to build a Poker Bot.
I am building it from scratch during my free time with TDD in mind.

## Installation

TBD

## Usage

### How to use the Poker Hand Analyzer

#### Analyzing a poker hand
```
using Nicomputer.PokerBot.Cards;
using Nicomputer.PokerBot.Cards.Hands;

var hands = new List<PokerHand>();
var analyzer = new PokerHandAnalyzer();
var myHand = new PokerHand(new HoleCards("Qs", "Qc"), new CardsCollection("Kh Ks 7d Ad Th"));
hands.Add(analyzer.GetPokerHand(myHand));
Console.WriteLine($"{myHand}"); // Displays: Hole Cards[QsQc] and Board[Kh Ks 7d Ad Th]. Best Poker Hand is TwoPairs.
```

#### Comparing two poker hands
```
myHand = new PokerHand(new HoleCards("As", "Ac"), new CardsCollection("Kh Ks 7d Jd Th"));
hands.Add(analyzer.GetPokerHand(myHand));
Console.WriteLine(hands[0].CompareTo(hands[1])); // Displays: 1
```

#### Sorting two or more poker hands
```
myHand = new PokerHand(new HoleCards("As", "Ah"), new CardsCollection("Ad Kh Th Jh Qh"));
hands.Add(analyzer.GetPokerHand(myHand));
foreach (var hand in hands)
{
	Console.WriteLine(hand);
}
// Displays:
// Hole Cards[QsQc] and Board[Kh Ks 7d Ad Th]. Best Poker Hand is TwoPairs.
// Hole Cards[AsAc] and Board[Kh Ks 7d Jd Th]. Best Poker Hand is TwoPairs.
// Hole Cards[AsAh] and Board[Ad Kh Th Jh Qh]. Best Poker Hand is StraightFlush.

hands.Sort();
foreach (var hand in hands)
{
	Console.WriteLine(hand);
}
// Displays:
// Hole Cards[AsAh] and Board[Ad Kh Th Jh Qh]. Best Poker Hand is StraightFlush.
// Hole Cards[AsAc] and Board[Kh Ks 7d Jd Th]. Best Poker Hand is TwoPairs.
// Hole Cards[QsQc] and Board[Kh Ks 7d Ad Th]. Best Poker Hand is TwoPairs.
```



## Tests

Unit Tests direclty accessible within the solution [here](https://github.com/Elgolfin/PokerBot/tree/master/PokerBotUnitTests)

## Contributing

TBD

## Useful Links
* https://rip94550.wordpress.com/2011/03/14/poker-hands-%E2%80%93-5-card-draw/

## Roadmap

* [See here](https://github.com/Elgolfin/PokerBot/blob/master/Roadmap.md)

## Release History

* 0.1.0 Initial release