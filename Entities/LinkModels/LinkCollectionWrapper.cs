namespace Entities.LinkModels
{
    public class LinkCollectionWrapper<T> : LinkResourceBase
    {
        public List<T> Value { get; set; } = new();
        public LinkCollectionWrapper()
        {
            Value = new List<T>();
        }
        public LinkCollectionWrapper(List<T> value)
        {
            Value = value;
        }
    }
}
