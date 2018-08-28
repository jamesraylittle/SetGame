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
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            var nextIdx = gen.Next(0, All.Capacity);
            return All[nextIdx];
        }

        public static NSColor GetColor(ShapeColor color) {
            switch (color) {
                case ShapeColor.Red: //red
                    return Settings.Colors.RedShapeColor;


                case ShapeColor.Blue: //Blue
                    return Settings.Colors.BlueShapeColor;

                default:
                //case CardColor.Purple: //Purple
                return Settings.Colors.PurpleShapeColor;
            }

        }

    }
}
