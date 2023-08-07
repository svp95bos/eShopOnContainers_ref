namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Extensions;

public static class LinqRandomExtension
{
    public static T RandomElement<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.RandomElementUsing(new Random());
    }

    public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
    {
        int index = rand.Next(0, enumerable.Count());
        return enumerable.ElementAt(index);
    }
}
