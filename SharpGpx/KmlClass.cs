using System.IO;
using System.Xml;
using BlueToque.GpxLib.Properties;
using BlueToque.Utility;

namespace BlueToque.GpxLib
{
    public class KmlClass
    {
        public KmlClass(GpxClass gpx)
        {
            m_gpx = gpx;
        }

        GpxClass m_gpx;

        /// <summary>
        /// Parse an XML string and return an object model that has the contents of the
        /// GPX file
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static GpxClass FromXml(string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            string xml = xmlString;

            //if (doc.DocumentElement != null && doc.DocumentElement.NamespaceURI == "http://www.topografix.com/GPX/1/0")
            xml = XsltHelper.Transform(xmlString, Resources.KML2GPX);

            GPX1_1.gpxType gpx = Serializer.Deserialize<GPX1_1.gpxType>(xml);
            return new GpxClass(gpx);

        }

        /// <summary>
        /// Load and parse the given GPS file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static GpxClass FromFile(string fileName)
        {
            if (fileName.ToLower().EndsWith("kmz"))
            {
                // unzip to temp file
            }
            using (StreamReader reader = new StreamReader(fileName))
                return FromXml(reader.ReadToEnd());
        }

        /// <summary>
        /// Save the GPX file to a string with the most recent version
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            return XsltHelper.Transform(Serializer.Serialize<GPX1_1.gpxType>(m_gpx.ToGpx1_1()), Resources.GPX2KML);
        }

        public void ToStream(Stream stream)
        {
            XsltHelper.Transform( m_gpx.ToXml(), Resources.GPX2KML, stream);
        }
        
    }
}
