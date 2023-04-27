using System;

public class InteractableController
{
    Dictionary<Lever, Interactable> interactableDict;

    public InteractableController()
    {
        interactableDict = new()
        {
            {new(100, -10), new Door(100, -50)},
            {new(200, -10), new BoulderStack(200, - 50)}
        };
    }

    internal void DrawAndUpdateInteractables()
    {
        foreach (var entry in interactableDict)
        {
            entry.Key.Draw();
            entry.Value.Draw();
        }
    }
}
