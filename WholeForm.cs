// Decompiled with JetBrains decompiler
// Type: TeamNames.WholeForm
// Assembly: TeamNames, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8FFB8F9-B510-4DB5-9B72-32ABE923C476
// Assembly location: C:\Users\Gary\Documents\Casting\NGS Overlay Controller S7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace TeamNames
{
    public class WholeForm : Form
    {
        // This should be bigger than the largest image we want to display.  We make the assumption that everywhere the team logos appear in a scene,
        // they are square.  If they aren't, OBS does odd things when we put non-square images into those holes.
        private const int LogoImageSize = 400;

        private string prevBanL1 = "";
        private string prevBanR1 = "";
        private string prevBanL2 = "";
        private string prevBanR2 = "";
        private string prevMap1 = "";
        private string prevMap2 = "";
        private string prevMap3 = "";
        private string prevMap4 = "";
        private string prevMap5 = "";
        private IContainer components = (IContainer)null;
        private string leftName;
        private int leftScore;
        private string rightName;
        private int rightScore;
        private bool loading;
        private string runpath;
        private Label leftTeamLabel;
        private Label rightTeamLabel;
        private TextBox leftBox;
        private TextBox rightBox;
        private Label leftScoreLabel;
        private Label label2;
        private NumericUpDown leftScoreUD;
        private NumericUpDown rightScoreUD;
        private Button switchButton;
        private CheckBox scoreDisplayBox;
        private ComboBox banLeftBox1;
        private ComboBox banRightBox1;
        private ComboBox map1Box;
        private ComboBox map2Box;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox win1Box;
        private Label label7;
        private ComboBox win2Box;
        private Button clearButton;
        private Label label8;
        private ComboBox win3Box;
        private Label label9;
        private ComboBox map3Box;
        private Label label10;
        private ComboBox win5Box;
        private Label label11;
        private ComboBox win4Box;
        private Label label12;
        private Label label13;
        private ComboBox map5Box;
        private ComboBox map4Box;
        private Button logoLeftButton;
        private Button logoRightButton;
        private TextBox bestOfBox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox divBox1;
        private TextBox extraBox4;
        private TextBox extraBox3;
        private TextBox extraBox2;
        private TextBox extraBox1;
        private TextBox roundBox;
        private TextBox timerBox;
        private Button timerStopGo;
        private Timer countdownTimer;
        private OpenFileDialog openFileDialog;
        private TextBox timerEndBox;
        private Label label16;
        private Label label15;
        private Label label14;
        private Button clearText;
        private Label label17;
        private ComboBox pick5box;
        private Label label18;
        private ComboBox pick4box;
        private ComboBox pick1box;
        private Label label19;
        private ComboBox pick2box;
        private Label label20;
        private Label label21;
        private ComboBox pick3box;
        private ComboBox banLeftBox2;
        private ComboBox banRightBox2;

        public WholeForm()
        {
            this.InitializeComponent();
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            string leftName = this.leftName;
            this.leftName = this.rightName;
            this.rightName = leftName;
            int leftScore = this.leftScore;
            this.leftScore = this.rightScore;
            this.rightScore = leftScore;
            this.leftBox.Text = this.leftName;
            this.rightBox.Text = this.rightName;
            this.leftScoreUD.Value = (Decimal)this.leftScore;
            this.rightScoreUD.Value = (Decimal)this.rightScore;
            this.writeOutFile();
            this.swapFiles("Live/logoleft.png", "Live/logoright.png");
            string text1 = this.banLeftBox1.Text;
            string text2 = this.banLeftBox2.Text;
            if (this.banRightBox1.Text.Length > 0)
                this.banLeftBox1.SelectedIndex = this.banRightBox1.FindStringExact(this.banRightBox1.Text);
            if (this.banRightBox2.Text.Length > 0)
                this.banLeftBox2.SelectedIndex = this.banRightBox2.FindStringExact(this.banRightBox2.Text);
            if (text1.Length > 0)
                this.banRightBox1.SelectedIndex = this.banRightBox1.FindStringExact(text1);
            if (text2.Length > 0)
                this.banRightBox2.SelectedIndex = this.banRightBox2.FindStringExact(text2);
            string prevBanL1 = this.prevBanL1;
            string prevBanL2 = this.prevBanL2;
            string prevBanR1 = this.prevBanR1;
            string prevBanR2 = this.prevBanR2;
            this.prevBanL1 = "";
            this.prevBanL2 = "";
            this.prevBanR1 = "";
            this.prevBanR2 = "";
            this.banLeftBox_SelectedIndexChanged((object)null, (EventArgs)null);
            this.banRightBox_SelectedIndexChanged((object)null, (EventArgs)null);
            this.banLeftBox2_SelectedIndexChanged((object)null, (EventArgs)null);
            this.banRightBox2_SelectedIndexChanged((object)null, (EventArgs)null);
            this.prevBanL1 = prevBanR1;
            this.prevBanL2 = prevBanR2;
            this.prevBanR1 = prevBanL1;
            this.prevBanR2 = prevBanL2;
            Console.WriteLine("BANS---");
            Console.WriteLine("L1: " + this.banLeftBox1.Text);
            Console.WriteLine("L2: " + this.banLeftBox2.Text);
            Console.WriteLine("R1: " + this.banRightBox1.Text);
            Console.WriteLine("R2: " + this.banRightBox2.Text);
            if (this.win1Box.Text == "Left Team")
            {
                this.win1Box.SelectedIndex = this.win1Box.FindStringExact("Right Team");
                this.win1Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else if (this.win1Box.Text == "Right Team")
            {
                this.win1Box.SelectedIndex = this.win1Box.FindStringExact("Left Team");
                this.win1Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            if (this.win2Box.Text == "Left Team")
            {
                this.win2Box.SelectedIndex = this.win2Box.FindStringExact("Right Team");
                this.win2Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else if (this.win2Box.Text == "Right Team")
            {
                this.win2Box.SelectedIndex = this.win2Box.FindStringExact("Left Team");
                this.win2Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            if (this.win3Box.Text == "Left Team")
            {
                this.win3Box.SelectedIndex = this.win3Box.FindStringExact("Right Team");
                this.win3Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else if (this.win3Box.Text == "Right Team")
            {
                this.win3Box.SelectedIndex = this.win3Box.FindStringExact("Left Team");
                this.win3Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            if (this.win4Box.Text == "Left Team")
            {
                this.win4Box.SelectedIndex = this.win4Box.FindStringExact("Right Team");
                this.win4Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else if (this.win4Box.Text == "Right Team")
            {
                this.win4Box.SelectedIndex = this.win4Box.FindStringExact("Left Team");
                this.win4Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            if (this.win5Box.Text == "Left Team")
            {
                this.win5Box.SelectedIndex = this.win5Box.FindStringExact("Right Team");
                this.win5Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else if (this.win5Box.Text == "Right Team")
            {
                this.win5Box.SelectedIndex = this.win5Box.FindStringExact("Left Team");
                this.win5Box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            if (this.pick1box.Text == "Left Team")
            {
                this.pick1box.SelectedIndex = this.pick1box.FindStringExact("Right Team");
                this.pick1box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else if (this.pick1box.Text == "Right Team")
            {
                this.pick1box.SelectedIndex = this.pick1box.FindStringExact("Left Team");
                this.pick1box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            if (this.pick2box.Text == "Left Team")
            {
                this.pick2box.SelectedIndex = this.pick2box.FindStringExact("Right Team");
                this.pick2box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else if (this.pick2box.Text == "Right Team")
            {
                this.pick2box.SelectedIndex = this.pick2box.FindStringExact("Left Team");
                this.pick2box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            if (this.pick3box.Text == "Left Team")
            {
                this.pick3box.SelectedIndex = this.pick3box.FindStringExact("Right Team");
                this.pick3box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else if (this.pick3box.Text == "Right Team")
            {
                this.pick3box.SelectedIndex = this.pick3box.FindStringExact("Left Team");
                this.pick3box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            if (this.pick4box.Text == "Left Team")
            {
                this.pick4box.SelectedIndex = this.pick4box.FindStringExact("Right Team");
                this.pick4box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else if (this.pick4box.Text == "Right Team")
            {
                this.pick4box.SelectedIndex = this.pick4box.FindStringExact("Left Team");
                this.pick4box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            if (this.pick5box.Text == "Left Team")
            {
                this.pick5box.SelectedIndex = this.pick5box.FindStringExact("Right Team");
                this.pick5box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
            else
            {
                if (!(this.pick5box.Text == "Right Team"))
                    return;
                this.pick5box.SelectedIndex = this.pick5box.FindStringExact("Left Team");
                this.pick5box_SelectedIndexChanged((object)null, (EventArgs)null);
            }
        }

        private void swapFiles(string fn1, string fn2)
        {
            if (File.Exists(fn1))
            {
                CopyFile(fn1, fn1 + "T", true);
                File.Delete(fn1);
            }
            if (File.Exists(fn2))
            {
                CopyFile(fn2, fn2 + "T", true);
                File.Delete(fn2);
            }
            if (File.Exists(fn1 + "T"))
                File.Move(fn1 + "T", fn2);
            if (!File.Exists(fn2 + "T"))
                return;
            File.Move(fn2 + "T", fn1);
        }

        private void rightBox_TextChanged(object sender, EventArgs e)
        {
            this.rightName = this.rightBox.Text;
            this.writeOutFile();
        }

        private void leftBox_TextChanged(object sender, EventArgs e)
        {
            this.leftName = this.leftBox.Text;
            this.writeOutFile();
        }

        private void leftScoreUD_ValueChanged(object sender, EventArgs e)
        {
            this.leftScore = (int)this.leftScoreUD.Value;
            this.writeOutFile();
        }

        private void rightScoreUD_ValueChanged(object sender, EventArgs e)
        {
            this.rightScore = (int)this.rightScoreUD.Value;
            this.writeOutFile();
        }

        private void bestOfBox_TextChanged(object sender, EventArgs e)
        {
            this.writeOutFile();
        }

        private void roundBox_TextChanged(object sender, EventArgs e)
        {
            this.writeOutFile();
        }

        private void divBox1_TextChanged(object sender, EventArgs e)
        {
            this.writeOutFile();
        }

        private void extraBox1_TextChanged(object sender, EventArgs e)
        {
            this.writeOutFile();
        }

        private void extraBox2_TextChanged(object sender, EventArgs e)
        {
            this.writeOutFile();
        }

        private void extraBox3_TextChanged(object sender, EventArgs e)
        {
            this.writeOutFile();
        }

        private void extraBox4_TextChanged(object sender, EventArgs e)
        {
            this.writeOutFile();
        }

        private void writeOutFile()
        {
            if (this.loading)
                return;
            this.writeBoxToLine(this.leftBox, "TeamLeft.txt");
            this.writeBoxToLine(this.rightBox, "TeamRight.txt");
            this.writeBoxToLine(this.bestOfBox, "BestOf.txt");
            this.writeBoxToLine(this.divBox1, "Division.txt");
            this.writeBoxToLine(this.roundBox, "Round.txt");
            this.writeBoxToLine(this.extraBox1, "Text1.txt");
            this.writeBoxToLine(this.extraBox2, "Text2.txt");
            this.writeBoxToLine(this.extraBox3, "Text3.txt");
            this.writeBoxToLine(this.extraBox4, "Text4.txt");
            this.writeBoxToLine(this.timerEndBox, "TimerEnd.txt");
            if (this.leftScoreUD.Enabled)
            {
                using (StreamWriter streamWriter = new StreamWriter("ScoreLeft.txt"))
                    streamWriter.WriteLine(this.leftScore);
            }
            if (this.rightScoreUD.Enabled)
            {
                using (StreamWriter streamWriter = new StreamWriter("ScoreRight.txt"))
                    streamWriter.WriteLine(this.rightScore);
            }
            if (this.countdownTimer.Enabled)
            {
                using (StreamWriter streamWriter = new StreamWriter("Timer.txt"))
                {
                    try
                    {
                        if (TimeSpan.Parse("00:" + this.timerBox.Text.Trim()).TotalSeconds > 0.0)
                            streamWriter.WriteLine(this.timerBox.Text);
                        else
                            streamWriter.WriteLine(this.timerEndBox.Text);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine((object)ex);
                    }
                }
            }
            if (this.timerEndBox.TextLength <= 0)
                return;
            using (StreamWriter streamWriter = new StreamWriter("TimerEnd.txt"))
            {
                if (this.timerEndBox.Text.Length > 0)
                    streamWriter.WriteLine(this.timerEndBox.Text);
                else
                    streamWriter.WriteLine("");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.loading = true;
            this.rightName = "";
            this.leftName = "";
            this.runpath = AppDomain.CurrentDomain.BaseDirectory;
            this.openFileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiffBMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
            this.leftBox.Text = this.readInFile("TeamLeft.txt");
            this.rightBox.Text = this.readInFile("TeamRight.txt");
            this.extraBox1.Text = this.readInFile("Text1.txt");
            this.extraBox2.Text = this.readInFile("Text2.txt");
            this.extraBox3.Text = this.readInFile("Text3.txt");
            this.extraBox4.Text = this.readInFile("Text4.txt");
            this.roundBox.Text = this.readInFile("Round.txt");
            this.bestOfBox.Text = this.readInFile("BestOf.txt");
            this.divBox1.Text = this.readInFile("Division.txt");
            this.timerEndBox.Text = this.readInFile("TimerEnd.txt");
            this.loading = false;
        }

        private string readInFile(string path)
        {
            if (!File.Exists(path))
                return "";
            using (StreamReader streamReader = File.OpenText(path))
                return streamReader.ReadLine();
        }

        private void scoreDisplayBox_CheckedChanged(object sender, EventArgs e)
        {
            this.rightScoreUD.Enabled = this.scoreDisplayBox.Checked;
            this.leftScoreUD.Enabled = this.scoreDisplayBox.Checked;
            this.writeOutFile();
        }

        private void banLeftBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.loading)
                return;
            if (this.prevBanL1.Length > 0)
            {
                CopyFile("Blank.png", this.runpath + "Live/" + this.prevBanL1 + " Mod.png", true);
                CopyFile(this.prevBanL1 + ".png", this.runpath + "Live/" + this.prevBanL1 + ".png", true);
            }
            CopyFile("BlueBan.png", this.runpath + "Live/" + this.banLeftBox1.Text + " Mod.png", true);
            CopyFile(this.banLeftBox1.Text + " BW.png", this.runpath + "Live/" + this.banLeftBox1.Text + ".png", true);
            this.prevBanL1 = this.banLeftBox1.Text;
        }

        private void banRightBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.loading)
                return;
            if (this.prevBanR1.Length > 0)
            {
                CopyFile("Blank.png", this.runpath + "Live/" + this.prevBanR1 + " Mod.png", true);
                CopyFile(this.prevBanR1 + ".png", this.runpath + "Live/" + this.prevBanR1 + ".png", true);
            }
            CopyFile("RedBan.png", this.runpath + "Live/" + this.banRightBox1.Text + " Mod.png", true);
            CopyFile(this.banRightBox1.Text + " BW.png", this.runpath + "Live/" + this.banRightBox1.Text + ".png", true);
            this.prevBanR1 = this.banRightBox1.Text;
        }

        private void banLeftBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.loading)
                return;
            if (this.prevBanL2.Length > 0)
            {
                CopyFile("Blank.png", this.runpath + "Live/" + this.prevBanL2 + " Mod.png", true);
                CopyFile(this.prevBanL2 + ".png", this.runpath + "Live/" + this.prevBanL2 + ".png", true);
            }
            CopyFile("BlueBan.png", this.runpath + "Live/" + this.banLeftBox2.Text + " Mod.png", true);
            CopyFile(this.banLeftBox2.Text + " BW.png", this.runpath + "Live/" + this.banLeftBox2.Text + ".png", true);
            this.prevBanL2 = this.banLeftBox2.Text;
        }

        private void banRightBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.loading)
                return;
            if (this.prevBanR2.Length > 0)
            {
                CopyFile("Blank.png", this.runpath + "Live/" + this.prevBanR2 + " Mod.png", true);
                CopyFile(this.prevBanR2 + ".png", this.runpath + "Live/" + this.prevBanR2 + ".png", true);
            }
            CopyFile("RedBan.png", this.runpath + "Live/" + this.banRightBox2.Text + " Mod.png", true);
            CopyFile(this.banRightBox2.Text + " BW.png", this.runpath + "Live/" + this.banRightBox2.Text + ".png", true);
            this.prevBanR2 = this.banRightBox2.Text;
        }

        private void handleMapWriteout(ComboBox mapbox, ComboBox pickbox)
        {
            Console.WriteLine("Writing out " + mapbox.Text + " and " + pickbox.Text);
            if (this.loading || (pickbox.Text.Length <= 0 || mapbox.Text.Length <= 0))
                return;
            if (pickbox.Text == "Left Team")
            {
                CopyFile("BluePick.png", this.runpath + "Live/" + mapbox.Text + " Mod.png", true);
                CopyFile(mapbox.Text + " BW.png", this.runpath + "Live/" + mapbox.Text + ".png", true);
            }
            else
            {
                CopyFile("RedPick.png", this.runpath + "Live/" + mapbox.Text + " Mod.png", true);
                CopyFile(mapbox.Text + " BW.png", this.runpath + "Live/" + mapbox.Text + ".png", true);
            }
        }

        private void map1Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pick1box.Text.Length > 0 && this.map1Box.Text.Length > 0 && this.prevMap1.Length > 0)
            {
                CopyFile("Blank.png", this.runpath + "Live/" + this.prevMap1 + " Mod.png", true);
                CopyFile(this.prevMap1 + ".png", this.runpath + "Live/" + this.prevMap1 + ".png", true);
            }
            this.handleMapWriteout(this.map1Box, this.pick1box);
            this.prevMap1 = this.map1Box.Text;
        }

        private void map2Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pick2box.Text.Length > 0 && this.map2Box.Text.Length > 0 && this.prevMap2.Length > 0)
            {
                CopyFile("Blank.png", this.runpath + "Live/" + this.prevMap2 + " Mod.png", true);
                CopyFile(this.prevMap2 + ".png", this.runpath + "Live/" + this.prevMap2 + ".png", true);
            }
            this.handleMapWriteout(this.map2Box, this.pick2box);
            this.prevMap2 = this.map2Box.Text;
        }

        private void map3Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pick3box.Text.Length > 0 && this.map3Box.Text.Length > 0 && this.prevMap3.Length > 0)
            {
                CopyFile("Blank.png", this.runpath + "Live/" + this.prevMap3 + " Mod.png", true);
                CopyFile(this.prevMap3 + ".png", this.runpath + "Live/" + this.prevMap3 + ".png", true);
            }
            this.handleMapWriteout(this.map3Box, this.pick3box);
            this.prevMap3 = this.map3Box.Text;
        }

        private void map4Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pick4box.Text.Length > 0 && this.map4Box.Text.Length > 0 && this.prevMap4.Length > 0)
            {
                CopyFile("Blank.png", this.runpath + "Live/" + this.prevMap4 + " Mod.png", true);
                CopyFile(this.prevMap4 + ".png", this.runpath + "Live/" + this.prevMap4 + ".png", true);
            }
            this.handleMapWriteout(this.map4Box, this.pick4box);
            this.prevMap4 = this.map4Box.Text;
        }

        private void map5Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pick5box.Text.Length > 0 && this.map5Box.Text.Length > 0 && this.prevMap5.Length > 0)
            {
                CopyFile("Blank.png", this.runpath + "Live/" + this.prevMap5 + " Mod.png", true);
                CopyFile(this.prevMap5 + ".png", this.runpath + "Live/" + this.prevMap5 + ".png", true);
            }
            this.handleMapWriteout(this.map5Box, this.pick5box);
            this.prevMap5 = this.map5Box.Text;
        }

        private void pick1box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleMapWriteout(this.map1Box, this.pick1box);
        }

        private void pick2box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleMapWriteout(this.map2Box, this.pick2box);
        }

        private void pick3box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleMapWriteout(this.map3Box, this.pick3box);
        }

        private void pick4box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleMapWriteout(this.map4Box, this.pick4box);
        }

        private void pick5box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleMapWriteout(this.map5Box, this.pick5box);
        }

        private void handleWinWriteout(ComboBox mapbox, ComboBox winbox)
        {
            if (winbox.Text == "Left Team")
                CopyFile("BlueWin.png", this.runpath + "Live/" + mapbox.Text + " Win.png", true);
            else
                CopyFile("RedWin.png", this.runpath + "Live/" + mapbox.Text + " Win.png", true);
        }

        private void win1Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleWinWriteout(this.map1Box, this.win1Box);
        }

        private void win2Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleWinWriteout(this.map2Box, this.win2Box);
        }

        private void win3Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleWinWriteout(this.map3Box, this.win3Box);
        }

        private void win4Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleWinWriteout(this.map4Box, this.win4Box);
        }

        private void win5Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.handleWinWriteout(this.map5Box, this.win5Box);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.loading = true;
            this.banLeftBox1.ResetText();
            this.banLeftBox1.SelectedIndex = -1;
            this.banRightBox1.ResetText();
            this.banRightBox1.SelectedIndex = -1;
            this.banLeftBox2.ResetText();
            this.banLeftBox2.SelectedIndex = -1;
            this.banRightBox2.ResetText();
            this.banRightBox2.SelectedIndex = -1;
            this.map1Box.ResetText();
            this.map1Box.SelectedIndex = -1;
            this.map2Box.ResetText();
            this.map2Box.SelectedIndex = -1;
            this.map3Box.ResetText();
            this.map3Box.SelectedIndex = -1;
            this.map4Box.ResetText();
            this.map4Box.SelectedIndex = -1;
            this.map5Box.ResetText();
            this.map5Box.SelectedIndex = -1;
            this.pick1box.ResetText();
            this.pick1box.SelectedIndex = -1;
            this.pick2box.ResetText();
            this.pick2box.SelectedIndex = -1;
            this.pick3box.ResetText();
            this.pick3box.SelectedIndex = -1;
            this.pick4box.ResetText();
            this.pick4box.SelectedIndex = -1;
            this.pick5box.ResetText();
            this.pick5box.SelectedIndex = -1;
            this.win1Box.ResetText();
            this.win1Box.SelectedIndex = -1;
            this.win2Box.ResetText();
            this.win2Box.SelectedIndex = -1;
            this.win3Box.ResetText();
            this.win3Box.SelectedIndex = -1;
            this.win4Box.ResetText();
            this.win4Box.SelectedIndex = -1;
            this.win5Box.ResetText();
            this.win5Box.SelectedIndex = -1;
            this.prevBanL1 = "";
            this.prevBanL2 = "";
            this.prevBanR1 = "";
            this.prevBanR2 = "";
            CopyFile("Blank.png", this.runpath + "Live/Alterac Pass Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Alterac Pass Win.png", true);
            CopyFile("Alterac Pass.png", this.runpath + "Live/Alterac Pass.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Battlefield of Eternity Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Battlefield of Eternity Win.png", true);
            CopyFile("Battlefield of Eternity.png", this.runpath + "Live/Battlefield of Eternity.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Braxis Holdout Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Braxis Holdout Win.png", true);
            CopyFile("Braxis Holdout.png", this.runpath + "Live/Braxis Holdout.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Cursed Hollow Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Cursed Hollow Win.png", true);
            CopyFile("Cursed Hollow.png", this.runpath + "Live/Cursed Hollow.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Dragon Shire Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Dragon Shire Win.png", true);
            CopyFile("Dragon Shire.png", this.runpath + "Live/Dragon Shire.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Infernal Shrines Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Infernal Shrines Win.png", true);
            CopyFile("Infernal Shrines.png", this.runpath + "Live/Infernal Shrines.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Sky Temple Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Sky Temple Win.png", true);
            CopyFile("Sky Temple.png", this.runpath + "Live/Sky Temple.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Tomb of the Spider Queen Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Tomb of the Spider Queen Win.png", true);
            CopyFile("Tomb of the Spider Queen.png", this.runpath + "Live/Tomb of the Spider Queen.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Towers of Doom Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Towers of Doom Win.png", true);
            CopyFile("Towers of Doom.png", this.runpath + "Live/Towers of Doom.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Volskaya Foundry Mod.png", true);
            CopyFile("Blank.png", this.runpath + "Live/Volskaya Foundry Win.png", true);
            CopyFile("Volskaya Foundry.png", this.runpath + "Live/Volskaya Foundry.png", true);
            this.loading = false;
        }

        private void timerStopGo_Click(object sender, EventArgs e)
        {
            if (this.timerStopGo.Text == "Go")
            {
                this.timerStopGo.Text = "Stop";
                this.timerBox.Enabled = false;
                this.groupBox3.Focus();
                this.countdownTimer.Enabled = true;
            }
            else
            {
                this.timerStopGo.Text = "Go";
                this.timerBox.Enabled = true;
                this.countdownTimer.Enabled = false;
            }
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                double totalSeconds = TimeSpan.Parse("00:" + this.timerBox.Text.Trim()).TotalSeconds;
                if (totalSeconds <= 0.0)
                {
                    this.timerStopGo.Text = "Go";
                    this.timerBox.Enabled = true;
                    this.countdownTimer.Enabled = false;
                }
                else
                {
                    this.timerBox.Text = TimeSpan.FromSeconds(totalSeconds - 1.0).ToString("mm\\:ss");
                    this.writeOutFile();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                this.timerStopGo.Text = "Go";
                this.timerBox.Enabled = true;
                this.countdownTimer.Enabled = false;
            }
        }

        private void logoLeftButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Bitmap bitmapFromDisk = new Bitmap(this.openFileDialog.FileName);
            var copiedBitmap = (Bitmap)bitmapFromDisk.Clone();
            bitmapFromDisk.Dispose();

            using (var resizedImage = GetResizedLogo(copiedBitmap))
            {
                resizedImage.Save(this.runpath + "Live/logoleft.png", ImageFormat.Png);
            }
        }

        private void logoRightButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Bitmap bitmapFromDisk = new Bitmap(this.openFileDialog.FileName);
            var copiedBitmap = (Bitmap)bitmapFromDisk.Clone();
            bitmapFromDisk.Dispose();

            using (var resizedImage = GetResizedLogo(copiedBitmap))
            {
                resizedImage.Save(this.runpath + "Live/logoright.png", ImageFormat.Png);
            }
        }

        private Bitmap GetResizedLogo(Image original)
        {
            Rectangle destRect;

            if (original.Width > original.Height) {
                var height = (int)(original.Height * (LogoImageSize / (double)original.Width));
                destRect = new Rectangle(0, (LogoImageSize - height) / 2, LogoImageSize, height);
            } else {
                var width = (int)(original.Width * (LogoImageSize /(double) original.Height));
                destRect = new Rectangle((LogoImageSize - width) / 2, 0, width, LogoImageSize);
            }
            Bitmap bitmap = new Bitmap(LogoImageSize, LogoImageSize);
            bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes imageAttr = new ImageAttributes())
                {
                    graphics.DrawImage(original, destRect, 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, imageAttr);
                }
            }

            return bitmap;
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void timerBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void timerEndBox_TextChanged(object sender, EventArgs e)
        {
            this.writeOutFile();
        }

        private void clearText_Click(object sender, EventArgs e)
        {
            this.leftBox.Clear();
            this.rightBox.Clear();
            this.divBox1.Clear();
            this.roundBox.Clear();
            this.bestOfBox.Clear();
            this.timerBox.Clear();
            this.timerEndBox.Clear();
            this.extraBox1.Clear();
            this.extraBox2.Clear();
            this.extraBox3.Clear();
            this.extraBox4.Clear();
            CopyFile("nologo.png", this.runpath + "Live/logoleft.png", true);
            CopyFile("nologo.png", this.runpath + "Live/logoright.png", true);
            this.writeOutFile();
        }

        private void writeBoxToLine(TextBox box, string filename)
        {
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                if (box.Text.Length > 0)
                    streamWriter.WriteLine(box.Text);
                else
                    streamWriter.WriteLine("");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            this.leftTeamLabel = new Label();
            this.rightTeamLabel = new Label();
            this.leftBox = new TextBox();
            this.rightBox = new TextBox();
            this.leftScoreLabel = new Label();
            this.label2 = new Label();
            this.leftScoreUD = new NumericUpDown();
            this.rightScoreUD = new NumericUpDown();
            this.switchButton = new Button();
            this.scoreDisplayBox = new CheckBox();
            this.banLeftBox1 = new ComboBox();
            this.banRightBox1 = new ComboBox();
            this.map1Box = new ComboBox();
            this.map2Box = new ComboBox();
            this.label1 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.win1Box = new ComboBox();
            this.label7 = new Label();
            this.win2Box = new ComboBox();
            this.clearButton = new Button();
            this.label8 = new Label();
            this.win3Box = new ComboBox();
            this.label9 = new Label();
            this.map3Box = new ComboBox();
            this.label10 = new Label();
            this.win5Box = new ComboBox();
            this.label11 = new Label();
            this.win4Box = new ComboBox();
            this.label12 = new Label();
            this.label13 = new Label();
            this.map5Box = new ComboBox();
            this.map4Box = new ComboBox();
            this.logoLeftButton = new Button();
            this.logoRightButton = new Button();
            this.bestOfBox = new TextBox();
            this.groupBox1 = new GroupBox();
            this.label17 = new Label();
            this.pick5box = new ComboBox();
            this.label18 = new Label();
            this.pick4box = new ComboBox();
            this.pick1box = new ComboBox();
            this.label19 = new Label();
            this.pick2box = new ComboBox();
            this.label20 = new Label();
            this.label21 = new Label();
            this.pick3box = new ComboBox();
            this.clearText = new Button();
            this.groupBox2 = new GroupBox();
            this.groupBox3 = new GroupBox();
            this.timerEndBox = new TextBox();
            this.label16 = new Label();
            this.label15 = new Label();
            this.label14 = new Label();
            this.timerBox = new TextBox();
            this.timerStopGo = new Button();
            this.divBox1 = new TextBox();
            this.extraBox4 = new TextBox();
            this.extraBox3 = new TextBox();
            this.extraBox2 = new TextBox();
            this.extraBox1 = new TextBox();
            this.roundBox = new TextBox();
            this.countdownTimer = new Timer(this.components);
            this.openFileDialog = new OpenFileDialog();
            this.banLeftBox2 = new ComboBox();
            this.banRightBox2 = new ComboBox();
            this.leftScoreUD.BeginInit();
            this.rightScoreUD.BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            this.leftTeamLabel.AutoSize = true;
            this.leftTeamLabel.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.leftTeamLabel.Location = new Point(12, 16);
            this.leftTeamLabel.Name = "leftTeamLabel";
            this.leftTeamLabel.Size = new Size(81, 20);
            this.leftTeamLabel.TabIndex = 0;
            this.leftTeamLabel.Text = "Left Team";
            this.rightTeamLabel.AutoSize = true;
            this.rightTeamLabel.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.rightTeamLabel.Location = new Point(2, 65);
            this.rightTeamLabel.Name = "rightTeamLabel";
            this.rightTeamLabel.Size = new Size(91, 20);
            this.rightTeamLabel.TabIndex = 1;
            this.rightTeamLabel.Text = "Right Team";
            this.leftBox.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.leftBox.Location = new Point(93, 13);
            this.leftBox.Name = "leftBox";
            this.leftBox.Size = new Size(199, 26);
            this.leftBox.TabIndex = 1;
            this.leftBox.TextChanged += new EventHandler(this.leftBox_TextChanged);
            this.rightBox.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.rightBox.Location = new Point(93, 62);
            this.rightBox.Name = "rightBox";
            this.rightBox.Size = new Size(199, 26);
            this.rightBox.TabIndex = 2;
            this.rightBox.TextChanged += new EventHandler(this.rightBox_TextChanged);
            this.leftScoreLabel.AutoSize = true;
            this.leftScoreLabel.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.leftScoreLabel.Location = new Point(312, 16);
            this.leftScoreLabel.Name = "leftScoreLabel";
            this.leftScoreLabel.Size = new Size(83, 20);
            this.leftScoreLabel.TabIndex = 4;
            this.leftScoreLabel.Text = "Left Score";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label2.Location = new Point(302, 65);
            this.label2.Name = "label2";
            this.label2.Size = new Size(93, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Right Score";
            this.leftScoreUD.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.leftScoreUD.Location = new Point(401, 14);
            this.leftScoreUD.Name = "leftScoreUD";
            this.leftScoreUD.Size = new Size(49, 26);
            this.leftScoreUD.TabIndex = 3;
            this.leftScoreUD.ValueChanged += new EventHandler(this.leftScoreUD_ValueChanged);
            this.rightScoreUD.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.rightScoreUD.Location = new Point(401, 63);
            this.rightScoreUD.Name = "rightScoreUD";
            this.rightScoreUD.Size = new Size(49, 26);
            this.rightScoreUD.TabIndex = 4;
            this.rightScoreUD.ValueChanged += new EventHandler(this.rightScoreUD_ValueChanged);
            this.switchButton.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.switchButton.Location = new Point(6, 101);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new Size(335, 32);
            this.switchButton.TabIndex = 7;
            this.switchButton.Text = "Switch Team Sides (Anti Caster-trolling tool)";
            this.switchButton.UseVisualStyleBackColor = true;
            this.switchButton.Click += new EventHandler(this.switchButton_Click);
            this.scoreDisplayBox.AutoSize = true;
            this.scoreDisplayBox.CheckAlign = ContentAlignment.MiddleRight;
            this.scoreDisplayBox.Checked = true;
            this.scoreDisplayBox.CheckState = CheckState.Checked;
            this.scoreDisplayBox.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.scoreDisplayBox.Location = new Point(347, 108);
            this.scoreDisplayBox.Name = "scoreDisplayBox";
            this.scoreDisplayBox.Size = new Size(114, 24);
            this.scoreDisplayBox.TabIndex = 8;
            this.scoreDisplayBox.Text = "Show Score";
            this.scoreDisplayBox.UseVisualStyleBackColor = true;
            this.scoreDisplayBox.CheckedChanged += new EventHandler(this.scoreDisplayBox_CheckedChanged);
            this.banLeftBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.banLeftBox1.FormattingEnabled = true;
            this.banLeftBox1.Items.AddRange(new object[10]
            {
        (object) "Alterac Pass",
        (object) "Battlefield of Eternity",
        (object) "Braxis Holdout",
        (object) "Cursed Hollow",
        (object) "Dragon Shire",
        (object) "Infernal Shrines",
        (object) "Sky Temple",
        (object) "Tomb of the Spider Queen",
        (object) "Towers of Doom",
        (object) "Volskaya Foundry"
            });
            this.banLeftBox1.Location = new Point(102, 13);
            this.banLeftBox1.Name = "banLeftBox1";
            this.banLeftBox1.Size = new Size(129, 21);
            this.banLeftBox1.TabIndex = 20;
            this.banLeftBox1.SelectedIndexChanged += new EventHandler(this.banLeftBox_SelectedIndexChanged);
            this.banRightBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.banRightBox1.FormattingEnabled = true;
            this.banRightBox1.Items.AddRange(new object[10]
            {
        (object) "Alterac Pass",
        (object) "Battlefield of Eternity",
        (object) "Braxis Holdout",
        (object) "Cursed Hollow",
        (object) "Dragon Shire",
        (object) "Infernal Shrines",
        (object) "Sky Temple",
        (object) "Tomb of the Spider Queen",
        (object) "Towers of Doom",
        (object) "Volskaya Foundry"
            });
            this.banRightBox1.Location = new Point(102, 40);
            this.banRightBox1.Name = "banRightBox1";
            this.banRightBox1.Size = new Size(129, 21);
            this.banRightBox1.TabIndex = 21;
            this.banRightBox1.SelectedIndexChanged += new EventHandler(this.banRightBox_SelectedIndexChanged);
            this.map1Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.map1Box.FormattingEnabled = true;
            this.map1Box.Items.AddRange(new object[10]
            {
        (object) "Alterac Pass",
        (object) "Battlefield of Eternity",
        (object) "Braxis Holdout",
        (object) "Cursed Hollow",
        (object) "Dragon Shire",
        (object) "Infernal Shrines",
        (object) "Sky Temple",
        (object) "Tomb of the Spider Queen",
        (object) "Towers of Doom",
        (object) "Volskaya Foundry"
            });
            this.map1Box.Location = new Point(102, 67);
            this.map1Box.Name = "map1Box";
            this.map1Box.Size = new Size(163, 21);
            this.map1Box.TabIndex = 22;
            this.map1Box.SelectedIndexChanged += new EventHandler(this.map1Box_SelectedIndexChanged);
            this.map2Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.map2Box.FormattingEnabled = true;
            this.map2Box.Items.AddRange(new object[10]
            {
        (object) "Alterac Pass",
        (object) "Battlefield of Eternity",
        (object) "Braxis Holdout",
        (object) "Cursed Hollow",
        (object) "Dragon Shire",
        (object) "Infernal Shrines",
        (object) "Sky Temple",
        (object) "Tomb of the Spider Queen",
        (object) "Towers of Doom",
        (object) "Volskaya Foundry"
            });
            this.map2Box.Location = new Point(102, 94);
            this.map2Box.Name = "map2Box";
            this.map2Box.Size = new Size(163, 21);
            this.map2Box.TabIndex = 23;
            this.map2Box.SelectedIndexChanged += new EventHandler(this.map2Box_SelectedIndexChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new Size(52, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Bans Left";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new Size(59, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Bans Right";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new Size(37, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Map 2";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new Size(37, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Map 1";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(418, 70);
            this.label6.Name = "label6";
            this.label6.Size = new Size(35, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Win 1";
            this.win1Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.win1Box.FormattingEnabled = true;
            this.win1Box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.win1Box.Location = new Point(460, 67);
            this.win1Box.Name = "win1Box";
            this.win1Box.Size = new Size(90, 21);
            this.win1Box.TabIndex = 27;
            this.win1Box.SelectedIndexChanged += new EventHandler(this.win1Box_SelectedIndexChanged);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(418, 97);
            this.label7.Name = "label7";
            this.label7.Size = new Size(35, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Win 2";
            this.win2Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.win2Box.FormattingEnabled = true;
            this.win2Box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.win2Box.Location = new Point(460, 94);
            this.win2Box.Name = "win2Box";
            this.win2Box.Size = new Size(90, 21);
            this.win2Box.TabIndex = 28;
            this.win2Box.SelectedIndexChanged += new EventHandler(this.win2Box_SelectedIndexChanged);
            this.clearButton.Location = new Point(369, 13);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new Size(84, 43);
            this.clearButton.TabIndex = 32;
            this.clearButton.Text = "Clear Maps!";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new EventHandler(this.clearButton_Click);
            this.label8.AutoSize = true;
            this.label8.Location = new Point(418, 124);
            this.label8.Name = "label8";
            this.label8.Size = new Size(35, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Win 3";
            this.win3Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.win3Box.FormattingEnabled = true;
            this.win3Box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.win3Box.Location = new Point(460, 121);
            this.win3Box.Name = "win3Box";
            this.win3Box.Size = new Size(90, 21);
            this.win3Box.TabIndex = 29;
            this.win3Box.SelectedIndexChanged += new EventHandler(this.win3Box_SelectedIndexChanged);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(6, 124);
            this.label9.Name = "label9";
            this.label9.Size = new Size(37, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Map 3";
            this.map3Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.map3Box.FormattingEnabled = true;
            this.map3Box.Items.AddRange(new object[10]
            {
        (object) "Alterac Pass",
        (object) "Battlefield of Eternity",
        (object) "Braxis Holdout",
        (object) "Cursed Hollow",
        (object) "Dragon Shire",
        (object) "Infernal Shrines",
        (object) "Sky Temple",
        (object) "Tomb of the Spider Queen",
        (object) "Towers of Doom",
        (object) "Volskaya Foundry"
            });
            this.map3Box.Location = new Point(102, 121);
            this.map3Box.Name = "map3Box";
            this.map3Box.Size = new Size(163, 21);
            this.map3Box.TabIndex = 24;
            this.map3Box.SelectedIndexChanged += new EventHandler(this.map3Box_SelectedIndexChanged);
            this.label10.AutoSize = true;
            this.label10.Location = new Point(418, 178);
            this.label10.Name = "label10";
            this.label10.Size = new Size(35, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Win 5";
            this.win5Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.win5Box.FormattingEnabled = true;
            this.win5Box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.win5Box.Location = new Point(460, 175);
            this.win5Box.Name = "win5Box";
            this.win5Box.Size = new Size(90, 21);
            this.win5Box.TabIndex = 31;
            this.win5Box.SelectedIndexChanged += new EventHandler(this.win5Box_SelectedIndexChanged);
            this.label11.AutoSize = true;
            this.label11.Location = new Point(418, 151);
            this.label11.Name = "label11";
            this.label11.Size = new Size(35, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Win 4";
            this.win4Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.win4Box.FormattingEnabled = true;
            this.win4Box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.win4Box.Location = new Point(460, 148);
            this.win4Box.Name = "win4Box";
            this.win4Box.Size = new Size(90, 21);
            this.win4Box.TabIndex = 30;
            this.win4Box.SelectedIndexChanged += new EventHandler(this.win4Box_SelectedIndexChanged);
            this.label12.AutoSize = true;
            this.label12.Location = new Point(6, 178);
            this.label12.Name = "label12";
            this.label12.Size = new Size(37, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Map 5";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(6, 151);
            this.label13.Name = "label13";
            this.label13.Size = new Size(37, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Map 4";
            this.map5Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.map5Box.FormattingEnabled = true;
            this.map5Box.Items.AddRange(new object[10]
            {
        (object) "Alterac Pass",
        (object) "Battlefield of Eternity",
        (object) "Braxis Holdout",
        (object) "Cursed Hollow",
        (object) "Dragon Shire",
        (object) "Infernal Shrines",
        (object) "Sky Temple",
        (object) "Tomb of the Spider Queen",
        (object) "Towers of Doom",
        (object) "Volskaya Foundry"
            });
            this.map5Box.Location = new Point(102, 175);
            this.map5Box.Name = "map5Box";
            this.map5Box.Size = new Size(163, 21);
            this.map5Box.TabIndex = 26;
            this.map5Box.SelectedIndexChanged += new EventHandler(this.map5Box_SelectedIndexChanged);
            this.map4Box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.map4Box.FormattingEnabled = true;
            this.map4Box.Items.AddRange(new object[10]
            {
        (object) "Alterac Pass",
        (object) "Battlefield of Eternity",
        (object) "Braxis Holdout",
        (object) "Cursed Hollow",
        (object) "Dragon Shire",
        (object) "Infernal Shrines",
        (object) "Sky Temple",
        (object) "Tomb of the Spider Queen",
        (object) "Towers of Doom",
        (object) "Volskaya Foundry"
            });
            this.map4Box.Location = new Point(102, 148);
            this.map4Box.Name = "map4Box";
            this.map4Box.Size = new Size(163, 21);
            this.map4Box.TabIndex = 25;
            this.map4Box.SelectedIndexChanged += new EventHandler(this.map4Box_SelectedIndexChanged);
            this.logoLeftButton.Location = new Point(466, 16);
            this.logoLeftButton.Name = "logoLeftButton";
            this.logoLeftButton.Size = new Size(75, 23);
            this.logoLeftButton.TabIndex = 5;
            this.logoLeftButton.Text = "Set Logo";
            this.logoLeftButton.UseVisualStyleBackColor = true;
            this.logoLeftButton.Click += new EventHandler(this.logoLeftButton_Click);
            this.logoRightButton.Location = new Point(466, 65);
            this.logoRightButton.Name = "logoRightButton";
            this.logoRightButton.Size = new Size(75, 23);
            this.logoRightButton.TabIndex = 6;
            this.logoRightButton.Text = "Set Logo";
            this.logoRightButton.UseVisualStyleBackColor = true;
            this.logoRightButton.Click += new EventHandler(this.logoRightButton_Click);
            this.bestOfBox.Location = new Point(45, 19);
            this.bestOfBox.Name = "bestOfBox";
            this.bestOfBox.Size = new Size(140, 20);
            this.bestOfBox.TabIndex = 10;
            this.bestOfBox.Text = "Bo3";
            this.bestOfBox.TextChanged += new EventHandler(this.bestOfBox_TextChanged);
            this.groupBox1.Controls.Add((Control)this.banLeftBox2);
            this.groupBox1.Controls.Add((Control)this.banRightBox2);
            this.groupBox1.Controls.Add((Control)this.label17);
            this.groupBox1.Controls.Add((Control)this.pick5box);
            this.groupBox1.Controls.Add((Control)this.label18);
            this.groupBox1.Controls.Add((Control)this.pick4box);
            this.groupBox1.Controls.Add((Control)this.pick1box);
            this.groupBox1.Controls.Add((Control)this.label19);
            this.groupBox1.Controls.Add((Control)this.pick2box);
            this.groupBox1.Controls.Add((Control)this.label20);
            this.groupBox1.Controls.Add((Control)this.label21);
            this.groupBox1.Controls.Add((Control)this.pick3box);
            this.groupBox1.Controls.Add((Control)this.clearText);
            this.groupBox1.Controls.Add((Control)this.label1);
            this.groupBox1.Controls.Add((Control)this.banLeftBox1);
            this.groupBox1.Controls.Add((Control)this.banRightBox1);
            this.groupBox1.Controls.Add((Control)this.map1Box);
            this.groupBox1.Controls.Add((Control)this.label10);
            this.groupBox1.Controls.Add((Control)this.map2Box);
            this.groupBox1.Controls.Add((Control)this.win5Box);
            this.groupBox1.Controls.Add((Control)this.label3);
            this.groupBox1.Controls.Add((Control)this.label11);
            this.groupBox1.Controls.Add((Control)this.label5);
            this.groupBox1.Controls.Add((Control)this.win4Box);
            this.groupBox1.Controls.Add((Control)this.label4);
            this.groupBox1.Controls.Add((Control)this.label12);
            this.groupBox1.Controls.Add((Control)this.label13);
            this.groupBox1.Controls.Add((Control)this.win1Box);
            this.groupBox1.Controls.Add((Control)this.map5Box);
            this.groupBox1.Controls.Add((Control)this.label6);
            this.groupBox1.Controls.Add((Control)this.map4Box);
            this.groupBox1.Controls.Add((Control)this.win2Box);
            this.groupBox1.Controls.Add((Control)this.label8);
            this.groupBox1.Controls.Add((Control)this.label7);
            this.groupBox1.Controls.Add((Control)this.win3Box);
            this.groupBox1.Controls.Add((Control)this.clearButton);
            this.groupBox1.Controls.Add((Control)this.label9);
            this.groupBox1.Controls.Add((Control)this.map3Box);
            this.groupBox1.Location = new Point(12, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(557, 201);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Controls";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(273, 178);
            this.label17.Name = "label17";
            this.label17.Size = new Size(37, 13);
            this.label17.TabIndex = 46;
            this.label17.Text = "Pick 5";
            this.pick5box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.pick5box.FormattingEnabled = true;
            this.pick5box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.pick5box.Location = new Point(316, 175);
            this.pick5box.Name = "pick5box";
            this.pick5box.Size = new Size(90, 21);
            this.pick5box.TabIndex = 44;
            this.pick5box.SelectedIndexChanged += new EventHandler(this.pick5box_SelectedIndexChanged);
            this.label18.AutoSize = true;
            this.label18.Location = new Point(273, 151);
            this.label18.Name = "label18";
            this.label18.Size = new Size(37, 13);
            this.label18.TabIndex = 45;
            this.label18.Text = "Pick 4";
            this.pick4box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.pick4box.FormattingEnabled = true;
            this.pick4box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.pick4box.Location = new Point(316, 148);
            this.pick4box.Name = "pick4box";
            this.pick4box.Size = new Size(90, 21);
            this.pick4box.TabIndex = 43;
            this.pick4box.SelectedIndexChanged += new EventHandler(this.pick4box_SelectedIndexChanged);
            this.pick1box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.pick1box.FormattingEnabled = true;
            this.pick1box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.pick1box.Location = new Point(316, 67);
            this.pick1box.Name = "pick1box";
            this.pick1box.Size = new Size(90, 21);
            this.pick1box.TabIndex = 39;
            this.pick1box.SelectedIndexChanged += new EventHandler(this.pick1box_SelectedIndexChanged);
            this.label19.AutoSize = true;
            this.label19.Location = new Point(273, 70);
            this.label19.Name = "label19";
            this.label19.Size = new Size(37, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "Pick 1";
            this.pick2box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.pick2box.FormattingEnabled = true;
            this.pick2box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.pick2box.Location = new Point(316, 94);
            this.pick2box.Name = "pick2box";
            this.pick2box.Size = new Size(90, 21);
            this.pick2box.TabIndex = 41;
            this.pick2box.SelectedIndexChanged += new EventHandler(this.pick2box_SelectedIndexChanged);
            this.label20.AutoSize = true;
            this.label20.Location = new Point(273, 124);
            this.label20.Name = "label20";
            this.label20.Size = new Size(37, 13);
            this.label20.TabIndex = 40;
            this.label20.Text = "Pick 3";
            this.label21.AutoSize = true;
            this.label21.Location = new Point(273, 97);
            this.label21.Name = "label21";
            this.label21.Size = new Size(37, 13);
            this.label21.TabIndex = 38;
            this.label21.Text = "Pick 2";
            this.pick3box.DropDownStyle = ComboBoxStyle.DropDownList;
            this.pick3box.FormattingEnabled = true;
            this.pick3box.Items.AddRange(new object[2]
            {
        (object) "Left Team",
        (object) "Right Team"
            });
            this.pick3box.Location = new Point(316, 121);
            this.pick3box.Name = "pick3box";
            this.pick3box.Size = new Size(90, 21);
            this.pick3box.TabIndex = 42;
            this.pick3box.SelectedIndexChanged += new EventHandler(this.pick3box_SelectedIndexChanged);
            this.clearText.Location = new Point(460, 13);
            this.clearText.Name = "clearText";
            this.clearText.Size = new Size(91, 43);
            this.clearText.TabIndex = 36;
            this.clearText.Text = "Clear All Text!";
            this.clearText.UseVisualStyleBackColor = true;
            this.clearText.Click += new EventHandler(this.clearText_Click);
            this.groupBox2.Controls.Add((Control)this.leftTeamLabel);
            this.groupBox2.Controls.Add((Control)this.rightTeamLabel);
            this.groupBox2.Controls.Add((Control)this.leftBox);
            this.groupBox2.Controls.Add((Control)this.logoRightButton);
            this.groupBox2.Controls.Add((Control)this.rightBox);
            this.groupBox2.Controls.Add((Control)this.logoLeftButton);
            this.groupBox2.Controls.Add((Control)this.leftScoreLabel);
            this.groupBox2.Controls.Add((Control)this.scoreDisplayBox);
            this.groupBox2.Controls.Add((Control)this.label2);
            this.groupBox2.Controls.Add((Control)this.switchButton);
            this.groupBox2.Controls.Add((Control)this.leftScoreUD);
            this.groupBox2.Controls.Add((Control)this.rightScoreUD);
            this.groupBox2.Location = new Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(557, 138);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Team Controls";
            this.groupBox3.Controls.Add((Control)this.timerEndBox);
            this.groupBox3.Controls.Add((Control)this.label16);
            this.groupBox3.Controls.Add((Control)this.label15);
            this.groupBox3.Controls.Add((Control)this.label14);
            this.groupBox3.Controls.Add((Control)this.timerBox);
            this.groupBox3.Controls.Add((Control)this.timerStopGo);
            this.groupBox3.Controls.Add((Control)this.divBox1);
            this.groupBox3.Controls.Add((Control)this.extraBox4);
            this.groupBox3.Controls.Add((Control)this.extraBox3);
            this.groupBox3.Controls.Add((Control)this.extraBox2);
            this.groupBox3.Controls.Add((Control)this.extraBox1);
            this.groupBox3.Controls.Add((Control)this.roundBox);
            this.groupBox3.Controls.Add((Control)this.bestOfBox);
            this.groupBox3.Location = new Point(12, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(557, 134);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Text Controls";
            this.timerEndBox.Location = new Point(61, 99);
            this.timerEndBox.Name = "timerEndBox";
            this.timerEndBox.Size = new Size(59, 20);
            this.timerEndBox.TabIndex = 14;
            this.timerEndBox.Text = "Timer done";
            this.timerEndBox.TextChanged += new EventHandler(this.timerEndBox_TextChanged);
            this.label16.AutoSize = true;
            this.label16.Location = new Point(3, 74);
            this.label16.Name = "label16";
            this.label16.Size = new Size(23, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Div";
            this.label15.AutoSize = true;
            this.label15.Location = new Point(3, 48);
            this.label15.Name = "label15";
            this.label15.Size = new Size(39, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Round";
            this.label14.AutoSize = true;
            this.label14.Location = new Point(3, 22);
            this.label14.Name = "label14";
            this.label14.Size = new Size(40, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Best of";
            this.timerBox.Location = new Point(6, 99);
            this.timerBox.Name = "timerBox";
            this.timerBox.Size = new Size(49, 20);
            this.timerBox.TabIndex = 13;
            this.timerBox.Text = "10:00";
            this.timerBox.TextChanged += new EventHandler(this.timerBox_TextChanged);
            this.timerStopGo.Location = new Point(126, 96);
            this.timerStopGo.Name = "timerStopGo";
            this.timerStopGo.Size = new Size(59, 23);
            this.timerStopGo.TabIndex = 14;
            this.timerStopGo.Text = "Go";
            this.timerStopGo.UseVisualStyleBackColor = true;
            this.timerStopGo.Click += new EventHandler(this.timerStopGo_Click);
            this.divBox1.Location = new Point(45, 71);
            this.divBox1.Name = "divBox1";
            this.divBox1.Size = new Size(140, 20);
            this.divBox1.TabIndex = 12;
            this.divBox1.Text = "Division B West";
            this.divBox1.TextChanged += new EventHandler(this.divBox1_TextChanged);
            this.extraBox4.Location = new Point(191, 97);
            this.extraBox4.Name = "extraBox4";
            this.extraBox4.Size = new Size(360, 20);
            this.extraBox4.TabIndex = 18;
            this.extraBox4.Text = "Extra Box 4";
            this.extraBox4.TextChanged += new EventHandler(this.extraBox4_TextChanged);
            this.extraBox3.Location = new Point(191, 71);
            this.extraBox3.Name = "extraBox3";
            this.extraBox3.Size = new Size(360, 20);
            this.extraBox3.TabIndex = 17;
            this.extraBox3.Text = "Extra Box 3";
            this.extraBox3.TextChanged += new EventHandler(this.extraBox3_TextChanged);
            this.extraBox2.Location = new Point(191, 45);
            this.extraBox2.Name = "extraBox2";
            this.extraBox2.Size = new Size(360, 20);
            this.extraBox2.TabIndex = 16;
            this.extraBox2.Text = "Extra Box 2";
            this.extraBox2.TextChanged += new EventHandler(this.extraBox2_TextChanged);
            this.extraBox1.Location = new Point(191, 19);
            this.extraBox1.Name = "extraBox1";
            this.extraBox1.Size = new Size(360, 20);
            this.extraBox1.TabIndex = 15;
            this.extraBox1.Text = "Extra Box 1";
            this.extraBox1.TextChanged += new EventHandler(this.extraBox1_TextChanged);
            this.roundBox.Location = new Point(45, 45);
            this.roundBox.Name = "roundBox";
            this.roundBox.Size = new Size(140, 20);
            this.roundBox.TabIndex = 11;
            this.roundBox.Text = "Round 1";
            this.roundBox.TextChanged += new EventHandler(this.roundBox_TextChanged);
            this.countdownTimer.Interval = 1000;
            this.countdownTimer.Tick += new EventHandler(this.countdownTimer_Tick);
            this.openFileDialog.FileOk += new CancelEventHandler(this.openFileDialog_FileOk);
            this.banLeftBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.banLeftBox2.FormattingEnabled = true;
            this.banLeftBox2.Items.AddRange(new object[10]
            {
        (object) "Alterac Pass",
        (object) "Battlefield of Eternity",
        (object) "Braxis Holdout",
        (object) "Cursed Hollow",
        (object) "Dragon Shire",
        (object) "Infernal Shrines",
        (object) "Sky Temple",
        (object) "Tomb of the Spider Queen",
        (object) "Towers of Doom",
        (object) "Volskaya Foundry"
            });
            this.banLeftBox2.Location = new Point(234, 13);
            this.banLeftBox2.Name = "banLeftBox2";
            this.banLeftBox2.Size = new Size(129, 21);
            this.banLeftBox2.TabIndex = 47;
            this.banLeftBox2.SelectedIndexChanged += new EventHandler(this.banLeftBox2_SelectedIndexChanged);
            this.banRightBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.banRightBox2.FormattingEnabled = true;
            this.banRightBox2.Items.AddRange(new object[10]
            {
        (object) "Alterac Pass",
        (object) "Battlefield of Eternity",
        (object) "Braxis Holdout",
        (object) "Cursed Hollow",
        (object) "Dragon Shire",
        (object) "Infernal Shrines",
        (object) "Sky Temple",
        (object) "Tomb of the Spider Queen",
        (object) "Towers of Doom",
        (object) "Volskaya Foundry"
            });
            this.banRightBox2.Location = new Point(234, 40);
            this.banRightBox2.Name = "banRightBox2";
            this.banRightBox2.Size = new Size(129, 21);
            this.banRightBox2.TabIndex = 48;
            this.banRightBox2.SelectedIndexChanged += new EventHandler(this.banRightBox2_SelectedIndexChanged);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(580, 507);
            this.Controls.Add((Control)this.groupBox3);
            this.Controls.Add((Control)this.groupBox2);
            this.Controls.Add((Control)this.groupBox1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = nameof(WholeForm);
            this.Text = "Casting Overlay Tool";
            this.Load += new EventHandler(this.Form1_Load);
            this.leftScoreUD.EndInit();
            this.rightScoreUD.EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        private void CopyFile(string src, string dst, bool overwrite)
        {
            File.Copy(src, dst, overwrite);
            File.SetLastWriteTime(dst, DateTime.Now);
        }
    }
}
