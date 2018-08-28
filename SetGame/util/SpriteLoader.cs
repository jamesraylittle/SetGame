using System;
using System.Collections.Generic;

using SpriteKit;
using Foundation;


//The whole purpose of this class is to aid in loading all the sprites into memory.
//with easy indexing.

namespace SetGame.util {

    public class SpriteLoader {

        public string Folder { get; private set; }
        public Dictionary<string, SKTexture> Sprites { get; private set; } = new Dictionary<string, SKTexture>();

        public SpriteLoader(string folder = ".") {
            string[] _spritePaths = NSBundle.MainBundle.PathsForResources("png", folder);
            foreach (var spriteLocation in _spritePaths) {
                var lastSlash = spriteLocation.LastIndexOf('/');
                var newString = spriteLocation.Substring(lastSlash + 1);

                var spriteName = newString.Substring(0, newString.Length - 4);

                Sprites.Add(spriteName, SKTexture.FromImageNamed(spriteLocation));

            }
        }

    }
}
