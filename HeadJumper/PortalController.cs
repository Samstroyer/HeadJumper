using System;

public class PortalController
{
    List<Portal> portals;

    internal PortalController()
    {
        // Maybe load from json?
        portals = new()
        {
            new Portal(5950, 17),
            new Portal(5950, 1032)
        };

        portals[0].LinkTo(portals[1]);
        portals[1].LinkTo(portals[0]);
    }

    internal void DrawAndUpdatePortals()
    {
        foreach (Portal p in portals)
        {
            p.DrawPortal();
            p.TryTravel();
        }
    }
}
