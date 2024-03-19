using System;
using System.Collections.Generic;

namespace AddedContent.Firebreak
{
    public static partial class Marker
    {
        [AttributeUsage(AttributeTargets.Method)]
        public class PostInitializeAttribute : MarkerAttribute
        {
            public static List<PostInitializeAttribute> All = new();

            public int Priority { get; set; } = 0;

            protected override void Implement()
            {
                All.Add(this);
            }
        }
    }
}