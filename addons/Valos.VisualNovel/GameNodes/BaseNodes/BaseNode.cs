using Godot;

namespace Valos.VisualNovel.GameNodes.BaseNodes;

[Tool]
public partial class BaseNode : GraphNode, ICleanable
{
    protected bool IsModelValid { get; private set; }
    
    public BaseNode()
    {
        IsModelValid = false;
    }

    protected virtual void SetModel()
    {
        IsModelValid = true;
    }
    
    public virtual void Clean()
    {
        IsModelValid = false;
    }
}