﻿using System;
using System.Collections.Generic;
using System.Linq;
using DuckGame.AddedContent.Drake.PolyRender;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DuckGame;

public static partial class DevConsoleCommands
{
    [DrawingContext(DoDraw = false)]
    public static void TestDraw()
    {
        const float length = 8f;
        Color[] colors =
        {
            new(255, 000, 000),
            new(000, 255, 000),
            new(000, 000, 255),
            new(255, 255, 000),
        };
        Vec2 center = new(length, length);

        PolyRenderer.Tri(center, center.ButX( length, true), center.ButY( length, true), colors[0]);
        PolyRenderer.Tri(center, center.ButX(-length, true), center.ButY( length, true), colors[1]);
        PolyRenderer.Tri(center, center.ButX( length, true), center.ButY(-length, true), colors[2]);
        PolyRenderer.Tri(center, center.ButX(-length, true), center.ButY(-length, true), colors[3]);
    }

    private static readonly List<(string Name, DrawingContextAttribute Attribute)> AllDrawingContexts =
        new Func<List<(string, DrawingContextAttribute)>>(() =>
        {
            List<(string Name, DrawingContextAttribute Attribute)> bigList = new();

            foreach (var item in DrawingContextAttribute.ReflectionMethodsUsing)
            {
                string name = item.Attribute.CustomID ?? item.MemberInfo.Name;
                bigList.Add((name, item.Attribute));
            }

            foreach (var item in DrawingContextAttribute.PrecompiledMethodsUsing)
            {
                string name = item.Attribute.CustomID ?? item.Name;
                bigList.Add((name, item.Attribute));
            }

            return bigList;
        })();

    [DevConsoleCommand(Description = "Toggle the activity of a Drawing Context from it's ID")]
    public static string DoDraw(string id)
    {
        foreach (var item in AllDrawingContexts)
        {
            string lookupName = item.Attribute.CustomID ?? item.Name;

            if (!lookupName.CaselessEquals(id)) 
                continue;
            
            bool prevState = item.Attribute.DoDraw;
            item.Attribute.DoDraw ^= true;
            
            return $"|DGBLUE|Drawing Context [{id}] toggled ({prevState} -> {!prevState})";
        }
        
        return $"|DGRED|No Drawing Context matches id of [{id}]";
    }
}