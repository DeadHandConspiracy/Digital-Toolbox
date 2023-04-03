namespace Tool_checkout
{
    public partial class Form1 : Form
    {
        int toolline = 0;
        List<string> toolMake = new();
        List<string> toolModel = new();
        List<string> toolSerial = new();

        public Form1()
        {
            InitializeComponent();

            int count = 0;
            bool checkboxstat = false;
            string Filename = @".\ToolList.csv";
            int lineIndex;
            int newLineItemFontSize;


            if (File.Exists(Filename))
            {
                // Load search log file into array for modification 
                string[] lines = File.ReadLines(Filename).ToArray();
                foreach (string line in lines)
                {
                    string[] columns = line.Split(',');

                    foreach (string column in columns)
                    {
                        if (count == 0)
                        {
                            count++;
                            if (column == "TRUE") { checkboxstat = true; }
                            else { checkboxstat = false; }

                            lineIndex = toolline++ + 1;
                            if (lineIndex >= 100)
                            {
                                newLineItemFontSize = 7;
                            }
                            else
                            {
                                newLineItemFontSize = 9;
                            }

                            Label newLineItem = new()
                            {
                                Text = $"{lineIndex}",
                                Name = $"newLineItem_{toolline}",
                                Font = new Font("Segoe UI", newLineItemFontSize),
                                Width = 20,
                                Height = 30,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            flowLayoutPanel1.Controls.Add(newLineItem);
                        }
                        else if (count == 1)
                        {
                            count++;
                            CheckBox newcheckBox = new()
                            {
                                Text = column,
                                Width = 316,
                                Checked = checkboxstat,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Name = $"newcheckBox_{toolline}"
                            };
                            newcheckBox.MouseLeave += new EventHandler(PicBox_Hide);
                            newcheckBox.MouseHover += new EventHandler(PicBox_Show);
                            newcheckBox.CheckStateChanged += new EventHandler(changeCBBColor);
                            flowLayoutPanel1.Controls.Add(newcheckBox);
                        }
                        else if (count == 2)
                        {
                            count++;
                            TextBox newnameText = new()
                            {
                                Text = column,
                                Name = $"newnameText_{toolline}"
                            };
                            newnameText.TextChanged += new EventHandler(changeBColor);
                            flowLayoutPanel1.Controls.Add(newnameText);

                        }
                        else if (count == 3)
                        {
                            count++;
                            TextBox newReturnText = new()
                            {
                                Text = column,
                                Name = $"newReturnText_{toolline}"
                            };
                            newReturnText.TextChanged += new EventHandler(changeBColor);
                            flowLayoutPanel1.Controls.Add(newReturnText);

                        }
                        else if (count == 4)
                        {
                            count++;
                            PictureBox newPic = new()
                            {
                                Name = $"newPic_{toolline}",
                                Height = 150,
                                Width = 555,
                                BorderStyle = BorderStyle.FixedSingle,
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Visible = false
                            };
                            if (column != String.Empty)
                            {
                                newPic.Image = Image.FromFile(column);
                                newPic.ImageLocation = column;
                            }
                            flowLayoutPanel1.Controls.Add(newPic);
                        }
                        else if (count == 5) 
                        { 
                            count++;
                            toolMake.Add(column);
                        }
                        else if (count == 6) 
                        { 
                            count++;
                            toolModel.Add(column);
                        }
                        else if (count == 7) 
                        { 
                            count = 0;
                            toolSerial.Add(column);
                        }

                    }
                                        
                }

            }
            else
            {
                File.WriteAllText(@".\ToolList.csv", "");

                System.IO.Directory.CreateDirectory("Images");

            }

            toolline = flowLayoutPanel1.Controls.OfType<CheckBox>().ToList().Count;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                toolline++;
                int lineIndex;
                int newLineItemFontSize;
                lineIndex = toolline;
                if (lineIndex >= 100)
                {
                    newLineItemFontSize = 7;
                }
                else
                {
                    newLineItemFontSize = 9;
                }

                Label newLineItem = new()
                {
                    Text = $"{toolline}",
                    Name = $"newLineItem_{toolline}",
                    Width = 20,
                    Height = 30,
                    Font = new Font("Segoe UI", newLineItemFontSize),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                flowLayoutPanel1.Controls.Add(newLineItem);

                CheckBox newcheckBox = new()
                {
                    Text = textBox1.Text,
                    Width = 316,
                    BackColor = Color.LightYellow,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Name = $"newcheckBox_{toolline}"
                };
                newcheckBox.MouseLeave += new EventHandler(PicBox_Hide);
                newcheckBox.MouseHover += new EventHandler(PicBox_Show);
                newcheckBox.CheckStateChanged += new EventHandler(changeCBBColor);
                flowLayoutPanel1.Controls.Add(newcheckBox);

                TextBox newnameText = new()
                {
                    Name = $"newnameText_{toolline}"
                };
                newnameText.TextChanged += new EventHandler(changeBColor);
                flowLayoutPanel1.Controls.Add(newnameText);

                TextBox newReturnText = new()
                {
                    Name = $"newReturnText_{toolline}"
                };
                newReturnText.TextChanged += new EventHandler(changeBColor);
                flowLayoutPanel1.Controls.Add(newReturnText);

                PictureBox newPic = new()
                {
                    Name = $"newPic_{toolline}",
                    Height = 150,
                    Width = 555,
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Visible = false
                };
                
                if (textBox3.Text != String.Empty)
                {
                    newPic.Image = Image.FromFile(textBox3.Text);
                    newPic.ImageLocation = textBox3.Text;
                }
                flowLayoutPanel1.Controls.Add(newPic);
                pictureBox1.Image = null;

                if(textBox4.Text == null)
                {
                    toolMake.Add("N/a");
                }
                else
                {
                    toolMake.Add(textBox4.Text);
                }

                if (textBox5.Text == null)
                {
                    toolModel.Add("N/a");
                }
                else
                {
                    toolModel.Add(textBox5.Text);
                }

                if (textBox6.Text == null)
                {
                    toolSerial.Add("N/a");
                }
                else
                {
                    toolSerial.Add(textBox6.Text);
                }

                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;

                textBox3.Text = null;
                textBox1.Text = null;

                textBox1.BackColor = SystemColors.Window;

            }
            else
            {
                textBox1.BackColor = Color.RosyBrown;
                MessageBox.Show($"Need to add a name.");
                textBox1.Select();
                textBox1.Focus();

            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Control c; int nextNum = 0;
            
            if (textBox2.Text != $"")
            {
                nextNum = Convert.ToInt16(textBox2.Text);
            }
            
            int lastTool = toolline;
            if (nextNum <= toolline && nextNum > 0)
            {
                c = flowLayoutPanel1.Controls[$"newLineItem_{nextNum}"]; c.Dispose();
                c = flowLayoutPanel1.Controls[$"newcheckBox_{nextNum}"]; c.Dispose();
                c = flowLayoutPanel1.Controls[$"newnameText_{nextNum}"]; c.Dispose();
                c = flowLayoutPanel1.Controls[$"newReturnText_{nextNum}"]; c.Dispose();
                c = flowLayoutPanel1.Controls[$"newPic_{nextNum}"]; c.Dispose();

                int b = nextNum; nextNum++;
                for (int i = nextNum; i < lastTool + 1; i++)
                {
                    flowLayoutPanel1.Controls[$"newLineItem_{i}"].Text = $"{b}";
                    flowLayoutPanel1.Controls[$"newLineItem_{i}"].Name = $"newLineItem_{b}";
                    flowLayoutPanel1.Controls[$"newcheckBox_{i}"].Name = $"newcheckBox_{b}";
                    flowLayoutPanel1.Controls[$"newnameText_{i}"].Name = $"newnameText_{b}";
                    flowLayoutPanel1.Controls[$"newReturnText_{i}"].Name = $"newReturnText_{b}";
                    flowLayoutPanel1.Controls[$"newPic_{i}"].Name = $"newPic_{b}";
                    b++;
                }
                toolline--;
            }
            else
            {
                MessageBox.Show($"{nextNum} is not valid item.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string createText, toolname, checkedout, person, returnDate, imgfile;

            File.WriteAllText(@".\ToolList.csv", "");

            for (int i = 1; i < toolline + 1; i++)
            {
                toolname = $"{flowLayoutPanel1.Controls[$"newcheckBox_{i}"].Text}";

                flowLayoutPanel1.Controls[$"newcheckBox_{i}"].BackColor = SystemColors.Control;

                checkedout = $"{flowLayoutPanel1.Controls[$"newcheckBox_{i}"]}";
                checkedout = checkedout.Substring(checkedout.Length - 1,1);

                person = $"{flowLayoutPanel1.Controls[$"newnameText_{i}"].Text}";
                returnDate = $"{flowLayoutPanel1.Controls[$"newReturnText_{i}"].Text}";
                
                if (checkedout == "0")
                {
                    checkedout = "FALSE";
                }
                else if (checkedout == "1")
                {
                    checkedout = "TRUE";
                }

                PictureBox tempPicBox = (PictureBox)flowLayoutPanel1.Controls[$"newPic_{i}"];
                imgfile = $"{tempPicBox.ImageLocation}";
                
                createText = $"{checkedout},{toolname},{person},{returnDate},{imgfile},{toolMake[i-1]},{toolModel[i-1]},{toolSerial[i-1]}{Environment.NewLine}";
                File.AppendAllText(@".\ToolList.csv", createText);

            }

            MessageBox.Show($"You just updated the Checkout list.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not built yet.");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (Convert.ToInt32(e.KeyChar) == 13 && button4.Text !="")
            {
                button4.PerformClick();
                e.Handled = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13 && textBox1.Text != "")
            {
                button1.PerformClick();
                e.Handled = true;
                textBox1.Text = "";
            }
            else if (Convert.ToInt32(e.KeyChar) == 13 && textBox1.Text == "")
            {
                textBox1.BackColor = Color.RosyBrown;
                MessageBox.Show($"Need to add a name."); e.Handled = true;
                textBox1.Select();
                textBox1.Focus();
            }
        }

        private void PicBox_Hide(object sender, EventArgs e)
        {
            CheckBox passedobj = (CheckBox)sender;

            int theUnderscore = passedobj.Name.IndexOf('_');
            int thetotal = passedobj.Name.Length;
            int thetail = thetotal - theUnderscore;
            int PicLineNum = Int16.Parse(passedobj.Name.Substring(theUnderscore + 1, thetail - 1));

            if (toolline != PicLineNum)
            {
                flowLayoutPanel1.Controls[$"newPic_{PicLineNum}"].Hide();
            }
        }

        private void PicBox_Show(object sender, EventArgs e)
        {
            CheckBox passedobj = (CheckBox)sender;

            int theUnderscore = passedobj.Name.IndexOf('_');
            int thetotal = passedobj.Name.Length;
            int thetail = thetotal - theUnderscore;
            int PicLineNum = Int16.Parse(passedobj.Name.Substring(theUnderscore + 1, thetail - 1));
            PictureBox tempPicBox = (PictureBox)flowLayoutPanel1.Controls[$"newPic_{PicLineNum}"]; ;
            string imgfile = $"{tempPicBox.ImageLocation}";

            if (imgfile != String.Empty)
            {
                flowLayoutPanel1.Controls[$"newPic_{toolline}"].Hide();
                flowLayoutPanel1.Controls[$"newPic_{PicLineNum}"].Show();
            }
            
        }

        private void changeBColor(object sender, EventArgs e)
        {
            TextBox passedobj = (TextBox)sender;

            int theUnderscore = passedobj.Name.IndexOf('_');
            int thetotal = passedobj.Name.Length;
            int thetail = thetotal - theUnderscore;
            int textLineNum = Int16.Parse(passedobj.Name.Substring(theUnderscore + 1, thetail - 1));
            flowLayoutPanel1.Controls[$"newcheckBox_{textLineNum}"].BackColor = Color.LightYellow;
        }

        private void changeCBBColor(object sender, EventArgs e)
        {
            CheckBox passedobj = (CheckBox)sender;

            int theUnderscore = passedobj.Name.IndexOf('_');
            int thetotal = passedobj.Name.Length;
            int thetail = thetotal - theUnderscore;
            int textLineNum = Int16.Parse(passedobj.Name.Substring(theUnderscore + 1, thetail - 1));
            flowLayoutPanel1.Controls[$"newcheckBox_{textLineNum}"].BackColor = Color.LightYellow;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new();
            fdlg.Title = "Open Image Files";
            fdlg.InitialDirectory = @".\images\";
            fdlg.Filter = "All files (*.*)|*.*|All image files(*.jpg; *.png; *.bmp)|*.jpg; *.png; *.bmp";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = fdlg.FileName;
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.Image = Image.FromFile(textBox3.Text);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 frm = new();
            frm.Show();
        }

        private void flowLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls[$"newPic_{toolline}"].Hide();
        }
    }
}
//Point p = PointToClient(MousePosition);
//MessageBox.Show($"{GetCildAtPoint(p).Name}");