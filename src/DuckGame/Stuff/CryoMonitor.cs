﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.CryoMonitor
// Assembly: DuckGame, Version=1.1.8175.33388, Culture=neutral, PublicKeyToken=null
// MVID: C907F20B-C12B-4773-9B1E-25290117C0E4
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\Duck Game\DuckGame.exe
// XML documentation location: D:\Program Files (x86)\Steam\steamapps\common\Duck Game\DuckGame.xml

namespace DuckGame
{
    [EditorGroup("survival")]
    [BaggedProperty("isOnlineCapable", false)]
    public class CryoMonitor : Thing
    {
        public CryoMonitor(float xpos, float ypos)
          : base(xpos, ypos)
        {
            graphic = new Sprite("survival/cryoMonitor");
            center = new Vec2(graphic.w / 2, graphic.h / 2);
            _collisionSize = new Vec2(32f, 32f);
            _collisionOffset = new Vec2(-16f, -16f);
            depth = (Depth)0.9f;
            layer = Layer.Foreground;
        }
    }
}
