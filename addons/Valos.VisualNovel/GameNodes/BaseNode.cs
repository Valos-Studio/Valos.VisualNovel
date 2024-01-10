using Godot;

namespace Valos.VisualNovel.GameNodes;

[Tool]
public partial class BaseNode : GraphNode
{
    public override void _Ready()
    {
        GuiInput += OnGuiInput;
    }

    public void OnGuiInput(InputEvent @event)
    {
        
    }
}