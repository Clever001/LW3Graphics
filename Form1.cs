using Microsoft.VisualBasic.Devices;
using System.Diagnostics;

namespace LW2Graphics
{
    public partial class Form1 : Form
    {
        private Control[] visibleObjects;
        private Bitmap bitmap;
        private Pen pen;
        private Point[] picturePoints;
        private Point center;
        private bool centerPosition; // Расположение объекта (True - по центру; False - произвольное)
        private enum Action { None, Movement, Turn, Resize };
        private Action curAction;

        private Color borderColor = Color.FromArgb(255, 0, 0, 0);
        //private Color fillColor = Color.FromArgb(255, 255, 255, 255);

        public Form1()
        {
            InitializeComponent();
            visibleObjects = [startLabel, inputLabel1, inputLabel2, input1, input2, applyButton];
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bitmap;
            pen = new Pen(Brushes.Black, 5);
            center = new Point(pictureBox.Width / 2, pictureBox.Height / 2);
            picturePoints = [new(center.X - 100, center.Y - 200),
                             new(center.X + 100, center.Y - 200),
                             new(center.X + 200, center.Y),
                             new(center.X + 100, center.Y + 200),
                             new(center.X - 100, center.Y + 200),
                             new(center.X - 200, center.Y)];
            centerPosition = true;
            curAction = Action.None;
            DrawFigure();
        }

        private void MakeInvisible()
        {
            Array.ForEach(visibleObjects, item => item.Visible = false);
            input1.Text = string.Empty;
            input2.Text = string.Empty;
        }

        // ---------- Отрисовка фигуры

        private void DrawFigure()
        {
            using Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            for (int i = 0; i != picturePoints.Length; i++)
            {
                if (i + 1 != picturePoints.Length) // Точка с индексом i не последняя в массиве
                {
                    g.DrawLine(pen, picturePoints[i], picturePoints[i + 1]);
                }
                else
                {
                    g.DrawLine(pen, picturePoints[0], picturePoints[i]);
                }
            }
            // if (center.X >= 0 && center.Y >= 0 && center.X <= pictureBox.Width && center.Y <= pictureBox.Height)
            //     bitmap.SetPixel(center.X, center.Y, Color.Red);
            g.Flush();
            pictureBox.Invalidate();
        }

        // ---------- Реализация ведёрка (закрашивания фигуры)

        private void FillFigure(Color newFillColor)
        {
            if (center.X >= 0 && center.Y >= 0 && center.X <= pictureBox.Width && center.Y <= pictureBox.Height)
            {
                Stopwatch sw = new();
                sw.Start();
                HashSet<Point> checkedPoints = new();
                Queue<Point> pointsQueue = new();
                pointsQueue.Enqueue(center);
                Point curPoint, newPoint;
                while (pointsQueue.Count != 0)
                {
                    curPoint = pointsQueue.Dequeue();
                    if (checkedPoints.Contains(curPoint))
                        continue;
                    checkedPoints.Add(curPoint);
                    if (bitmap.GetPixel(curPoint.X, curPoint.Y) == borderColor)
                        continue;
                    bitmap.SetPixel(curPoint.X, curPoint.Y, newFillColor);

                    newPoint = new Point(curPoint.X - 1, curPoint.Y);
                    if (!checkedPoints.Contains(newPoint)) pointsQueue.Enqueue(newPoint);

                    newPoint = new Point(curPoint.X, curPoint.Y - 1);
                    if (!checkedPoints.Contains(newPoint)) pointsQueue.Enqueue(newPoint);

                    newPoint = new Point(curPoint.X + 1, curPoint.Y);
                    if (!checkedPoints.Contains(newPoint)) pointsQueue.Enqueue(newPoint);

                    newPoint = new Point(curPoint.X, curPoint.Y + 1);
                    if (!checkedPoints.Contains(newPoint)) pointsQueue.Enqueue(newPoint);
                }
                pictureBox.Refresh();
                sw.Stop();
                MessageBox.Show($"Всего было потрачено времени: {sw.ElapsedMilliseconds} мск." + Environment.NewLine 
                    + $"Всего обработано точек: {checkedPoints.Count} шт.", "Сведенья об времени работы алгоритма");
            }
            else
            {
                MessageBox.Show("Центр фигуры должен находиться в пределах видимости, чтобы можно было закрасить фигуру.", "ERROR");
            }
            GC.Collect();
        }

        // ---------- Изменение размеров bitmap

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ChangeBitmapSize(centerPosition);
        }

        private void ChangeBitmapSize(bool centerPos)
        {
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bitmap;
            if (centerPos)
            {
                Point newCenter = new Point(pictureBox.Width / 2, pictureBox.Height / 2);
                int dx = newCenter.X - center.X, dy = newCenter.Y - center.Y;
                for (int i = 0; i != picturePoints.Length; i++)
                {
                    picturePoints[i].X += dx;
                    picturePoints[i].Y += dy;
                }
                center = newCenter;
            }
            DrawFigure();
        }

        // ---------- Аффинное преобразование "Движение"

        private void ChangePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Добавляет необходимые объекты на форму
            MakeInvisible(); // Сначала делаем все объекта невидимыми. Потом добавляем необходимые.

