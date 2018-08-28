using System;
using System.Linq;
using System.Collections.Generic;

using AppKit;
using SpriteKit;
using Foundation;
using CoreGraphics;

using SetGame.Common;

namespace SetGame {
    /*
     * A Card has 4 attributes:
     * (1) Shape: (Oval, Diamond, Squiggle)
     * (2) Shape Count: (1, 2, 3)
     * (3) Shape Color: (Red, Blue, Purple)
     * (4) Shape Fill: None, Half, Full
     */

    public class Card {

        public CardShape Shape { get; private set; }
        public ShapeCount ShapeCount { get; private set; }
        public ShapeColor ShapeColor { get; private set; }
        public ShapeFill ShapeFill { get; private set; }

        public bool IsClicked { get; private set; }

        private SKShapeNode _node = null;
        public SKShapeNode Node { 
            get {
                if (_node == null) {
                    _node = _CreateNode();
                }
                return _node;
            } 
            private set {
                _node = value;
            }
        }

        public Card(CardShape _shape, ShapeCount _shapeCount, ShapeColor _shapeColor, ShapeFill _shapeFill) {
            Shape = _shape;
            ShapeCount = _shapeCount;
            ShapeColor = _shapeColor;
            ShapeFill = _shapeFill;
            IsClicked = false;

        }

        override public String ToString() {
            return "Card(" + Shape.ToString() + ", " + ShapeCount.ToString() + ", " + ShapeColor.ToString() + ", " + ShapeFill.ToString() + ")";
        }

        private SKShapeNode _CreateNode() {
            //Creating The Card:
            var rectangle = 
                new CGRect(0, 0, Settings.Sizes.CardHeight, Settings.Sizes.CardWidth);
            var card = SKShapeNode.FromRect(rectangle, 5);
            card.FillColor = Settings.Colors.CardBackgroundColor;
            card.StrokeColor = Settings.Colors.CardStrokeColor;


            //Create the Shape Node:

            //TODO: Check the actual shape enum
            var _totalShapes = ShapeCounts.GetInt(ShapeCount);
            var _fillColor = ShapeColors.GetColor(ShapeColor);
            var _shapes = new List<SKShapeNode>(_totalShapes);

            //generate each shape:
            for (int i = 0; i < _totalShapes; i++) {
                SKShapeNode _shapeNode = _GetShape();

                _shapeNode.StrokeColor = _fillColor;
                _shapeNode.LineWidth = 5f;

                switch (ShapeFill) {
                    case ShapeFill.Full:
                        _shapeNode.FillColor = _fillColor;
                    break;

                    case ShapeFill.Half:
                        _shapeNode.FillTexture = SKTexture.FromImageNamed(NSBundle.MainBundle.PathForResource("stripes", "png"));
                        _shapeNode.FillColor = card.FillColor;
                    break;

                    default: //None Case
                        _shapeNode.FillColor = card.FillColor;
                    break;
                }



                switch (ShapeCount) { //can this be done less idiomatic?
                    case ShapeCount.Two:
                        _shapeNode.Position = Settings.Positions.DoubleShapePosition(i);
                    break;

                    case ShapeCount.Three:
                        _shapeNode.Position = Settings.Positions.TripleShapePosition(i);
                    break;

                    default: //case ShapeCount.One: 
                        _shapeNode.Position = Settings.Positions.SingleShapePosition;
                    break;
                }

                _shapes.Add(_shapeNode);

                card.AddChild(_shapeNode);

            }

            return card;
        }


        private SKShapeNode _GetShape() {
            switch (Shape) {
                case CardShape.Diamond: return ShapeFactory.MakeDiamond();
                case CardShape.Sqiqqle: return ShapeFactory.MakeSquiggle();
                default: return ShapeFactory.MakeOval();
            }
        }

        public void Clicked() {
            IsClicked = !IsClicked;
            if (IsClicked) MouseOver();
            else NoMouseOver();
        }

        public void MouseOver() {
            //Node.FillColor = Settings.Colors.CardMouseOverColor;
            Node.Position =
                new CGPoint(Node.Position.X, Node.Position.Y + 10);
        }

        public void NoMouseOver() {
            //Node.FillColor = Settings.Colors.CardBackgroundColor;
            Node.Position =
                new CGPoint(Node.Position.X, Node.Position.Y - 10);
        }



        public static Card GenerateRandomCard() {
            return new Card(
                CardShapes.GetRandom(), 
                ShapeCounts.GetRandom(), 
                ShapeColors.GetRandom(), 
                ShapeFills.GetRandom()
            );
        }

        /*
         * For Two cards to be considered similar:
         * Each Attribute must be all the same, or
         * different.
         */ 
        public static bool IsSimilar(Card A, Card B) {
            //Check Shape:
            var sameShape = A.Shape == B.Shape;
            var sameShapeCount = A.ShapeCount == B.ShapeCount;
            var sameShapeColor = A.ShapeColor == B.ShapeColor;
            var sameShapeFill = A.ShapeFill == B.ShapeFill;

            return sameShape && sameShapeCount && sameShapeColor && sameShapeFill;
        }

        public static bool CheckSet(List<Card> cards) {
            //lots of assumptions being made for now
            var cardA = cards[0];
            var cardB = cards[1];
            var cardC = cards[2];

            return IsSimilar(cardA, cardB) && IsSimilar(cardB, cardC);
        }

    }
}
