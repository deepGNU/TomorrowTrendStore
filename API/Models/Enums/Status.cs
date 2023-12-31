namespace API.Models.Enums
{
    public enum Status
    {
        Cart,
        Pending,
        Processing,
        Shipped,
        Delivered,
        Canceled,
        Returned
    }

    //public static class StatusDescriptions
    //{
    //    public static readonly Dictionary<Status, string> Dict = new()
    //    {
    //        {Status.Cart, "InCart"},
    //        {Status.Pending, "Pending"},
    //        {Status.Processing, "Processing"},
    //        {Status.Shipped, "Shipped"},
    //        {Status.Delivered, "Delivered"},
    //        {Status.Canceled, "Canceled"},
    //        {Status.Returned, "Returned"}
    //    };
    //}
}