            inputLabel1.Visible = true;
            inputLabel2.Visible = true;
            input1.Visible = true;
            input2.Visible = true;
            applyButton.Visible = true;
            inputLabel1.Text = "На сколько вы хотите изменить x?";
            inputLabel2.Text = "На сколько вы хотите изменить y?";
            curAction = Action.Movement;
        }

        private void ChangePosition()
        {
            // Реализует "движение" объекта
            int dx, dy;
            if (!int.TryParse(input1.Text, out dx) || !int.TryParse(input2.Text, out dy))
            {
                MessageBox.Show("Не получилось распознать входные данные.", "ERROR");
                return;
            }
            if (centerPosition)
            {
                MessageBox.Show("Измените расположение объекта на значение \"Произвольное\"", "ERROR");
                return;
            }
            center.X += dx; center.Y += dy;
            for (int i = 0; i != picturePoints.Length; i++)
            {
                picturePoints[i].X += dx;
                picturePoints[i].Y += dy;
            }
        }

        // ---------- Аффинное преобразование "Поворот"

        private void FlipObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeInvisible();

            inputLabel1.Visible = true;
            input1.Visible = true;
            applyButton.Visible = true;
            inputLabel1.Text = "Введите угол поворота (в градусах)";
            curAction = Action.Turn;
        }

        private void FlipObject()
        {
            // Реализует "поворот" объекта
            double x;
            if (!double.TryParse(input1.Text, out x))
            {
                MessageBox.Show("Не получилось распознать входные данные.", "ERROR");
                return;
            }
            double rads = x * Math.PI / 180;
            MakeRelativeCoordinates();
            for (int i = 0; i != picturePoints.Length; i++)
            {
                Point tmp = picturePoints[i];
                picturePoints[i].X = (int)Math.Round(tmp.X * Math.Cos(rads) - tmp.Y * Math.Sin(rads));
                picturePoints[i].Y = (int)Math.Round(tmp.X * Math.Sin(rads) + tmp.Y * Math.Cos(rads));
            }
            MakeAbsoluteCoordinates();
        }

        // ---------- Аффинное преобразование "Растяжение/сжатие"

        private void ChangeSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeInvisible();

            inputLabel1.Visible = true;
            input1.Visible = true;
            applyButton.Visible = true;
            inputLabel1.Text = "Введите коэффициент сжатия (растяжения)";
            curAction = Action.Resize;
        }

        private void ResizeObject()
        {
            // Реализует "растяжение/сжатие" объекта
            double k;
            if (!double.TryParse(input1.Text, out k))
            {
                MessageBox.Show("Не получилось распознать входные данные.", "ERROR");
                return;
            }
            MakeRelativeCoordinates();
            for (int i = 0; i != picturePoints.Length; i++)
            {
                picturePoints[i].X = (int)Math.Round(picturePoints[i].X / k);
                picturePoints[i].Y = (int)Math.Round(picturePoints[i].Y / k);
            }
            MakeAbsoluteCoordinates();
        }

        // ---------- Работа с координатами

        private void MakeRelativeCoordinates()
        {
            // Делает координаты точек относительными
            for (int i = 0; i != picturePoints.Length; i++)
            {
                picturePoints[i].X -= center.X;
                picturePoints[i].Y -= center.Y;
            }
        }

        private void MakeAbsoluteCoordinates()
        {
            // Делает абсолютные координаты
            for (int i = 0; i != picturePoints.Length; i++)
            {
                picturePoints[i].X += center.X;
                picturePoints[i].Y += center.Y;
            }
        }

        // ---------- Реализация работы кнопок на форме

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            switch (curAction)
            {
                case Action.Movement:
                    ChangePosition();
                    break;
                case Action.Turn:
                    FlipObject();
                    break;
                case Action.Resize:
                    ResizeObject();
                    break;
            }
            DrawFigure();
        }

        private void PlaceObjectButton_Click(object sender, EventArgs e)
        {
            centerPosition = !centerPosition;
            if (centerPosition)
            {
                placeObjectButton.Text = "По центру";
                placeObjectButton.BackColor = Color.FromArgb(0, 192, 0);
                placeObjectButton.ForeColor = Color.FromArgb(128, 255, 128);
            }
            else
            {
                placeObjectButton.Text = "Произвольное";
                placeObjectButton.BackColor = Color.FromArgb(192, 0, 0);
                placeObjectButton.ForeColor = Color.FromArgb(255, 128, 128);
            }
            ChangeBitmapSize(centerPosition);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && curAction != Action.None)
            {
                applyButton.PerformClick();
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(PointToScreen(e.Location));
            }
        }

        private void RestoreInitialObject_Click(object sender, EventArgs e)
        {
            center = new Point(pictureBox.Width / 2, pictureBox.Height / 2);
            picturePoints = [new(center.X - 100, center.Y - 200),
                             new(center.X + 100, center.Y - 200),
                             new(center.X + 200, center.Y),
                             new(center.X + 100, center.Y + 200),
                             new(center.X - 100, center.Y + 200),
                             new(center.X - 200, center.Y)];
            DrawFigure();
        }

        private void FillObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сделай проверку на то, что новый цвет не равен черному
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (colorDialog1.Color == Color.Black)
                {
                    MessageBox.Show("Нельзя выбрать цвет, совпадающий с цветом границ.");
                    return;
                }
                FillFigure(colorDialog1.Color);
            }
        }
    }
}
