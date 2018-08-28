using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace SetGame.Common {

    public enum ShapeFill {
        [Description("None")]
        None,
        [Description("Half")]
        Half,
        [Description("Full")]
        Full
    }

    public static class ShapeFills {
        public static List<ShapeFill> All =
            Enum.GetValues(typeof(ShapeFill)).Cast<ShapeFill>().ToList();

        public static ShapeFill GetRandom() {
            Random gen = new Random();
            var nextIdx = gen.Next(0, All.Capacity);
            return All[nextIdx];
        }
    }

}
