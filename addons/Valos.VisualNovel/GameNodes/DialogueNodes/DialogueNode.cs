using Godot;

namespace Valos.VisualNovel.GameNodes.DialogueNodes;

[Tool]
public partial class DialogueNode : BaseNode
{
    public override void _Ready()
    {
        SlotUpdated += OnSlotUpdated;
    }

    public void OnSlotUpdated(long slotIndex)
    {
        
    }
}