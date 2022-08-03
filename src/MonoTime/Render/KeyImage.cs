﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.KeyImage
// Assembly: DuckGame, Version=1.1.8175.33388, Culture=neutral, PublicKeyToken=null
// MVID: C907F20B-C12B-4773-9B1E-25290117C0E4
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\Duck Game\DuckGame.exe
// XML documentation location: D:\Program Files (x86)\Steam\steamapps\common\Duck Game\DuckGame.xml

namespace DuckGame
{
    public class KeyImage : Sprite
    {
        private FancyBitmapFont _font;
        private Sprite _keySprite;
        private string _keyString;

        public KeyImage(char key)
        {
            _font = new FancyBitmapFont("smallFont");
            _keySprite = new Sprite("buttons/keyboard/key");
            _keyString = key.ToString() ?? "";
            _texture = _keySprite.texture;
        }

        public override void Draw()
        {
            _keySprite.position = position;
            _keySprite.alpha = alpha;
            _keySprite.color = color;
            _keySprite.depth = depth;
            _keySprite.scale = scale;
            _keySprite.Draw();
            _font.scale = scale;
            _font.Draw(_keyString, position + new Vec2((float)(_keySprite.width * _keySprite.scale.x / 2.0 - _font.GetWidth(_keyString) / 2.0 - 1.0), 2f * _keySprite.scale.y), new Color(20, 32, 34), depth + 2);
        }
    }
}
