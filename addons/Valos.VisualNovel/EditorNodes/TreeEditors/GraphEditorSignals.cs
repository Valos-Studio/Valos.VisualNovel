using Godot;
using Godot.Collections;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public partial class GraphEditor
{
    private void InitializeSignals()
    {
        PopupRequest += OnPopupRequest;

        ConnectionRequest += OnConnectionRequest;

        DisconnectionRequest += OnDisconnectionRequest;
        
        ConnectionToEmpty += OnConnectionToEmpty;

        DeleteNodesRequest += OnDeleteNodesRequest;
    }
    
    public async void OnPopupRequest(Vector2 position)
    {
        await this.ShowPopup(position);
    }

    public void OnConnectionRequest(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        this.ConnectNode(fromNode, (int)fromPort, toNode, (int)fromPort);
    }
    
    public void OnDisconnectionRequest(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        this.DisconnectNode(fromNode, (int)fromPort, toNode, (int)fromPort);
    }

    public async void OnConnectionToEmpty(StringName fromNode, long fromPort, Vector2 releasePosition)
    {
        GraphNode result = await ShowPopup(releasePosition);
        
        if (result != null)
        {
            this.OnConnectionRequest(fromNode, fromPort, result.Name, result.GetInputPortSlot(0));
        }
    }

    public void OnDeleteNodesRequest(Array nodeNames)
    {
        foreach (StringName name in nodeNames)
        {
            this.DeleteNode(name);
        }
    }
}