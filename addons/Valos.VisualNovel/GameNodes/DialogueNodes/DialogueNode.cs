using Godot;
using Valos.VisualNovel.GameNodes.BaseNodes;

namespace Valos.VisualNovel.GameNodes.DialogueNodes;

[Tool]
public partial class DialogueNode : BaseNode
{
    public override void _Ready()
    {
        base._Ready();
        
        SlotUpdated += OnSlotUpdated;
    }

    public void OnSlotUpdated(long slotIndex)
    {
        
    }
}