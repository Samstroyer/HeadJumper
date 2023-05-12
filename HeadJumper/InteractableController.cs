using System;

public class InteractableController
{
    Dictionary<Lever, Interactable> interactableDict;

    public InteractableController()
    {
        interactableDict = new()
        {
            {new(1200, -440), new Door(2150, 5)},
            // {new(40, -40), new BoulderStack(40, - 200)}
        };

        foreach (var entry in interactableDict)
        {
            entry.Key.AddTarget(entry.Value);
        }
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
