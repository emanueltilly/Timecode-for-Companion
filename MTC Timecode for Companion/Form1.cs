using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melanchall.DryWetMidi.Devices;


namespace MTC_Timecode_for_Companion
{
    public partial class Form1 : Form
    {
        MidiTimecode mtc;

        ProjectData data = new ProjectData();
        readonly TimecodeSmoother tcSmooth = new TimecodeSmoother();
        readonly TimecodeEvent nextEvent = new TimecodeEvent();
        readonly Companion companion = new Companion();

        private bool toggleTC = true;

        private int[] liveTC = new int[4] { 0, 0, 0, 0 };
        private bool liveTCrolling = false;

        private Int32 currentClock = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //GUI
            splitContainer1.SplitterDistance = 45;
            splitContainer1.FixedPanel = FixedPanel.Panel1;


            nextEvent.Hour = 99;
            nextEvent.Minute = 99;
            nextEvent.Second = 99;
            nextEvent.Frame = 99;
            nextEvent.Enabled = false;

            mtc = new MidiTimecode();
            var devices = MidiTimecode.GetInputDevices();
            foreach (InputDevice device in devices)
                inputdevice.Items.Add(device.Name);



            //Create dummy objects
            /*int loop = 0;
            while (loop < 20)
            {
                data.TimecodeEventList.Add(new TimecodeEvent());
                
                loop++;
            }*/

            LoadGUIfromData();

        }

        private void LoadGUIfromData()
        {
            ReloadDataGridView();
            fpsDropdown.SelectedIndex = data.fpsDropdownIndex;

            companionIPbox.Text = data.companionIP;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].Width = 50; dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Width = 100; dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Width = 50;
            dataGridView1.Columns[11].Width = 100; dataGridView1.Columns[11].Visible = false;

        }

        private void ReloadDataGridView()
        {
            //Link list to data grid view
            BindingSource source = new BindingSource
            {
                DataSource = data.TimecodeEventList
            };
            dataGridView1.DataSource = source;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void TcTimer_Tick(object sender, EventArgs e)
        {
            //Update the local time variable
            liveTCrolling = (mtc.timeSnap.GetLastUpdate().TotalSeconds < 1.5d);
            if (liveTCrolling == true) { liveTC = tcSmooth.UpdateLiveTC(mtc.timeSnap.GetNowTimecode(true)); }
            currentClock = TimestampTools.GetUnixTimestamp();
            int liveRealFrame = TimestampTools.ConvertTimestampToFrames(liveTC);
            int evntCounter = 0;
            //See if any lines can be executed
            foreach (TimecodeEvent evnt in data.TimecodeEventList)
            {
                //Check that event has not been executed in the last 2 sec
                if ((currentClock - evnt.LastExecution) > 2 )
                {
                    //Check if event is executed
                    if (evnt.Executed != true && evnt.Enabled == true && data.TimecodeEventList.Count > 0)
                    {
                        //If event is on this frame or has been missed in the last 10 frames
                        if (evnt.RealFrame == liveRealFrame || (evnt.RealFrame < liveRealFrame && evnt.RealFrame > (liveRealFrame - 10)))
                        {
                            //EXECUTE COMMAND
                            Console.WriteLine("");
                            Console.WriteLine("EXEC EVENT " + evnt.EventName);

                            companion.PushButton(evnt.Page, evnt.Bank);

                            if (evnt.OneShot == true) { evnt.Executed = true; } else
                            {
                                evnt.LastExecution = TimestampTools.GetUnixTimestamp();
                            }
                            

                            //Select event in datagridview and autoscroll
                            dataGridView1.ClearSelection();
                            dataGridView1.Rows[evntCounter].Selected = true;
                            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;
                        }
                    }
                }
                
                evntCounter++;
            }
            


            //GUI
            timecode_lbl.Text = TimestampTools.TimecodeToString(liveTC);
            //timecode_lbl.ForeColor = liveTCrolling ? Color.Lime : Color.DarkRed;
            if (liveTCrolling == false) { warningFlashTimer.Enabled = true; } else { warningFlashTimer.Enabled = false; timecode_lbl.ForeColor = Color.Black; }
            
            
            
        }

        private void ToggleTimecodeButton_Click(object sender, EventArgs e)
        {
            toggleTC = (toggleTC != true);
            mtc.timeSnap.ToggleCounting(toggleTC);
        }

        private void SaveProjectButton_Click(object sender, EventArgs e)
        {
            
        }

        private void OpenProjectButton_Click(object sender, EventArgs e)
        {
         
        }

        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog
            {
                RestoreDirectory = true,
                Title = "Save Project",
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };
            //SaveFileDialog1.ShowDialog();

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //SAVE TO FILE
                data.SaveToFile(SaveFileDialog1.FileName);
            }
        }

        private void OpenProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Title = "Open Project",
                Filter = "Xml Files (*.xml)|*.xml" + "|" +
                            "All Files (*.*)|*.*"
            };
            if (openDialog.ShowDialog() == DialogResult.OK)
            {

                data = ProjectData.LoadFromFile(openDialog.FileName);
                LoadGUIfromData();

            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void Inputdevice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ToolStripButton1_Click_1(object sender, EventArgs e)
        {
            toggleTC = (toggleTC != true);
            mtc.timeSnap.ToggleCounting(toggleTC);
        }

        private void FpsDropdown_TextChanged(object sender, EventArgs e)
        {
            data.fpsDropdownIndex = fpsDropdown.SelectedIndex;
            TimestampTools.SetFPS(int.Parse(fpsDropdown.Text));
            
        }

        private void ApplyTCbutton_Click(object sender, EventArgs e)
        {
            if (inputdevice.SelectedIndex >= 0 && fpsDropdown.SelectedIndex >= 0 && companionIPbox.Text != null)
            {
                RecalculateRealFrameForList();
                ResetExecutedForList();

                data.companionIP = companionIPbox.Text;
                companion.Ip = data.companionIP;

                mtc.inputDevice = MidiTimecode.GetInputDevices()[inputdevice.SelectedIndex];
                mtc.inputFPS = int.Parse(fpsDropdown.Text);
                mtc.inputOffset = 0;
                mtc.Initialize();
                inputdevice.Enabled = false;
                fpsDropdown.Enabled = false;
                applyTCbutton.Enabled = false;
                companionIPbox.Enabled = false;
                toggleTimecodeButton.Enabled = true;
                //dataGridView1.ReadOnly = true;
                

                tcSmooth.Initialize(int.Parse(fpsDropdown.Text));

                tcTimer.Interval = tcSmooth.FpsToMs(int.Parse(fpsDropdown.Text));
                tcTimer.Enabled = true;
            }
        }

        private void RecalculateRealFrameForList()
        {
            foreach (TimecodeEvent e1 in data.TimecodeEventList)
            {
                e1.UpdateRealFrame();
                
                
            }
        }
        private void ResetExecutedForList()
        {
            foreach (TimecodeEvent e2 in data.TimecodeEventList)
            {
                e2.ResetExecuted();
               
            }
        }

        private void WarningFlashTimer_Tick(object sender, EventArgs e)
        {
            timecode_lbl.ForeColor = ((timecode_lbl.ForeColor == Color.Red) ? Color.Black : Color.Red);
        }

        private void deleteSelectedItemInListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string box_msg = ("Do you want to DELETE this row from the cue list?");
                string box_title = "Are you sure?";
                DialogResult result = MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                        data.TimecodeEventList.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                        ReloadDataGridView();


        }
            }
            catch
            {
                MessageBox.Show("No row was selected, or there was a problem deleting the row.", "No row selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
