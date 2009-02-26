using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;

namespace Scout
{
	public partial class ToDoItemControl : UserControl
	{
		private InkOverlay overlay;

		public ToDoItemControl()
		{
			InitializeComponent();

			ResizeRedraw = true;

			HandleCreated += new EventHandler(ToDoItemControl_HandleCreated);

			center.LineAlignment = StringAlignment.Center;
			center.Alignment = StringAlignment.Center;

			left.LineAlignment = StringAlignment.Center;
			left.Alignment = StringAlignment.Near;

			bluePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

			MouseClick += new MouseEventHandler(ToDoItemControl_MouseClick);
		}

		void ToDoItemControl_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (Editing != null)
					Editing(this, EventArgs.Empty);
			}
		}

		public event EventHandler Editing;

		Font personFont;

		void ToDoItemControl_HandleCreated(object sender, EventArgs e)
		{
			panel1.BackColor = Color.Transparent;
			overlay = new InkOverlay(panel1);
			overlay.Enabled = true;

			overlay.CollectionMode = CollectionMode.InkAndGesture;
            overlay.SetGestureStatus(ApplicationGesture.Up, true);
            overlay.SetGestureStatus(ApplicationGesture.Down, true);
            overlay.SetGestureStatus(ApplicationGesture.Right, true);
            overlay.SetGestureStatus(ApplicationGesture.ArrowUp, true);
            overlay.SetGestureStatus(ApplicationGesture.ArrowDown, true);
            overlay.SetGestureStatus(ApplicationGesture.Check, true);
            overlay.SetGestureStatus(ApplicationGesture.Square, true);
            overlay.SetGestureStatus(ApplicationGesture.Circle, true);
			//overlay.Gesture += new InkCollectorGestureEventHandler(overlay_Gesture);
			overlay.Stroke += new InkCollectorStrokeEventHandler(overlay_Stroke);

			CreateRecognizer(overlay);

			personFont = new Font(Font, FontStyle.Bold);
		}

		private void CreateRecognizer(InkOverlay overlay)
		{
			Recognizers recognizers = new Recognizers();
			Recognizer english = recognizers.GetDefaultRecognizer();
			context = english.CreateRecognizerContext();

			WordList wordList = new WordList();
			for (int i = 0; i < 100; ++i)
				wordList.Add(i.ToString());

			context.WordList = wordList;
			context.Factoid = Factoid.WordList;
			context.RecognitionFlags = RecognitionModes.Coerce;

		}

		RecognizerContext context;

		void overlay_Stroke(object sender, InkCollectorStrokeEventArgs e)
		{
			StartTimer();
		}

		private void RecognizeNumber()
		{
			context.Strokes = overlay.Ink.Strokes;

			if (ToDoItem != null && context.Strokes.Count > 0)
			{
				RecognitionStatus status;
				RecognitionResult result = context.Recognize(out status);
				if (status == RecognitionStatus.NoError && result.TopConfidence == RecognitionConfidence.Strong)
				{
					int newValue;
					if (int.TryParse(result.ToString(), out newValue))
					{
						if (newValue > 0)
						{
							ToDoItem.IsCompleted = false;
							ToDoItem.Position = newValue;
						}
						else if (newValue == 0)
							AssumeToggle();
					}
				}
				else
				{
					AssumeToggle();
				}
			}

			overlay.Ink.DeleteStrokes();
			Refresh();
		}

		private void AssumeToggle()
		{
			ToDoItem.IsCompleted = !ToDoItem.IsCompleted;
		}

		void overlay_Gesture(object sender, InkCollectorGestureEventArgs e)
		{
            if (ToDoItem != null && e.Gestures.Length > 0)
			{
                overlay.Ink.DeleteStrokes();

                switch (e.Gestures[0].Id)
                {
                    case ApplicationGesture.ArrowUp:
                    case ApplicationGesture.Up:
                        ToDoItem.Position -= 1;
                        break;
                    case ApplicationGesture.ArrowDown:
                    case ApplicationGesture.Down:
                        ToDoItem.Position += 1;
                        break;
                    case ApplicationGesture.Check:
                    case ApplicationGesture.Right:
                        ToDoItem.IsCompleted = true;
                        break;
                    case ApplicationGesture.Square:
                        ToDoItem.IsCompleted = false;
                        break;
                    case ApplicationGesture.Circle:
                        ToDoItem.IsCompleted = !ToDoItem.IsCompleted;
                        break;
                }
			}
			else
			{
				e.Cancel = true;
			}
		}

		private void StartTimer()
		{
			Timer timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += delegate { StopTimer(timer); RecognizeNumber(); };
			timer.Enabled = true;
		}

		private void StopTimer(Timer timer)
		{
			timer.Enabled = false;
			timer.Dispose();
		}

		public BasecampAPI.ToDoItem ToDoItem;
		public BasecampAPI.Person Person;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			DrawNumber(e);

			DrawText(e);

			DrawNotebookLine(e);
		}


		StringFormat center = StringFormat.GenericTypographic.Clone() as StringFormat;
		StringFormat left = StringFormat.GenericTypographic.Clone() as StringFormat;

		private void DrawText(PaintEventArgs e)
		{
			if (ToDoItem == null) return;

			int startX = panel1.Right + 5;

			if (Person != null)
			{
				string name = Person.Name + ": ";
				SizeF size = e.Graphics.MeasureString(name, personFont);
				Rectangle personRect = Rectangle.FromLTRB(startX, 0, startX + (int)size.Width, Height);
				e.Graphics.DrawString(
					name,
					personFont,
					ToDoItem.IsCompleted ? Brushes.Gray : Brushes.Black,
					personRect,
					left);

				startX += (int)size.Width + 5;
			}

			RectangleF r = Rectangle.FromLTRB(startX, 0, Width, Height);

			e.Graphics.DrawString(
				ToDoItem.Content,
				Font,
				ToDoItem.IsCompleted ? Brushes.Gray : Brushes.Black,
				r,
				left);
		}

		private void DrawNumber(PaintEventArgs e)
		{
			if (ToDoItem == null || ToDoItem.IsCompleted) return;

			RectangleF r = Rectangle.FromLTRB(0, 0, panel1.Right, panel1.Height - 15);

			e.Graphics.DrawString(ToDoItem.Position.ToString(), Font, Brushes.Black, r, center);
		}

		Pen bluePen = new Pen(Color.LightBlue, 1);
		
		private void DrawNotebookLine(PaintEventArgs e)
		{
			
			int bottom = Height - 2;
			e.Graphics.DrawLine(bluePen, 0, bottom, Width, bottom);
			e.Graphics.DrawLine(Pens.LightPink, panel1.Right - 3, 0, panel1.Right - 3, Height);
		}
	}

}
