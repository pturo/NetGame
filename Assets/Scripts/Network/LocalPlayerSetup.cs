using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LocalPlayerSetup : NetworkBehaviour
{
    [SyncVar]
    public bool isHost;

    public Behaviour[] componentsToDisable;

    private void Start()
    {
        if (NetworkServer.active && isLocalPlayer)
            isHost = true;

        if (!isLocalPlayer)
            foreach (var item in componentsToDisable)
                item.enabled = false;
    }
}
