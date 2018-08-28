using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

using AppKit;
using SpriteKit;
using Foundation;
using CoreGraphics;

using SetGame.Common;

namespace SetGame {

    delegate void MouseOverCard(NSEvent theEvent);

    public class GameScene : SKScene {

        public List<Card> Cards { get; private set; }

        public GameScene(IntPtr handle) : base(handle) {
        }

        public override void DidMoveToView(SKView view) {
            //Load in the "table top"
            SKSpriteNode background = SKSpriteNode.FromImageNamed(NSBundle.MainBundle.PathForResource("bg_1", "jpg"));
            background.Position = new CGPoint(Frame.GetMidX(), Frame.GetMidY());
            background.ScaleTo(Frame.Size);
            background.ZPosition = -1000;
            AddChild(background);




            DealCards();
        }

        public void DealCards() {
            //check if we have cards.
            if (Cards != null && Cards.Capacity > 0) {
                //Remove the Nodes from the Scene
                RemoveChildren(Cards.Select(c => c.Node).ToArray());
                //Delete the List
                Cards.Clear();
            } else 
                Cards = new List<Card>();
            


            //Generate each card and place them on the table.
            for (int row = 0; row < Settings.Sizes.TotalRows; row++) {
                for (int col = 0; col < Settings.Sizes.TotalColumns; col++) {
                    var card = Card.GenerateRandomCard();
                    card.Node.Position = Settings.Positions.CalcCardPosition(row, col);
                    

                    Console.WriteLine("Adding Card To Table => " + card);
                    //Add the card to the list
                    Cards.Add(card);
                    //Add the node to the scene
                    AddChild(card.Node);
                }
            }
        }


        public override void MouseDown(NSEvent theEvent) {

            //Detecting which cards are clicked.
            if (Cards != null) {
                Cards.Where(c => 
                    c.Node.ContainsPoint(theEvent.LocationInNode(this))
                ).ToList().ForEach(c => c.Clicked());

                //If three cards are selected lets check for a Set
                var clickedCards = Cards.Where(c => c.IsClicked).ToList();

                if (clickedCards.Count >= 3) {

                    if (Card.CheckSet(clickedCards)) {
                        clickedCards.ForEach(c => {
                            //Reset the cards State.
                            c.Clicked();
                            //Remove these cards from the set.
                            Cards.Remove(c);
                        });

                        //Remove the Nodes from the Scene.
                        RemoveChildren(clickedCards.Select(c => c.Node).ToArray());
                        //Generate 3 new cards
                        for (int i = 0; i < 3; i++) {
                            var replacementCard = Card.GenerateRandomCard();
                            replacementCard.Node.Position = clickedCards[i].Node.Position;
                            Cards.Add(replacementCard);
                            AddChild(replacementCard.Node);
                        }
                        Console.WriteLine("SET FOUND");
                    } else { //Not a Set Unselect.
                        clickedCards.ForEach(c => c.Clicked());
                        Console.WriteLine("NOT A SET");
                    }

                }



            }



        }

        public override void KeyUp(NSEvent theEvent) {
            if (theEvent.KeyCode == (ushort)NSKey.R) {
                DealCards();
            }
        }

        public override void Update(double currentTime) {
            // Called before each frame is rendered


        } //eom

      
    }
}
