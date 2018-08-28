using System;

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

            //Figuring out card placement.
            var startingX = 125;
            var startingY = 550;

            var padding = 150;
            for (int row = 0; row < 4; row++) {
                for (int col = 0; col < 3; col++) {
                    var deltaX = (startingX * col) + (padding * col) + startingX;
                    var deltaY = startingY + (row * -padding);

                    drawOvalRectangle(deltaX, deltaY);
                }
            }
        }

        public override void MouseDown(NSEvent theEvent) {
            //do nothing for now.
            Console.WriteLine(CardShapes.GetRandom());
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
