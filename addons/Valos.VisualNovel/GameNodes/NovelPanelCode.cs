using Godot;
using Valos.VisualNovel.GameNodes.StartNodes;

namespace Valos.VisualNovel.GameNodes;

[Tool]
public partial class NovelPanelCode : Node
{
    public StartNode StartNode { get; set; }
    public Node DialogueNodes { get; set; }
    public Node ResponseNodes { get; set; }
    public Node LocationNodes { get; set; }

    public override void _Ready()
    {
        base._Ready();

        DialogueNodes = InitNode(nameof(DialogueNodes));

        ResponseNodes = InitNode(nameof(ResponseNodes));

        LocationNodes = InitNode(nameof(LocationNodes));
    }

    // private StartNode InitStartNode()
    // {
    // }

    private Node InitNode(string name)
    {
        Node property = new Node();

        CallDeferred(Node.MethodName.AddChild, property);

        property.SetDeferred(Node.PropertyName.Owner, this);

        property.SetDeferred(Node.PropertyName.Name, name);

        return property;
    }
}