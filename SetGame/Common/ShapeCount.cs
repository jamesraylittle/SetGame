using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace SetGame.Common {
    //Really not sure if this is the best way to deal with this, but w\e
    public enum ShapeCount {
        [Description("One")]
        One,
        [Description("Two")]
        Two,
        [Description("Three")]
        Three
    }

    public static class ShapeCounts {
        public static List<ShapeCount> All =
            Enum.GetValues(typeof(ShapeCount)).Cast<ShapeCount>().ToList();

        public static ShapeCount GetRandom() {
            Random gen = new Random();
            var nextIdx = gen.Next(0, All.Capacity);
            return All[nextIdx];
        }

        public static int GetInt(ShapeCount count) {
            switch (count) {
                case ShapeCount.One: return 1;
                case ShapeCount.Two: return 2;
                default: return 3;
            }
        }
    }

}
