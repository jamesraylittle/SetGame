using System;

using AppKit;
using SpriteKit;
using Foundation;
using CoreGraphics;

namespace SetGame {

    //A Class for making the three shapes. I didnt know where else to put these guys.
    public static class ShapeFactory {

        public static SKShapeNode MakeOval() {
            return SKShapeNode.FromRect(Settings.Sizes.OvalSize, 20);
        }

        public static SKShapeNode MakeDiamond() {
            var square = SKShapeNode.FromRect(Settings.Sizes.DiamondSize);
            square.ZRotation = 44.99999999f;
            return square;
        }

        public static SKShapeNode MakeSquiggle() {
            // new Path
            var shape = SKShapeNode.FromCircle(12.5f);


            //return MakeDiamond();
            return shape;
        }
        

    }
}
