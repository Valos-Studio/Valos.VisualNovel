using Godot;

namespace Valos.VisualNovel.GameNodes.DialogueNodes;

[Tool]
public partial class DialogueNode : BaseNode
{
    public override void _Ready()
    {
        GuiInput += OnGuiInput;
    }

    public void OnGuiInput(InputEvent @event)
    {
        if (Input.IsKeyPressed(Key.Delete) == true)
        {
            EmitSignal(GraphElement.SignalName.DeleteRequest, this);
            
            GD.PrintErr("Delete pressed");
        }
    }
}