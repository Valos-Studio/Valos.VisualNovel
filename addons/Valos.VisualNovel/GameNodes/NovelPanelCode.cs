using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.EditorNodes.TreeEditors;

namespace Valos.VisualNovel.GameNodes;

[Tool]
public partial class NovelPanelCode : Node
{
    public StartData StartData { get; set; }
    public Node DialogueNodes { get; set; }
    public Node ResponseNodes { get; set; }
    public Node LocationNodes { get; set; }
    
    public ConnectionList ConnectionList { get;}
    
    public NovelPanelCode()
    {
        ConnectionList = new ConnectionList();
    }

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            if (HasNode("StartData") == true)
            {
                StartData = GetNode<StartData>("StartData");
            }
            else
            {
                InitStartData();
            }
            
            if (HasNode(nameof(DialogueNodes)) == true)
            {
                DialogueNodes = GetNode<Node>(nameof(DialogueNodes));
            }
            else
            {
                DialogueNodes = InitNode(nameof(DialogueNodes));
            }

            if (HasNode(nameof(ResponseNodes)) == true)
            {
                ResponseNodes = GetNode<Node>(nameof(ResponseNodes));
            }
            else
            {
                ResponseNodes = InitNode(nameof(ResponseNodes));
            }

            if (HasNode(nameof(LocationNodes)) == true)
            {
                LocationNodes = GetNode<Node>(nameof(LocationNodes));
            }
            else
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