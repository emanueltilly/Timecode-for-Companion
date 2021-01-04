using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace MTC_Timecode_for_Companion
{
    public class ProjectData
    {
        public List<TimecodeEvent> TimecodeEventList = new List<TimecodeEvent>();

        public int fpsDropdownIndex = -1;



        public void SaveToFile(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(ProjectData));
                XML.Serialize(stream, this);
            }
        }

        public static ProjectData LoadFromFile(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer XML = new XmlSerializer(typeof(ProjectData));
                return (ProjectData)XML.Deserialize(stream);
            }
        }

       


    }
}
