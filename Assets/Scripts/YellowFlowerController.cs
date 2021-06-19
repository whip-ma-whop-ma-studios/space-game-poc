public class YellowFlowerController : Consumable, IInteractableObj
{
    public void Interact()
    {
        Consume(-20);
    }
}
