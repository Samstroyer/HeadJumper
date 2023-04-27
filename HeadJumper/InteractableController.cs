using System;

public class InteractableController
{
    Dictionary<Lever, Interactable> interactableDict;

    public InteractableController()
    {
        interactableDict = new()
        {
            {new(100, -10), new Door(100, -200)},
            {new(200, -10), new BoulderStack(200, - 200)}
        };
    }

    internal void DrawAndUpdateInteractables()
    {
        foreach (var entry in interactableDict)
        {
            entry.Key.DrawAndCheck();
            entry.Value.DrawAndUpdate(entry.Key.IsOn());
        }
    }
}
