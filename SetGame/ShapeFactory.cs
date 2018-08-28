using System;

using SpriteKit;

namespace SetGame {

    //A Class for making the three shapes. I didnt know where else to put these guys.
    public static class ShapeFactory {

        public static SKShapeNode MakeOval() {
            return SKShapeNode.FromRect(Settings.Sizes.OvalSize, 20);
        }

        public static SKShapeNode MakeDiamond() {
            var square = SKShapeNode.FromRect(Settings.Sizes.DiamondSize);
            square.ZRotation = 12;
            return square;
        }
        

    }
}
