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
        if (Engine.IsEditorHint())
        {
            StartData = GetNode<StartData>("StartData");
            
            if (Validator.IsValid(StartData) == false)
            {
                InitStartData();
            }

            DialogueNodes = GetNode<Node>(nameof(DialogueNodes));

            if (Validator.IsValid(DialogueNodes) == false)
            {
                DialogueNodes = InitNode(nameof(DialogueNodes));
            }
            
            ResponseNodes = GetNode<Node>(nameof(ResponseNodes));

            if (Validator.IsValid(ResponseNodes) == false)
            {
                ResponseNodes = InitNode(nameof(ResponseNodes));
            }
            
            LocationNodes = GetNode<Node>(nameof(LocationNodes));

            if (Validator.IsValid(LocationNodes) == false)
            {
                LocationNodes = InitNode(nameof(LocationNodes));
            }
        }
    }

    private void InitStartData()
    {
        StartData = new StartData();

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