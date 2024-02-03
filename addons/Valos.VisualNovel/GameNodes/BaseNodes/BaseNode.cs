using Godot;

namespace Valos.VisualNovel.GameNodes.BaseNodes;

[Tool]
public partial class BaseNode : GraphNode, ICleanable
{
    protected bool isModelValid;

    public BaseNode()
    {
        isModelValid = false;
    }
    
    public virtual void Clean()
    {
        isModelValid = false;
    }
}