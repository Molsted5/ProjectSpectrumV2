[System.Serializable]

public class Pickup
{
    public string name;
    public int count;

    public Pickup(string PickupName, int itemCount)
    {
        name = PickupName;
        count = itemCount;
    }
   
}
