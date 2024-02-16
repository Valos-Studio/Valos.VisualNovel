using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.Extensions;
using Valos.VisualNovel.GameNodes.Lists.Nodes;
using Valos.VisualNovel.NovelPanels.Lists.Connections;

namespace Valos.VisualNovel.GameNodes;

[Tool]
public partial class NovelPanelCode : Node
{
    public StartData StartNode { get; set; }
    public LocationList Locations { get; set; }
    public ConnectionList Connections { get; set; }

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            StartNode = NodeInitializer<StartData>(nameof(StartNode));

            Locations = NodeInitializer<LocationList>(nameof(Locations));

            Connections = NodeInitializer<ConnectionList>(nameof(Connections));
        }
    }

    private T NodeInitializer<T>(string name) where T : Node, new()
    {
        T node;

        if (HasNode(name) == true)
        {
            node = GetNode<T>(name);
        }
        else
        {
            node = new T();

            this.AddChildDeferred(node, name);
        }

        return node;
    }
}