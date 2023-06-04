using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;

namespace MTC_Timecode_for_Companion
{
    public class ProjectData
    {
        public List<TimecodeEvent> TimecodeEventList = new List<TimecodeEvent>();

        public int fpsDropdownIndex = -1;

        public string companionIP = "127.0.0.1";
        public int companionPort = 16759;



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

    public class RowColorAssignment
    {
        public RowColor selectedColor = new RowColor();
        private List<RowColor> availableColors = new List<RowColor>();

        public List<string> getAvailableColors()
        {
            availableColors.Clear();
            availableColors.Add(new RowColor() { name = "White", value = Color.FromArgb(255, 255, 255) });
            availableColors.Add(new RowColor() { name = "Gray", value = Color.FromArgb(220, 220, 220) });
            availableColors.Add(new RowColor() { name = "Red", value = Color.FromArgb(255, 205, 210) }); 
            availableColors.Add(new RowColor() { name = "Purple", value = Color.FromArgb(225, 190, 231) }); 
            availableColors.Add(new RowColor() { name = "Blue", value = Color.FromArgb(187, 222, 251) }); 
            availableColors.Add(new RowColor() { name = "Cyan", value = Color.FromArgb(178, 235, 242) }); 
            availableColors.Add(new RowColor() { name = "Green", value = Color.FromArgb(200, 230, 201) }); 
            availableColors.Add(new RowColor() { name = "Yellow", value = Color.FromArgb(255, 249, 196) }); 
            availableColors.Add(new RowColor() { name = "Orange", value = Color.FromArgb(255, 224, 178) });

            List<string> names = new List<string>();
            foreach (RowColor col in availableColors)
            {
                names.Add(col.name);
            }
            return names;
        }
        public void setColor(string colorName)
        {
            getAvailableColors();

            // Search for the color in the available colors list
            foreach (RowColor col in availableColors)
            {
                // If the color name matches, set the selectedColor to the current color and return
                if (col.name == colorName)
                {
                    selectedColor = col;
                    return;
                }
            }

        }
    }

    public class RowColor
    {
        public string name { get; set; }

        // Don't serialize this value, instead serialize the ARGB values
        [XmlIgnore]
        public Color value { get; set; }

        // Create new properties that will be XML serialized
        [XmlElement("ValueA")]
        public int ValueA
        {
            get { return value.A; }
            set { this.value = Color.FromArgb(value, this.value.R, this.value.G, this.value.B); }
        }

        [XmlElement("ValueR")]
        public int ValueR
        {
            get { return value.R; }
            set { this.value = Color.FromArgb(this.value.A, value, this.value.G, this.value.B); }
        }

        [XmlElement("ValueG")]
        public int ValueG
        {
            get { return value.G; }
            set { this.value = Color.FromArgb(this.value.A, this.value.R, value, this.value.B); }
        }

        [XmlElement("ValueB")]
        public int ValueB
        {
            get { return value.B; }
            set { this.value = Color.FromArgb(this.value.A, this.value.R, this.value.G, value); }
        }
    }

}
