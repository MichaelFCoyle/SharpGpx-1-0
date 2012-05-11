
namespace BlueToque.SharpGpx
{
    public static class Extensions
    {
        public static GPX1_1.linkTypeCollection AddLink(this GPX1_1.linkTypeCollection linkCollection, GPX1_1.linkType link)
        {
            linkCollection.Add(link);
            return linkCollection;
        }

    }
}
