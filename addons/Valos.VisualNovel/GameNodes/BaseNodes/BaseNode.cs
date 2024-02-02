using Godot;

namespace Valos.VisualNovel.GameNodes.BaseNodes;

[Tool]
public partial class BaseNode : GraphNode, ICleanable
{
    public virtual void Clean()
    {
    }
}