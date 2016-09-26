using System;
using Bridge.Html5;

namespace BridgeBreakout
{
    public interface IGameSpace
    {
        Action<MouseEvent> OnMouseMove { get; set; }

        int Left { get; }
        int Top { get; }

        int Width { get; }
        int Height { get; }
    }
}