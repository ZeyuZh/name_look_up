/* UserInterface.cs
 * Author: Rod Howell 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A GUI for a program that retrieves information about last names in
    /// a sample of US data.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The information on all the names.
        /// </summary>
        private Dictionary<NameInformation> _names;

        /// <summary>
        /// Constructs a new GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /*/// <summary>
        /// Handles a Click event on the Open Data File button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _names = ReadInputFile(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }*/

        /// <summary>
        /// Handles a Click event on the Get Statistics button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            NameInformation info;
            if (_names.TryGetValue(name, out info))
            {
                uxFrequency.Text = info.Frequency.ToString();
                uxRank.Text = info.Rank.ToString();
                return;
            }
            else
            {
                MessageBox.Show("Name not found.");
                uxFrequency.Text = "";
                uxRank.Text = "";
            }
        }

        /// <summary>
        /// Reads the information from the given file into a dictionary.
        /// </summary>
        /// <param name="fn">The name of the file to be read.</param>
        /// <returns>A dictionary containing the information from the file.</returns>
        private Dictionary<NameInformation> ReadInputFile(string fn)
        {
            Dictionary<NameInformation> names;
            KeyValuePair<string, NameInformation> keyPair;
            List<KeyValuePair<string, NameInformation>> list = new List<KeyValuePair<string, NameInformation>>();
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    keyPair = new KeyValuePair<string, NameInformation>(name, new NameInformation(name, freq, rank));
                    list.Add(keyPair);
                }
                names = new Dictionary<NameInformation>(list);
            }
            return names;
        }

        /* /// <summary>
         /// Handles a Click event on the Remove button.
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         private void uxRemove_Click(object sender, EventArgs e)
         {
             if (_names.Remove(uxName.Text.Trim().ToUpper()))
             {
                 MessageBox.Show("Name removed.");
             }
             else
             {
                 MessageBox.Show("Name not found.");
             }
             uxName.Text = "";
             uxFrequency.Text = "";
             uxRank.Text = "";
         }

         /// <summary>
         /// Writes the data stored in the given dictionary in arbitrary order.
         /// </summary>
         /// <param name="output">The output stream.</param>
         /// <param name="d">The dictionary containing the data.</param>
         private void WriteData(StreamWriter output, Dictionary<string, NameInformation> d)
         {
             foreach (NameInformation info in d.Values)
             {
                 output.WriteLine(info.Name);
                 output.WriteLine(info.Frequency);
                 output.WriteLine(info.Rank);
             }
         }

         /// <summary>
         /// Handles a Click event on the Save button.
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         private void uxSave_Click(object sender, EventArgs e)
         {
             if (uxSaveDialog.ShowDialog() == DialogResult.OK)
             {
                 try
                 {
                     using (StreamWriter output = new StreamWriter(uxSaveDialog.FileName))
                     {
                         WriteData(output, _names);
                     }
                     MessageBox.Show("File written.");
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             }
         }*/

        /// <summary>
        /// The event handler for the "Open raw data file" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenRawData_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _names = ReadInputFile(uxOpenDialog.FileName);
                    MessageBox.Show("Number of elements: " + _names.Count + "\nSecondary table length: " + _names.SecondaryTableLength);
                    uxSaveHashTable.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// The event handler for the "Save hash table" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSaveHashTable_Click(object sender, EventArgs e)
        {
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Stream stream = File.Create(uxSaveDialog.FileName))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(stream, uxSaveDialog.FileName);
                    }
                    MessageBox.Show("File written.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// An event handler for the "Open hash table" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenHashTable_Click(object sender, EventArgs e)
        {
            if(uxOpenTableDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = File.OpenRead(uxOpenTableDialog.FileName))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Deserialize(stream);
                    }
                    MessageBox.Show("Hash table successfully read.");
                    uxSaveHashTable.Enabled = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
