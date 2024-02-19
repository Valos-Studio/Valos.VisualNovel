using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.Extensions;
using Valos.VisualNovel.GameNodes.Lists.Nodes;
using Valos.VisualNovel.NovelPanels.Lists.Connections;

namespace Valos.VisualNovel.GameNodes;

[Tool]
public partial class NovelPanelCode : Node
{
    [Export()] public StartData StartNode { get; set; }
    [Export()] public LocationList Locations { get; set; }
    [Export()] public ConnectionList Connections { get; set; }

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            StartNode = this.NodeInitializer<StartData>(nameof(StartNode));

            Locations = this.NodeInitializer<LocationList>(nameof(Locations));
            
            Connections = this.NodeInitializer<ConnectionList>(nameof(Connections));
        }
    }
}