using System;

using AppKit;
using SpriteKit;
using Foundation;
using CoreGraphics;

namespace SetGame.Settings {

    public static class Positions {
        /*
         * Card Staring Position
         */
        public static double CardCellPadding = 150;
        public static double CardStartingX = 125;
        public static double CardStartingY = 550;

        public static CGPoint CardStartingPoint() {
            return new CGPoint(CardStartingX, CardStartingY);
        }

        //used for placing cards on the card table.
        public static CGPoint CalcCardPosition(int row, int col) {
            return new CGPoint(
                (CardStartingX * col) + (CardCellPadding * col) + CardStartingX,
                CardStartingY + (row * -CardCellPadding)
            );
        }

        /*
         * Shape Positions
         */

        //single shape positions
        public static double SingleShapeX = Sizes.CardHeight / 2f;
        public static double SingleShapeY = 50;

        public static CGPoint SingleShapePosition = 
            new CGPoint(SingleShapeX, SingleShapeY);

        //double shape positions
        public static double DoubleShapeX = 50;
        public static double DoubleShapeY = SingleShapeY;
        public static double DoubleShapePadding = 50;

        public static CGPoint DoubleShapePosition(int col) {
            return new CGPoint(
                (DoubleShapeX * col) + (DoubleShapePadding * col) + DoubleShapeX,
                DoubleShapeY
            );
        }

        //triple shape positions
        public static double TripleShapeX = 37;
        public static double TripleShapeY = SingleShapeY;
        public static double TripleShapePadding = 25;

        public static CGPoint TripleShapePosition(int col) {
            return new CGPoint(
                (TripleShapeX * col) + (TripleShapePadding * col) + TripleShapeX,
                TripleShapeY
            );
        }

    }
}
