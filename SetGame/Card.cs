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

            //Create the Shape Node:

            //TODO: Check the actual shape enum
            var _totalShapes = ShapeCounts.GetInt(ShapeCount);
            //var _totalShapes = 1;
            var _fillColor = ShapeColors.GetColor(ShapeColor);
            var _shapes = new List<SKShapeNode>(_totalShapes);

            //generate each shape:
            for (int i = 0; i < _totalShapes; i++) {
                SKShapeNode _shapeNode =
                    SKShapeNode.FromRect(Settings.Sizes.OvalSize, 20);

                _shapeNode.FillColor = _fillColor;

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

                _shapeNode.Position = Settings.Positions.TripleShapePosition(i);
                _shapes.Add(_shapeNode);

            }

            _shapes.ForEach(card.AddChild);

            return card;
        }

        public static Card GenerateRandomCard() {
            return new Card(
                CardShapes.GetRandom(), 
                ShapeCounts.GetRandom(), 
                ShapeColors.GetRandom(), 
                ShapeFills.GetRandom()
            );
        }
    }
}
