using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace SetGame.Common {

    public enum CardShape {
        [Description("Oval")]
        Oval,
        [Description("Sqiggle")]
        Sqiqqle,
        [Description("Diamond")]
        Diamond
    }

    public static class CardShapes {
        public static List<CardShape> All = 
            Enum.GetValues(typeof(CardShape)).Cast<CardShape>().ToList();

        public static CardShape GetRandom() {
            Random gen = new Random();
            var nextIdx = gen.Next(0, All.Capacity);
            return All[nextIdx];
        }
    }

}
