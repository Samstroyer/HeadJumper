using System;

public class InteractableController
{
    Dictionary<Lever, Interactable> interactableDict;

    public InteractableController()
    {
        interactableDict = new()
        {
            {new(400, -10), new Door(400, -200)},
            // {new(40, -40), new BoulderStack(40, - 200)}
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
