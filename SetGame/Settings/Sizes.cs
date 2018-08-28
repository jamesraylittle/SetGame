using System;

using AppKit;
using SpriteKit;
using Foundation;
using CoreGraphics;

namespace SetGame.Settings {

    public static class Sizes {
        /*
         * Card Size
         */ 
        public static double CardHeight = 200;
        public static double CardWidth = 100;
        public static CGSize CardSize = new CGSize(CardWidth, CardHeight);
        /*
         * Shape Sizes
         */
        public static double OvalHeight = 90;
        public static double OvalWidth = 20;
        public static CGSize OvalSize = new CGSize(OvalWidth, OvalHeight);

        public static double DiamondHeight = 30;
        public static double DiamondWidth = 30;
        public static CGSize DiamondSize = new CGSize(DiamondWidth, DiamondHeight);

        /*
         * Game Table
         */
        public static int TotalRows = 4;
        public static int TotalColumns = 3;


    }
}
