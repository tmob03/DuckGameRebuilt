﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.SinWave
// Assembly: DuckGame, Version=1.1.8175.33388, Culture=neutral, PublicKeyToken=null
// MVID: C907F20B-C12B-4773-9B1E-25290117C0E4
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\Duck Game\DuckGame.exe
// XML documentation location: D:\Program Files (x86)\Steam\steamapps\common\Duck Game\DuckGame.xml

using System;

namespace DuckGame
{
    public class SinWave : IAutoUpdate
    {
        private float _increment;
        private float _wave;
        private float _value;

        public float value
        {
            get => this._value;
            set => this._value = value;
        }

        public float normalized => (float)((_value + 1.0) / 2.0);

        public SinWave(float inc, float start = 0f)
        {
            this._increment = inc;
            this._wave = start;
            AutoUpdatables.Add(this);
        }

        public SinWave()
        {
            this._increment = 0.1f;
            this._wave = 0f;
        }

        public void Update()
        {
            this._wave += this._increment;
            this._value = (float)Math.Sin(_wave);
        }

        public static implicit operator float(SinWave val) => val.value;

        public static implicit operator SinWave(float val) => new SinWave(val);
    }
}
