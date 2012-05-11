using System;
using System.Security.Principal;
using BlueToque.SharpGpx;
using BlueToque.SharpGpx.GPX1_1;

namespace Examples
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // read a file
                GpxClass gpx = GpxClass.FromFile("Files\\All Buntzen Trails.gpx");

                gpx.rte.ForEach(x=>Console.WriteLine("Route: {0}\r\n",x.name));
                gpx.wpt.ForEach(x=>Console.WriteLine("Waypoint: {0}\r\n",x.name));
                gpx.trk.ForEach(x=>Console.WriteLine("Track: {0}\r\n",x.name));

                // create a new file
                GpxClass newGpx = new GpxClass()
                {
                    creator=WindowsIdentity.GetCurrent().Name,
                    version= "Test",
                    wpt=new wptTypeCollection(),
                };

                wptType waypoint = new wptType()
                {
                    name = "Test Waypoint",
                    cmt = "Comment",
                    desc = "Description",
                    lat = (Decimal)49.3402360,
                    lon = (Decimal)(-122.8770030),
                    time = DateTime.Now,
                    timeSpecified = true,
                    sym = "Waypoint",
                };

                newGpx.wpt.Add(waypoint);

                newGpx.ToFile("Test.gpx");

                CreateTrack();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file:\r\n{0}", ex);
            }
        }

        private static void CreateTrack()
        {
            
            GpxClass track=new GpxClass()
            {
                metadata=new metadataType()
                {
                    author=new personType(){name=WindowsIdentity.GetCurrent().Name},
                    link=new linkTypeCollection().AddLink(new linkType(){ href="www.BlueToque.ca",  text="Blue Toque Software" })
                },
                trk=new trkTypeCollection()
            };

            track.trk.Add(new trkType()
            {
                name = "11-AUG-11 18:18:27",
                trkseg = new trksegTypeCollection().Addtrkseg(
                    new trksegType()
                    {
                        trkpt = new wptTypeCollection()
                            .Addwpt(new wptType()
                            {
                                lat = (Decimal)49.706482,
                                lon = (Decimal)(-123.111961),
                                ele = (Decimal)38.11,
                                eleSpecified = true,
                            })
                            .Addwpt(new wptType()
                            {
                                lat = (Decimal)49.706417,
                                lon = (Decimal)(-123.112190),
                                ele = (Decimal)38.11,
                                eleSpecified = true,
                            })
                            .Addwpt(new wptType()
                            {
                                lat = (Decimal)49.706348,
                                lon = (Decimal)(-123.112495),
                                ele = (Decimal)76.08,
                                eleSpecified = true,
                            })
                            .Addwpt(new wptType()
                            {
                                lat = (Decimal)49.706242,
                                lon = (Decimal)(-123.111961),
                                ele = (Decimal)74.16,
                                eleSpecified = true,
                            })
                            .Addwpt(new wptType()
                            {
                                lat = (Decimal)49.705872,
                                lon = (Decimal)(-123.111961),
                                ele = (Decimal)38.11,
                                eleSpecified = true,
                            })
                    })
            });

            track.ToFile("Test2.gpx");
        }
    }
}
