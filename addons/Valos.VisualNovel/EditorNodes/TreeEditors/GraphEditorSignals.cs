using Godot;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public partial class GraphEditor
{

    private void InitializeSignals()
    {
        PopupRequest += OnPopupRequest;
        
        ConnectionToEmpty += OnConnectionToEmpty;

        DeleteNodesRequest += OnDeleteNodesRequest;

        ConnectionRequest += OnConnectionRequest;

        DisconnectionRequest += OnDisconnectionRequest;
    }

    public void OnDisconnectionRequest(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        this.DisconnectNode(fromNode, (int)fromPort, toNode, (int)fromPort);
    }

    public void OnConnectionRequest(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        this.ConnectNode(fromNode, (int)fromPort, toNode, (int)fromPort);
    }

    public async void OnConnectionToEmpty(StringName fromNode, long fromPort, Vector2 releasePosition)
    {
        GraphNode result = await ShowPopup(releasePosition);
        
        if (result != null)
        {
            OnConnectionRequest(fromNode, fromPort, result.Name, result.GetInputPortSlot(0));
        }
    }

    public async void OnPopupRequest(Vector2 position)
    {
        await ShowPopup(position);
    }
}