using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoTimer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// A single video and its properties
        /// </summary>
        private class Video
        {
            int index;
            string title;
            TimeSpan duration;
            string location;
            TimeSpan totalRelativeDuration;

            public Video(string _index, string _title, string _duration, string _location)
            {
                index = Int32.Parse(_index);
                title = _title;
                duration = RoundSeconds(TimeSpan.FromMilliseconds(Int32.Parse(_duration)));
                location = _location;
            }

            public string getIndex()
            {
                return $"{index}";
            }

            public string getTitle()
            {
                return title;
            }

            public TimeSpan getDuration()
            {
                return duration;
            }

            public string getDurationAsString()
            {
                return $"{duration}";
            }

            public string getTotalDuration()
            {
                return $"{totalRelativeDuration}";
            }

            public void setTotalDuration(TimeSpan input)
            {
                totalRelativeDuration = input;
            }

            /// <summary>
            /// Helper function to round times to nearest second
            /// </summary>
            /// <param name="span">Input</param>
            /// <returns>Output</returns>
            private TimeSpan RoundSeconds(TimeSpan span)
            {
                return TimeSpan.FromSeconds(Math.Round(span.TotalSeconds));
            }
        }

        private enum PlaylistNumber
        {
            PLAYLIST_ONE = 1,
            PLAYLIST_TWO = 2
        }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Formats the data grid after it is made
        /// </summary>
        /// <param name="dataGrid"></param>
        private void formatDataGrid(DataGridView dataGrid)
        {
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.AllowUserToResizeColumns = true;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 3)
                    {
                        if (TimeSpan.Parse(cell.Value.ToString()) < TimeSpan.FromHours(1))
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.LightGreen;
                            style.ForeColor = Color.Black;
                            cell.Style = style;
                        }

                        else if (TimeSpan.Parse(cell.Value.ToString()) < TimeSpan.FromHours(2))
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.LightYellow;
                            style.ForeColor = Color.Black;
                            cell.Style = style;
                        }

                        else if (TimeSpan.Parse(cell.Value.ToString()) < TimeSpan.FromHours(3))
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.LightSalmon;
                            style.ForeColor = Color.Black;
                            cell.Style = style;
                        }

                        else if (TimeSpan.Parse(cell.Value.ToString()) > TimeSpan.FromHours(6))
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.LightBlue;
                            style.ForeColor = Color.Black;
                            cell.Style = style;
                        }

                        else
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.Red;
                            style.ForeColor = Color.Black;
                            cell.Style = style;
                        }
                    }
                }
            }

            dataGrid.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="videosOut"></param>
        private void loadPlaylistDataFromFile(PlaylistNumber playlistNumber, out List<Video> videosOut)
        {
            // Const flags
            const string LOCATION_TAG = "<location>";
            const string DURATION_TAG = "<duration>";
            const string INDEX_TAG = "<vlc:id>";
            const string TRACK_START_TAG = "<track>";
            const string TRACK_END_TAG = "</track>";

            // Variables
            List<Video> videos = new List<Video>();
            string index, title, duration, location;
            index = title = duration = location = "";

            try
            {
                // Make sure file is selected
                if (playlistNumber == PlaylistNumber.PLAYLIST_ONE && textBoxPlaylist1File.Text == string.Empty)
                {
                    btnSelectPlaylist1_Click(null, null);
                }
                else if (textBoxPlaylist2File.Text == string.Empty)
                {
                    btnSelectPlaylist2_Click(null, null);
                }

                // Load the file
                string[] data;
                if (playlistNumber == PlaylistNumber.PLAYLIST_ONE)
                {
                    data = File.ReadAllLines(textBoxPlaylist1File.Text);
                }
                else
                {
                    data = File.ReadAllLines(textBoxPlaylist2File.Text);
                }
                
                //MessageBox.Show($"Loaded file. First line is {data[0]}");

                // Parse each video in the file
                foreach (var line in data)
                {
                    if (line.Contains(TRACK_START_TAG))
                    {
                        index = "INVALID";
                        title = "INVALID";
                        duration = "INVALID";
                        location = "INVALID";
                    }
                    else if (line.Contains(LOCATION_TAG))
                    {
                        string temp = line;
                        temp = temp.Replace("<location>", "");
                        temp = temp.Replace("</location>", "");
                        temp = temp.Replace(@"file:///", "");
                        temp = temp.Trim();
                        temp = Path.GetFullPath(temp);
                        location = temp;

                        temp = Path.GetFileNameWithoutExtension(temp);
                        temp = temp.Replace("%20", " ");
                        title = temp;
                    }
                    else if (line.Contains(DURATION_TAG))
                    {
                        string temp = line;
                        temp = temp.Replace("<duration>", "");
                        temp = temp.Replace("</duration>", "");
                        temp = temp.Trim();
                        duration = temp;
                    }
                    else if (line.Contains(INDEX_TAG))
                    {
                        string temp = line;
                        temp = temp.Replace("<vlc:id>", "");
                        temp = temp.Replace("</vlc:id>", "");
                        temp = temp.Trim();
                        index = temp;
                    }
                    else if (line.Contains(TRACK_END_TAG))
                    {
                        videos.Add(new Video(index, title, duration, location));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading playlist ~ {ex}");
            }
            finally
            {
                videosOut = videos;
            }
        }

        /// <summary>
        /// Calculates all video relative total durations
        /// </summary>
        /// <param name="videos">List of videos to parse</param>
        private void calculateVideoDurations(ref List<Video> videos)
        {
            TimeSpan totalDuration = TimeSpan.FromSeconds(0);
            int index = 0;

            foreach (var video in videos)
            {
                videos[index].setTotalDuration(totalDuration);
                totalDuration += videos[index].getDuration();
                index++;
            }
        }

        /// <summary>
        /// Parse the first playlist and display its information in the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParseList1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Index");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("Length");
            dataTable.Columns.Add("Total Length");

            List<Video> videos = new List<Video>();

            // Load the playlist and do the parsing
            loadPlaylistDataFromFile(PlaylistNumber.PLAYLIST_ONE, out videos);
            calculateVideoDurations(ref videos);

            foreach (var video in videos)
            {
                dataTable.Rows.Add(video.getIndex(), video.getTitle(), video.getDurationAsString(), video.getTotalDuration());
            }

            dataGridPlaylist1.DataSource = dataTable;

            formatDataGrid(dataGridPlaylist1);
        }

        /// <summary>
        /// Parse the second playlist and display its information in the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParseList2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Index");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("Length");
            dataTable.Columns.Add("Total Length");

            List<Video> videos = new List<Video>();

            // Load the playlist and do the parsing
            loadPlaylistDataFromFile(PlaylistNumber.PLAYLIST_TWO, out videos);
            calculateVideoDurations(ref videos);

            foreach (var video in videos)
            {
                dataTable.Rows.Add(video.getIndex(), video.getTitle(), video.getDurationAsString(), video.getTotalDuration());
            }

            dataGridPlaylist2.DataSource = dataTable;

            formatDataGrid(dataGridPlaylist2);
        }

        /// <summary>
        /// Selects the playlist to use for list #1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectPlaylist1_Click(object sender, EventArgs e)
        {
            if(openPlaylistDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBoxPlaylist1File.Text = openPlaylistDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex}");
                }
            }
        }

        private void btnSelectPlaylist2_Click(object sender, EventArgs e)
        {
            if (openPlaylistDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBoxPlaylist2File.Text = openPlaylistDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex}");
                }
            }
        }
    }
}
