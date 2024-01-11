using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes;

[Tool]
public partial class NovelPanelCode : Node
{
    public StartData StartData { get; set; }
    public Node DialogueNodes { get; set; }
    public Node ResponseNodes { get; set; }
    public Node LocationNodes { get; set; }

    public override void _Ready()
    {
        base._Ready();

        InitStartData();

        DialogueNodes = InitNode(nameof(DialogueNodes));

        ResponseNodes = InitNode(nameof(ResponseNodes));

        LocationNodes = InitNode(nameof(LocationNodes));
    }

    private void InitStartData()
    {
        PackedScene node = GD.Load<PackedScene>("res://addons/Valos.VisualNovel/DataNodes/StartData.tscn");

        StartData = node.Instantiate<StartData>();

        AddChildDeferred(StartData, nameof(StartData));
    }

    private Node InitNode(string name)
    {
        Node property = new Node();

        AddChildDeferred(property, name);

        return property;
    }

    private void AddChildDeferred(Node node, string name)
    {
        CallDeferred(Node.MethodName.AddChild, node);

        node.SetDeferred(Node.PropertyName.Owner, this);

        node.SetDeferred(Node.PropertyName.Name, name);
    }
}