using System.Collections.Generic;


namespace BlueToque.SharpGpx.GPX1_1 
{
    public partial class gpxType
    {
    }

    public partial class wptTypeCollection 
    {
        public wptTypeCollection() { }

        public wptTypeCollection(IEnumerable<wptType> collection)
            : base(collection)
        { }

        public wptTypeCollection Addwpt(wptType wptType)
        {
            Add(wptType);
            return this;
        }
    }

    public partial class rteTypeCollection 
    {
        public rteTypeCollection() { }

        public rteTypeCollection(IEnumerable<rteType> collection)
            : base(collection)
        { }
    }

    public partial class trkTypeCollection 
    {
        public trkTypeCollection() { }

        public trkTypeCollection(IEnumerable<trkType> collection)
            : base(collection)
        { }
    }

    public partial class linkTypeCollection 
    {
        public linkTypeCollection() { }

        public linkTypeCollection(IEnumerable<linkType> collection)
            : base(collection)
        { }

        public linkTypeCollection Addlink(linkType linkType)
        {
            Add(linkType);
            return this;
        }
    }

    public partial class trksegTypeCollection
    {
        public trksegTypeCollection() { }

        public trksegTypeCollection(IEnumerable<trksegType> collection)
            : base(collection)
        { }

        public trksegTypeCollection Addtrkseg(trksegType trksegType)
        {
            Add(trksegType);
            return this;
        }
    }

    public partial class ptTypeCollection 
    {
        public ptTypeCollection() { }

        public ptTypeCollection(IEnumerable<ptType> collection)
            : base(collection)
        { }
    }
}
