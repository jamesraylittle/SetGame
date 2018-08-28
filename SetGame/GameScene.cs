﻿using System;

using AppKit;
using SpriteKit;
using Foundation;
using CoreGraphics;

using SetGame.Common;

namespace SetGame {
    public class GameScene : SKScene {

        public GameScene(IntPtr handle) : base(handle) {
        }

        public override void DidMoveToView(SKView view) {
            //Load in the "table top"
            SKSpriteNode background = SKSpriteNode.FromImageNamed(NSBundle.MainBundle.PathForResource("bg", "jpeg"));
            background.Position = new CGPoint(Frame.GetMidX(), Frame.GetMidY());
            background.ScaleTo(Frame.Size);
            background.ZPosition = -1000;
            AddChild(background);

            //Generate each card and place them on the table.
            for (int row = 0; row < Settings.Sizes.TotalRows; row++) {
                for (int col = 0; col < Settings.Sizes.TotalColumns; col++) {
                    var card = Card.GenerateRandomCard();
                    card.Node.Position = Settings.Positions.CalcCardPosition(row, col);
                    Console.WriteLine("Adding Card To Table => " + card);
                    AddChild(card.Node);
                }
            }

        }

        public override void MouseDown(NSEvent theEvent) {
            //do nothing for now.
            Console.WriteLine(Card.GenerateRandomCard());
        }

        public override void Update(double currentTime) {
            // Called before each frame is rendered
        }

        private void drawOvalRectangle(double x, double y) {
            Console.WriteLine("Rect X: " + x + ", Rect Y: " + y);
            var rectangle = new CGRect(x, y, 200, 100);
            var card = SKShapeNode.FromRect(rectangle, 5);
            var oval = SKShapeNode.FromRect(new CGSize(100, 33.33), 20);
            card.FillColor = NSColor.DarkGray;

            oval.FillColor = NSColor.Blue;
            oval.Position = new CGPoint(x + 100, y + 50);

            card.AddChild(oval);

            AddChild(card);
        }


        private void drawRectangle(double x, double y) {
            /*Console.WriteLine("Rect X: " + x + ", Rect Y: " + y);
            var rectangle = new CGRect(x, y, 200, 100);
            var card = SKShapeNode.FromRect(rectangle, 5);
            //var oval = SKShapeNode.
            card.FillColor = NSColor.DarkGray;

            oval.FillColor = NSColor.Blue;
            oval.Position = new CGPoint(x + 100, y + 50);

            card.AddChild(oval);

            AddChild(card);*/
        }
    }
}
