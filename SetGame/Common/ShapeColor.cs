using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

using AppKit;

namespace SetGame.Common {

    public enum ShapeColor {
        [Description("Red")]
        Red,
        [Description("Blue")]
        Blue,
        [Description("Purple")]
        Purple
    }

    public static class ShapeColors {
        public static List<ShapeColor> All =
            Enum.GetValues(typeof(ShapeColor)).Cast<ShapeColor>().ToList();

        public static ShapeColor GetRandom() {
            Random gen = new Random();
            var nextIdx = gen.Next(0, All.Capacity);
            return All[nextIdx];
        }

        public static NSColor GetColor(ShapeColor color) {
            switch (color) {
                case ShapeColor.Red: //red
                    return NSColor.Red;


                case ShapeColor.Blue: //Blue
                    return NSColor.Blue;

                default:
                //case CardColor.Purple: //Purple
                    return NSColor.Purple;
            }

        }

    }
}
