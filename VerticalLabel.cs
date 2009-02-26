using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Scout
{
	public partial class VerticalLabel : Label
	{
		public bool Initializing = true;
		public VerticalLabel()
		{
			InitializeComponent();
		}

		private bool bChanging = false;

		protected override void OnTextChanged(EventArgs e)
		{
			if (!bChanging && !Initializing)
			{
				Bitmap bmp = new Bitmap(175, 175);
				Graphics graphics = Graphics.FromImage(bmp);
				SizeF size = new SizeF();

				size = MeasureStringExtended(graphics, this.Text, this.Font, Parent.Width);
				this.Height = (int)size.Height;
				base.OnTextChanged(e);
			}
		}
	
		private SizeF MeasureStringExtended(Graphics g, string text, Font font, int desWidth)
		{
			string tempString = text;
			string workString = "";
			string outputstring = "";
			int npos = 1;
			int sp_pos = 0;
			int sp_pos1 = 0;
			int sp_pos2 = 0;
			int sp_pos3 = 0;
			bool bNeeded = false;
			int line = 0;
			int nWidth = 0;

			//get original size
			SizeF size = g.MeasureString(text, font);

			if (size.Width > desWidth)
			{
				while (tempString.Length > 0)
				{
					//Check for the last lane
					if (npos > tempString.Length)
					{
						outputstring = outputstring + tempString;
						line++;
						break;
					}
					workString = tempString.Substring(0, npos);
					//get the current width
					nWidth = (int)g.MeasureString(workString, font).Width;
					//check if we've got out of the destWidth
					if (nWidth > desWidth)
					{
						//try to find a space

						sp_pos1 = workString.LastIndexOf(" ");
						sp_pos2 = workString.LastIndexOf(";");
						sp_pos3 = workString.IndexOf("\r\n");
						if (sp_pos3 > 0)
						{
							sp_pos = sp_pos3;
							bNeeded = false;
						}
						else
						{
							if ((sp_pos2 > 0) && (sp_pos2 > sp_pos1))
							{
								sp_pos = sp_pos2;
								bNeeded = true;
							}
							else if (sp_pos1 > 0)
							{
								sp_pos = sp_pos1;
								bNeeded = true;
							}
							else
							{
								sp_pos = 0;
								bNeeded = true;
							}
						}

						if (sp_pos > 0)
						{
							//cut out the wrap lane we've found
							outputstring = outputstring + tempString.Substring(0, sp_pos + 1);
							if (bNeeded) outputstring = outputstring + "\r\n";
							tempString = tempString.Substring((sp_pos + 1), tempString.Length - (sp_pos + 1));
							line++;
							npos = 0;
						}
						else //no space
						{
							outputstring = outputstring + tempString.Substring(0, npos + 1);
							if (bNeeded) outputstring = outputstring + "\r\n";
							tempString = tempString.Substring(npos, tempString.Length - npos);
							line++;
							npos = 0;
						}
					}
					npos++;
				}
			}
			else
			{
				outputstring = text;
			}

			SizeF returnSize = g.MeasureString(outputstring, font);
			bChanging = true;
			this.Text = outputstring;
			bChanging = false;
			return returnSize;
		}
	}
}


