﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.Jetpack
//removed for regex reasons Culture=neutral, PublicKeyToken=null
// MVID: C907F20B-C12B-4773-9B1E-25290117C0E4
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\Duck Game\DuckGame.exe
// XML documentation location: D:\Program Files (x86)\Steam\steamapps\common\Duck Game\DuckGame.xml

using System;

namespace DuckGame
{
    [EditorGroup("Equipment")]
    [BaggedProperty("previewPriority", true)]
    public class Jetpack : Equipment
    {
        public StateBinding _onBinding = new StateBinding(nameof(_on));
        public StateBinding _heatBinding = new StateBinding(nameof(_heat));
        protected SpriteMap _sprite;
        public bool _on;
        public float _heat;

        public Jetpack(float xpos, float ypos)
          : base(xpos, ypos)
        {
            _sprite = new SpriteMap("jetpack", 16, 16);
            graphic = _sprite;
            center = new Vec2(8f, 8f);
            collisionOffset = new Vec2(-5f, -5f);
            collisionSize = new Vec2(11f, 12f);
            _offset = new Vec2(-3f, 3f);
            _equippedDepth = -15;
            _jumpMod = true;
            thickness = 0.1f;
            _wearOffset = new Vec2(-2f, 0f);
            editorTooltip = "Allows you to fly like some kind of soaring bird.";
        }

        public override void OnPressAction() => _on = true;

        public override void OnReleaseAction() => _on = false;

        public override void Update()
        {
            base.Update();
            _sprite.frame = (int)(_heat * 7.0);
            if (_equippedDuck != null)
            {
                float num1 = 0f;
                _offset = new Vec2(-3f, 3f);
                angle = 0f;
                if (_equippedDuck.sliding && _equippedDuck._trapped == null)
                {
                    if (_equippedDuck.offDir > 0)
                        angle = -1.570796f;
                    else
                        angle = 1.570796f;
                    _offset.y += 12f;
                    num1 -= 6f;
                }
                if (_equippedDuck.crouch && !_equippedDuck.sliding)
                    _offset.y += 4f;
                collisionOffset = new Vec2(0f, -9999f);
                collisionSize = new Vec2(0f, 0f);
                solid = false;
                PhysicsObject physicsObject1 = _equippedDuck;
                if (_equippedDuck._trapped != null)
                    physicsObject1 = _equippedDuck._trapped;
                else if (_equippedDuck.ragdoll != null && _equippedDuck.ragdoll.part1 != null)
                    physicsObject1 = _equippedDuck.ragdoll.part1;
                _sprite.flipH = _equippedDuck._sprite.flipH;
                if (_on && _heat < 1.0)
                {
                    if (_equippedDuck._trapped == null && _equippedDuck.crouch)
                        _equippedDuck.sliding = true;
                    if (isServerForObject)
                        Global.data.jetFuelUsed.valueFloat += Maths.IncFrameTimer();
                    _heat += 11f / 1000f;
                    if (physicsObject1 is RagdollPart)
                    {
                        ++Global.data.timeJetpackedAsRagdoll;
                        float angle = this.angle;
                        this.angle = physicsObject1.angle;
                        Vec2 vec2_1 = Offset(new Vec2(0f, 8f));
                        Level.Add(new JetpackSmoke(vec2_1.x, vec2_1.y));
                        this.angle = angle;
                        Vec2 vec2_2 = physicsObject1.velocity;
                        if (vec2_2.length < 7f)
                        {
                            RagdollPart ragdollPart = physicsObject1 as RagdollPart;
                            ragdollPart.addWeight = 0.2f;
                            _equippedDuck.ragdoll.jetting = true;
                            float num2 = -(physicsObject1.angle - 1.5707964f);
                            Vec2 vec2_3 = Vec2.Zero;
                            vec2_2 = _equippedDuck.inputProfile.leftStick;
                            if (vec2_2.length > 0.1f)
                            {
                                vec2_3 = new Vec2(_equippedDuck.inputProfile.leftStick.x, -_equippedDuck.inputProfile.leftStick.y);
                            }
                            else
                            {
                                vec2_3 = new Vec2(0f, 0f);
                                if (_equippedDuck.inputProfile.Down("LEFT"))
                                    --vec2_3.x;
                                if (_equippedDuck.inputProfile.Down("RIGHT"))
                                    ++vec2_3.x;
                                if (_equippedDuck.inputProfile.Down("UP"))
                                    --vec2_3.y;
                                if (_equippedDuck.inputProfile.Down("DOWN"))
                                    ++vec2_3.y;
                            }
                            if (vec2_3.length < 0.1f)
                                vec2_3 = new Vec2((float)Math.Cos(num2), (float)-Math.Sin(num2));
                            PhysicsObject physicsObject2 = physicsObject1;
                            physicsObject2.velocity += vec2_3 * 1.5f;
                            if (ragdollPart.doll != null && ragdollPart.doll.part1 != null && ragdollPart.doll.part2 != null && ragdollPart.doll.part3 != null)
                            {
                                ragdollPart.doll.part1.extraGravMultiplier = 0.4f;
                                ragdollPart.doll.part2.extraGravMultiplier = 0.4f;
                                ragdollPart.doll.part3.extraGravMultiplier = 0.7f;
                            }
                        }
                    }
                    else
                    {
                        Level.Add(new JetpackSmoke(x, y + 8f + num1));
                        if (angle > 0f)
                        {
                            if (physicsObject1.hSpeed < 6f)
                                physicsObject1.hSpeed += 0.9f;
                        }
                        else if (angle < 0f)
                        {
                            if (physicsObject1.hSpeed > -6f)
                                physicsObject1.hSpeed -= 0.9f;
                        }
                        else if (physicsObject1.vSpeed > -4.5f)
                            physicsObject1.vSpeed -= 0.38f;
                    }
                }
                if (_heat >= 1f)
                    _on = false;
                if (!physicsObject1.grounded)
                    return;
                if (_heat > 0f)
                    _heat -= 0.25f;
                else
                    _heat = 0f;
            }
            else
            {
                _sprite.flipH = false;
                collisionOffset = new Vec2(-5f, -5f);
                collisionSize = new Vec2(11f, 12f);
                solid = true;
            }
        }
    }
}