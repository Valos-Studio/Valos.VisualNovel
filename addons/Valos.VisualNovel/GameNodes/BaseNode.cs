using Godot;

namespace Valos.VisualNovel.GameNodes;

public partial class BaseNode : GraphNode
{
    public override void _Ready()
    {
        GuiInput += OnGuiInput;
    }

    public void OnGuiInput(InputEvent @event)
    {
        if (Input.IsKeyPressed(Key.Delete) == true)
        {
            EmitSignal(nameof(DeleteRequest), this);
        }
    }
}