using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Carlo
{
    public partial class Form1 : Form
    {
        public List<int> exceptions = new List<int>();
        public int[,] globalTab;
        public int lastNucleonsAmount = 0;        
        public int[,] globalEnergyTab;
        public int[,] globalBordersTab;
        public bool firstIteration = true;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();

            Bitmap DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = DrawArea;

            Bitmap DrawArea2 = new Bitmap(pictureBox2.Size.Width, pictureBox2.Size.Height);
            pictureBox2.Image = DrawArea;

            button1.Enabled = false;
            resetButton.Enabled = true;
            startSRXBtn.Enabled = false;
            selectBordersBTN.Enabled = false;
        }

        private void MonteCarloSimulation()
        {
           bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = bmp;

            int sizeX = int.Parse(sizexTextBox.Text);
            int sizeY = int.Parse(sizeyTextBox.Text);
            int numberOfIterations = int.Parse(numberOfIterationsTextBox.Text);
            int nucleonAmount = (int)nucleonsAmountNumericUpDown.Value;
            lastNucleonsAmount = nucleonAmount;

            //blokada maksymalnego rozmiaru macierzy
            #region
            if (sizeX > pictureBox1.Width)
            {
                sizeX = pictureBox1.Width;
                sizexTextBox.Text = sizeX.ToString();
            }

            if (sizeY > pictureBox1.Height)
            {
                sizeY = pictureBox1.Height;
                sizeyTextBox.Text = sizeY.ToString();
            }
            #endregion


            Random random = new Random();

            int[,] tabActual = new int[sizeX, sizeY];

            //wypelnianie tablicy randomowymi nukleonami
            for(int i = 0; i<sizeX; i++)
            {
                for(int j = 0; j<sizeY; j++)
                {                    
                    tabActual[i, j] = random.Next(1, nucleonAmount + 1);
                }
            }

            List<Color> colors = new List<Color>();
            for (int i = 0; i < nucleonAmount; i++)
            {
                colors.Add(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));                
            }

            //first colorize
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    bmp.SetPixel(i, j, colors[tabActual[i,j] - 1]);
                }
            }

            pictureBox1.Refresh();


            //wlasciwy algorytm
            bool[,] checkedTab = new bool[sizeX, sizeY];
            int checkCounter = 0;

            for(int x = 0; x < numberOfIterations; x++)
            {
                while (checkCounter < sizeX * sizeY)
                {
                    int dx = random.Next(0, sizeX);
                    int dy = random.Next(0, sizeY);

                    if (checkedTab[dx, dy])
                    {
                        continue;
                    }
                    else
                    {
                        checkedTab[dx, dy] = true;
                        checkCounter++;
                        MooreMC(dx, dy, tabActual, sizeX, sizeY, nucleonAmount, random);
                    }
                }

                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        bmp.SetPixel(i, j, colors[tabActual[i, j] - 1]);
                    }
                }
                pictureBox1.Refresh();
                checkCounter = 0;
                checkedTab = new bool[sizeX, sizeY];

            }

            globalTab = tabActual;
            lastNucleonsAmount = nucleonAmount;

        }

        private void MonteCarloSRX()
        {
            //Bitmap bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = bmp;

            int sizeX = int.Parse(sizexTextBox.Text);
            int sizeY = int.Parse(sizeyTextBox.Text);
            int numberOfIterations = int.Parse(srxIterationsTextbox.Text);
            int nucleonAmount = int.Parse(nucleonsOnStartTextbox.Text);
            int energyInside = int.Parse(energyInsideTextbox.Text);
            int energyOnEdges = int.Parse(energyOnEdgesTextbox.Text);
            int nucleationRate = int.Parse(NucleationRateTextbox.Text);
            int stopIterations = int.Parse(stopConditionTextbox.Text);
            int lastNucleonsAmountSRX = 0;



            //blokada maksymalnego rozmiaru macierzy
            #region
            if (sizeX > pictureBox1.Width)
            {
                sizeX = pictureBox1.Width;
                sizexTextBox.Text = sizeX.ToString();
            }

            if (sizeY > pictureBox1.Height)
            {
                sizeY = pictureBox1.Height;
                sizeyTextBox.Text = sizeY.ToString();
            }
            #endregion


            Random random = new Random();

            int[,] tabActual = new int[sizeX, sizeY];
            int[,] energyTab = new int[sizeX, sizeY];

            //tworzenie energii H
            #region
            SelectBorders();

            if(energyDistributionComboBox.SelectedItem.Equals("Homogenous"))
            {
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        globalEnergyTab[i, j] = energyInside;
                    }
                }
            }

            if(energyDistributionComboBox.SelectedItem.Equals("Heterogenous"))
            {
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        if (globalEnergyTab[i, j] == -1)
                        {
                            globalEnergyTab[i, j] = energyOnEdges;
                        }
                        if (globalEnergyTab[i, j] == 0)
                        {
                            globalEnergyTab[i, j] = energyInside;
                        }
                    }
                }
            }

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    energyTab[i,j] = globalEnergyTab[i, j];
                }
            }

            #endregion


            //utworzenie listy zawierajacej wspolrzedne granic
            List<Point> borders = new List<Point>();

            for(int i = 0; i<sizeX; i++)
            {
                for(int j = 0; j<sizeY; j++)
                {
                    if(globalBordersTab[i,j] == -1)
                    {
                        borders.Add(new Point(i,j));
                    }
                }
            }


            //przepisanie tablicy do SRX
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    tabActual[i, j] = globalTab[i,j];
                }
            }

            
            List<Color> colors = new List<Color>();


            //if(nucleationTypeCombobox.SelectedItem.Equals("Constant"))
            //{
            //    SRXNucleonsGeneratorSingle(nucleationRate, random, nucleonAmount, tabActual, sizeX, sizeY, colors, borders, lastNucleonsAmount);
            //}

            
            //wlasciwy algorytm
            for(int y = 0; y<stopIterations; y++)
            {
                //if (nucleationTypeCombobox.SelectedItem.Equals("Increasing"))
                //{
                //    SRXNucleonsGeneratorMultiConstant(nucleationRate, random, nucleonAmount, tabActual, sizeX, sizeY, colors, borders, lastNucleonsAmount);
                //}

                bool[,] checkedTab = new bool[sizeX, sizeY];
                int checkCounter = 0;

                for (int x = 0; x < numberOfIterations; x++)
                {
                    if (nucleationTypeCombobox.SelectedItem.Equals("Constant"))
                    {
                        SRXNucleonsGeneratorMultiConstant(nucleationRate, random, nucleonAmount, tabActual, sizeX, sizeY, colors, borders, ref lastNucleonsAmountSRX);
                    }

                    if (nucleationTypeCombobox.SelectedItem.Equals("Increasing"))
                    {
                        SRXNucleonsGeneratorMultiIncreasing(nucleationRate, random, nucleonAmount, tabActual, sizeX, sizeY, colors, borders, ref lastNucleonsAmountSRX, x);
                    }
                    while (checkCounter < sizeX * sizeY)
                    {
                        int dx = random.Next(0, sizeX);
                        int dy = random.Next(0, sizeY);

                        if (checkedTab[dx, dy])
                        {
                            continue;
                        }
                        else
                        {
                            checkedTab[dx, dy] = true;
                            checkCounter++;
                            MooreMCSRX(dx, dy, tabActual, sizeX, sizeY, nucleonAmount, random, globalEnergyTab);
                        }
                    }

                    for (int i = 0; i < sizeX; i++)
                    {
                        for (int j = 0; j < sizeY; j++)
                        {
                            if (tabActual[i, j] < 0)
                            {
                                bmp.SetPixel(i, j, colors[(tabActual[i, j] * -1) - 1]);
                            }
                        }
                    }
                    pictureBox1.Refresh();
                    checkCounter = 0;
                    checkedTab = new bool[sizeX, sizeY];

                }
            }
            
            firstIteration = true;
        }

        private void SRXNucleonsGeneratorMultiConstant(int nucleationRate, Random random, int nucleonAmount, int[,] tabActual, int sizeX, int sizeY, List<Color> colors, List<Point> borders, ref int lastNucleonsAmountSRX)
        {
            if(firstIteration)
            {
                //kolorki
                for (int i = 0; i < nucleonAmount; i++)
                {
                    int GBcolors = random.Next(0, 50);
                    colors.Add(Color.FromArgb(random.Next(100, 255), GBcolors, GBcolors));
                }

                //umieszczenie nukleonow
                for (int i = 1; i <= nucleonAmount; i++)
                {
                    if (nucleonsPlacementCombobox.SelectedItem.Equals("Anywhere"))
                    {
                        tabActual[random.Next(0, sizeX), random.Next(0, sizeY)] = i * (-1);
                    }
                    if (nucleonsPlacementCombobox.SelectedItem.Equals("Edges"))
                    {
                        Point randomPoint = borders[random.Next(0, borders.Count)];
                        tabActual[randomPoint.X, randomPoint.Y] = i * (-1);
                    }
                }

                lastNucleonsAmountSRX = nucleonAmount;
                firstIteration = false;
            }
            else
            {
                //kolorki
                for (int i = lastNucleonsAmountSRX; i < lastNucleonsAmountSRX + nucleationRate; i++)
                {
                    int GBcolors = random.Next(0, 50);
                    colors.Add(Color.FromArgb(random.Next(100, 255), GBcolors, GBcolors));
                }

                //umieszczenie nukleonow
                for (int i = lastNucleonsAmountSRX + 1; i <= lastNucleonsAmountSRX + nucleationRate; i++)
                {
                    if (nucleonsPlacementCombobox.SelectedItem.Equals("Anywhere"))
                    {
                        tabActual[random.Next(0, sizeX), random.Next(0, sizeY)] = i * (-1);
                    }
                    if (nucleonsPlacementCombobox.SelectedItem.Equals("Edges"))
                    {
                        Point randomPoint = borders[random.Next(0, borders.Count)];
                        tabActual[randomPoint.X, randomPoint.Y] = i * (-1);
                    }
                }

                lastNucleonsAmountSRX += nucleationRate;
            }
            
        }

        private void SRXNucleonsGeneratorMultiIncreasing(int nucleationRate, Random random, int nucleonAmount, int[,] tabActual, int sizeX, int sizeY, List<Color> colors, List<Point> borders, ref int lastNucleonsAmountSRX, int x)
        {
            if (firstIteration)
            {
                //kolorki
                for (int i = 0; i < nucleonAmount; i++)
                {
                    int GBcolors = random.Next(0, 50);
                    colors.Add(Color.FromArgb(random.Next(100, 255), GBcolors, GBcolors));
                }

                //umieszczenie nukleonow
                for (int i = 1; i <= nucleonAmount; i++)
                {
                    if (nucleonsPlacementCombobox.SelectedItem.Equals("Anywhere"))
                    {
                        tabActual[random.Next(0, sizeX), random.Next(0, sizeY)] = i * (-1);
                    }
                    if (nucleonsPlacementCombobox.SelectedItem.Equals("Edges"))
                    {
                        Point randomPoint = borders[random.Next(0, borders.Count)];
                        tabActual[randomPoint.X, randomPoint.Y] = i * (-1);
                    }
                }

                lastNucleonsAmountSRX = nucleonAmount;
                firstIteration = false;
            }
            else
            {
                //kolorki
                for (int i = lastNucleonsAmountSRX; i < lastNucleonsAmountSRX + nucleationRate * (x+1); i++)
                {
                    int GBcolors = random.Next(0, 50);
                    colors.Add(Color.FromArgb(random.Next(100, 255), GBcolors, GBcolors));
                }

                //umieszczenie nukleonow
                for (int i = lastNucleonsAmountSRX + 1; i <= lastNucleonsAmountSRX + nucleationRate * (x + 1); i++)
                {
                    if (nucleonsPlacementCombobox.SelectedItem.Equals("Anywhere"))
                    {
                        tabActual[random.Next(0, sizeX), random.Next(0, sizeY)] = i * (-1);
                    }
                    if (nucleonsPlacementCombobox.SelectedItem.Equals("Edges"))
                    {
                        Point randomPoint = borders[random.Next(0, borders.Count)];
                        tabActual[randomPoint.X, randomPoint.Y] = i * (-1);
                    }
                }

                lastNucleonsAmountSRX += nucleationRate * (x + 1);
            }

        }

        private void SRXNucleonsGeneratorSingle(int nucleationRate, Random random, int nucleonAmount, int[,] tabActual, int sizeX, int sizeY, List<Color> colors, List<Point> borders, int lastNucleonsAmountSRX)
        {
            //kolorki
            for (int i = 0; i < nucleonAmount; i++)
            {
                int GBcolors = random.Next(0, 50);
                colors.Add(Color.FromArgb(random.Next(100, 255), GBcolors, GBcolors));
            }

            //umieszczenie nukleonow
            for (int i = 1; i <= nucleonAmount; i++)
            {
                if (nucleonsPlacementCombobox.SelectedItem.Equals("Anywhere"))
                {
                    tabActual[random.Next(0, sizeX), random.Next(0, sizeY)] = i * (-1);
                }
                if (nucleonsPlacementCombobox.SelectedItem.Equals("Edges"))
                {
                    Point randomPoint = borders[random.Next(0, borders.Count)];
                    tabActual[randomPoint.X, randomPoint.Y] = i * (-1);
                }
            }
        }


        private void CellularAutomataSimulation()
        {

            int sizeX = int.Parse(sizexTextBox.Text);
            int sizeY = int.Parse(sizeyTextBox.Text);
            int probability = int.Parse(probabilityTextBox.Text);
            int nucleonAmount = (int)nucleonsAmountNumericUpDown.Value;
            lastNucleonsAmount = nucleonAmount;
            
            bool canGrowth = true;
            int canGrowthCounter = 0;
            int lastCanGrowthCounter = 0;
            int errorCounter = 0;
            exceptions.Add(-1);
            exceptions.Add(-2);


            bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = bmp;

            //blokada maksymalnego rozmiaru macierzy
            if (sizeX > pictureBox1.Width)
            {
                sizeX = pictureBox1.Width;
                sizexTextBox.Text = sizeX.ToString();
            }

            if (sizeY > pictureBox1.Height)
            {
                sizeY = pictureBox1.Height;
                sizeyTextBox.Text = sizeY.ToString();
            }

            //stworzenie macierzy aktualnej i z poprzedniego kroku
            int[,] tabActual = new int[sizeX, sizeY];
            int[,] tabLast = new int[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    tabActual[i, j] = 0;
                    tabLast[i, j] = 0;
                }
            }

            Random random = new Random();

            

            for (int i = 0; i < nucleonAmount; i++)
            {
                int randomPositionX;
                int randomPositionY;
                do
                {
                    randomPositionX = random.Next(0, sizeX);
                    randomPositionY = random.Next(0, sizeY);
                }
                while (tabActual[randomPositionX, randomPositionY] != 0 && tabLast[randomPositionX, randomPositionY] != 0);

                tabActual[randomPositionX, randomPositionY] = i + 1;
                tabLast[randomPositionX, randomPositionY] = i + 1;

            }

            //colorise
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (tabActual[i, j] == -1)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }

                }
            }

            pictureBox1.Refresh();



            List<Color> colors = new List<Color>();
            for (int i = 0; i < nucleonAmount; i++)
            {
                colors.Add(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));                
            }

            //growth main method
            while (canGrowth)
            {
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        //int tempValueLeft;
                        //int tempValueRight;
                        //int tempValueUp;
                        //int tempValueDown;

                        if (tabActual[i, j] == 0)
                        {
                            canGrowthCounter++;
                            if (!Moore(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount))
                            {
                                if (!VonNeumann(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount))
                                {
                                    if (!FurtherMoore(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount))
                                    {
                                        Probability(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount, random, probability);
                                        //MooreMax(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount);
                                    }
                                }
                            }




                            if (tabActual[i, j] > 0)
                            {
                                bmp.SetPixel(i, j, colors[tabActual[i, j] - 1]);
                            }


                        }
                    }


                }

                if (canGrowthCounter > 0)
                {
                    if (canGrowthCounter == lastCanGrowthCounter)
                    {
                        errorCounter++;
                        if (errorCounter > 50)
                        {
                            canGrowth = false;
                        }
                        canGrowthCounter = 0;
                    }
                    else
                    {
                        canGrowth = true;
                        lastCanGrowthCounter = canGrowthCounter;
                        canGrowthCounter = 0;
                        errorCounter = 0;
                    }

                }
                else
                {
                    canGrowth = false;
                    canGrowthCounter = 0;
                }

                pictureBox1.Refresh();



                //rewrite
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        tabLast[i, j] = tabActual[i, j];
                    }
                }
            }

            globalTab = tabActual;
            lastNucleonsAmount = nucleonAmount;
        }

        private void MonteCarloSimulationDP()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = bmp;

            int sizeX = int.Parse(sizexTextBox.Text);
            int sizeY = int.Parse(sizeyTextBox.Text);
            int numberOfIterations = int.Parse(numberOfIterationsTextBox.Text);
            int nucleonAmount = (int)nucleonsAmountNumericUpDown.Value;
            

            int nucleonsToDualPhase = (int)nucleonsToDualPhaseNumericUpDown.Value;
            Random random = new Random();            

            //blokada maksymalnego rozmiaru macierzy
            #region
            if (sizeX > pictureBox1.Width)
            {
                sizeX = pictureBox1.Width;
                sizexTextBox.Text = sizeX.ToString();
            }

            if (sizeY > pictureBox1.Height)
            {
                sizeY = pictureBox1.Height;
                sizeyTextBox.Text = sizeY.ToString();
            }
            #endregion

           

            

            int[,] tabActual = new int[sizeX, sizeY];

            for (int i = 0; i < nucleonsToDualPhase; i++)
            {
                exceptions.Add(random.Next(1, lastNucleonsAmount + 1));
            }

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    foreach(var v in exceptions)
                    {
                        if(v == globalTab[i,j])
                        {
                            tabActual[i, j] = -1;                            
                        }
                    }
                }
            }

            //wypelnianie tablicy randomowymi nukleonami
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if(tabActual[i,j] != -1)
                    {
                        tabActual[i, j] = random.Next(1, nucleonAmount + 1);
                    }
                }
            }

            List<Color> colors = new List<Color>();
            for (int i = 0; i < nucleonAmount; i++)
            {
                colors.Add(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
            }

            //first colorize
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if(tabActual[i,j] == -1)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        bmp.SetPixel(i, j, colors[tabActual[i, j] - 1]);
                    }
                }
            }

            pictureBox1.Refresh();


            //wlasciwy algorytm
            bool[,] checkedTab = new bool[sizeX, sizeY];
            int checkCounter = 0;

            for (int x = 0; x < numberOfIterations; x++)
            {
                while (checkCounter < (sizeX * sizeY))
                {
                    int dx = random.Next(0, sizeX);
                    int dy = random.Next(0, sizeY);

                    if (checkedTab[dx, dy])
                    {
                        continue;
                    }
                    else
                    {
                        if(tabActual[dx,dy] == -1)
                        {
                            checkedTab[dx, dy] = true;
                            checkCounter++;                            
                        }
                        else
                        {
                            checkedTab[dx, dy] = true;
                            checkCounter++;
                            MooreMC(dx, dy, tabActual, sizeX, sizeY, nucleonAmount, random);
                        }
                    }
                }

                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        if(tabActual[i,j] == -1)
                        {
                            bmp.SetPixel(i, j, Color.Black);
                        }
                        else
                        {
                            bmp.SetPixel(i, j, colors[tabActual[i, j] - 1]);
                        }
                    }
                }
                pictureBox1.Refresh();
                checkCounter = 0;
                checkedTab = new bool[sizeX, sizeY];

            }



        }

        private void CellularAutomataSimulationDP()
        {

            int sizeX = int.Parse(sizexTextBox.Text);
            int sizeY = int.Parse(sizeyTextBox.Text);
            int probability = int.Parse(probabilityTextBox.Text);
            int nucleonAmount = (int)nucleonsAmountNumericUpDown.Value;
            int nucleonsToDualPhase = (int)nucleonsToDualPhaseNumericUpDown.Value;

            bool canGrowth = true;
            int canGrowthCounter = 0;
            int lastCanGrowthCounter = 0;
            int errorCounter = 0;
            exceptions.Add(-1);
            exceptions.Add(-2);

            Random random = new Random();

            Bitmap bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = bmp;

            //blokada maksymalnego rozmiaru macierzy
            if (sizeX > pictureBox1.Width)
            {
                sizeX = pictureBox1.Width;
                sizexTextBox.Text = sizeX.ToString();
            }

            if (sizeY > pictureBox1.Height)
            {
                sizeY = pictureBox1.Height;
                sizeyTextBox.Text = sizeY.ToString();
            }

            //stworzenie macierzy aktualnej i z poprzedniego kroku
            int[,] tabActual = new int[sizeX, sizeY];
            int[,] tabLast = new int[sizeX, sizeY];

            for (int i = 0; i < nucleonsToDualPhase; i++)
            {
                exceptions.Add(random.Next(1, lastNucleonsAmount + 1));
            }

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    foreach (var v in exceptions)
                    {
                        if (v == globalTab[i, j])
                        {
                            tabActual[i, j] = -1;
                            tabLast[i, j] = -1;
                        }
                    }
                }
            }

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if(tabActual[i,j] != -1)
                    {
                        tabActual[i, j] = 0;
                        tabLast[i, j] = 0;
                    }
                }
            }           



            for (int i = 0; i < nucleonAmount; i++)
            {
                int randomPositionX;
                int randomPositionY;
                do
                {
                    randomPositionX = random.Next(0, sizeX);
                    randomPositionY = random.Next(0, sizeY);
                }
                while (tabActual[randomPositionX, randomPositionY] != 0 && tabLast[randomPositionX, randomPositionY] != 0);

                tabActual[randomPositionX, randomPositionY] = i + 1;
                tabLast[randomPositionX, randomPositionY] = i + 1;

            }

            //colorise
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (tabActual[i, j] == -1)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }

                }
            }

            pictureBox1.Refresh();



            List<Color> colors = new List<Color>();
            for (int i = 0; i < nucleonAmount; i++)
            {
                colors.Add(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
            }

            //growth main method
            while (canGrowth)
            {
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        //int tempValueLeft;
                        //int tempValueRight;
                        //int tempValueUp;
                        //int tempValueDown;

                        if (tabActual[i, j] == 0)
                        {
                            canGrowthCounter++;
                            if (!Moore(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount))
                            {
                                if (!VonNeumann(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount))
                                {
                                    if (!FurtherMoore(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount))
                                    {
                                        Probability(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount, random, probability);
                                        //MooreMax(i, j, tabActual, tabLast, sizeX, sizeY, nucleonAmount);
                                    }
                                }
                            }




                            if (tabActual[i, j] > 0)
                            {
                                bmp.SetPixel(i, j, colors[tabActual[i, j] - 1]);
                            }


                        }
                    }


                }

                if (canGrowthCounter > 0)
                {
                    if (canGrowthCounter == lastCanGrowthCounter)
                    {
                        errorCounter++;
                        if (errorCounter > 50)
                        {
                            canGrowth = false;
                        }
                        canGrowthCounter = 0;
                    }
                    else
                    {
                        canGrowth = true;
                        lastCanGrowthCounter = canGrowthCounter;
                        canGrowthCounter = 0;
                        errorCounter = 0;
                    }

                }
                else
                {
                    canGrowth = false;
                    canGrowthCounter = 0;
                }

                pictureBox1.Refresh();



                //rewrite
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        tabLast[i, j] = tabActual[i, j];
                    }
                }
            }


        }

        private void DualPhaseSimulation()
        {
            if(CARadioButton.Checked)
            {
                CellularAutomataSimulationDP();
            }

            if(MCRadioButton.Checked)
            {
                MonteCarloSimulationDP();
            }
        }

        private void MooreMC(int i, int j, int[,] tabActual, int sizeX, int sizeY, int nucleonsAmount, Random rand)
        {
            List<int> neighbors = new List<int>();

            //check left
            if (i != 0 && tabActual[i - 1, j] != -1)
            {
                neighbors.Add(tabActual[i - 1, j]);
            }
            //check left up
            if (i != 0 && j != 0 && tabActual[i - 1, j - 1] != -1)
            {
                neighbors.Add(tabActual[i - 1, j - 1]);
            }
            //check left down
            if (i != 0 && j != sizeY - 1 && tabActual[i - 1, j + 1] != -1)
            {
                neighbors.Add(tabActual[i - 1, j + 1]);
            }
            //check right
            if (i != sizeX - 1 && tabActual[i + 1, j] != -1)
            {
                neighbors.Add(tabActual[i + 1, j]);
            }
            //check right up
            if (i != sizeX - 1 && j != 0 && tabActual[i + 1, j - 1] != -1)
            {
                neighbors.Add(tabActual[i + 1, j - 1]);
            }
            //check right down
            if (i != sizeX - 1 && j != sizeY - 1 && tabActual[i + 1, j + 1] != -1)
            {
                neighbors.Add(tabActual[i + 1, j + 1]);
            }
            //check up
            if (j != 0 && tabActual[i, j - 1] != -1)
            {
                neighbors.Add(tabActual[i, j - 1]);
            }
            //check down
            if (j != sizeY - 1 && tabActual[i, j + 1] != -1)
            {
                neighbors.Add(tabActual[i, j + 1]);
            }

            int energyAfter = 0;
            int energyBefore = 0;

            foreach (var v in neighbors)
            {
                if (tabActual[i, j] != v)
                {
                    energyBefore++;
                }
            }

            if (neighbors.Count != 0)
            {
                int randomID = neighbors[rand.Next(0, neighbors.Count)];
                foreach (var v in neighbors)
                {
                    if (randomID != v)
                    {
                        energyAfter++;
                    }
                }

                if (energyAfter <= energyBefore)
                {
                    tabActual[i, j] = randomID;
                }
            }

        }


        private void MooreMCSRX(int i, int j, int[,] tabActual, int sizeX, int sizeY, int nucleonsAmount, Random rand, int[,] energyTab)
        {
            List<int> neighbors = new List<int>();
            int iCoordinates = 0;
            int jCoordinates = 0;

            //check left -> index 0
            if (i != 0)
            {
                neighbors.Add(tabActual[i - 1, j]);
            }
            //check left up -> index 1
            if (i != 0 && j != 0 )
            {
                neighbors.Add(tabActual[i - 1, j - 1]);
            }
            //check left down -> index 2
            if (i != 0 && j != sizeY - 1 )
            {
                neighbors.Add(tabActual[i - 1, j + 1]);
            }
            //check right -> index 3
            if (i != sizeX - 1 )
            {
                neighbors.Add(tabActual[i + 1, j]);
            }
            //check right up -> index 4
            if (i != sizeX - 1 && j != 0 )
            {
                neighbors.Add(tabActual[i + 1, j - 1]);
            }
            //check right down -> index 5
            if (i != sizeX - 1 && j != sizeY - 1 )
            {
                neighbors.Add(tabActual[i + 1, j + 1]);
            }
            //check up -> index 6
            if (j != 0 )
            {
                neighbors.Add(tabActual[i, j - 1]);
            }
            //check down -> index 7
            if (j != sizeY - 1 )
            {
                neighbors.Add(tabActual[i, j + 1]);
            }           

            int energyAfter = 0;
            int energyBefore = 0;

            foreach(var v in neighbors)
            {
                if(tabActual[i,j] != v)
                {
                    energyBefore++;
                }
            }
            energyBefore = energyBefore + energyTab[i, j];            
            

            if (neighbors.Count != 0)
            {
                int randomID = rand.Next(0, neighbors.Count);
                int selectedNeighbor = neighbors[randomID];

                //find neighbor coordinates
                #region
                if(randomID == 0)
                {
                    iCoordinates = i - 1;
                    jCoordinates = j;
                }
                if (randomID == 1)
                {
                    iCoordinates = i - 1;
                    jCoordinates = j - 1;
                }
                if (randomID == 2)
                {
                    iCoordinates = i - 1;
                    jCoordinates = j + 1;
                }
                if (randomID == 3)
                {
                    iCoordinates = i + 1;
                    jCoordinates = j;
                }
                if (randomID == 4)
                {
                    iCoordinates = i + 1;
                    jCoordinates = j - 1;
                }
                if (randomID == 5)
                {
                    iCoordinates = i + 1;
                    jCoordinates = j + 1;
                }
                if (randomID == 6)
                {
                    iCoordinates = i;
                    jCoordinates = j - 1;
                }
                if (randomID == 7)
                {
                    iCoordinates = i;
                    jCoordinates = j + 1;
                }

                #endregion

                if(selectedNeighbor < 0)
                {
                    foreach (var v in neighbors)
                    {
                        if (selectedNeighbor != v)
                        {                            
                            energyAfter++;
                        }
                    }

                    if (energyAfter <= energyBefore)
                    {
                        tabActual[i, j] = selectedNeighbor;
                        energyTab[i, j] = 0;
                    }
                }
                
            }            

        }

        private bool VonNeumann(int i, int j, int[,] tabActual, int[,] tabLast, int sizeX, int sizeY, int nucleonsAmount)
        {
            List<int> neighbors = new List<int>();

            //check left
            if (i != 0)
            {
                if (tabLast[i - 1, j] != 0 && !exceptions.Contains(tabLast[i - 1, j]))
                {
                    neighbors.Add(tabLast[i - 1, j]);
                }
            }
            //check right
            if (i != sizeX - 1)
            {
                if (tabLast[i + 1, j] != 0 && !exceptions.Contains(tabLast[i + 1, j]))
                {
                    neighbors.Add(tabLast[i + 1, j]);
                }
            }
            //check up
            if (j != 0)
            {
                if (tabLast[i, j - 1] != 0 && !exceptions.Contains(tabLast[i, j - 1]))
                {
                    neighbors.Add(tabLast[i, j - 1]);
                }
            }
            //check down
            if (j != sizeY - 1)
            {
                if (tabLast[i, j + 1] != 0 && !exceptions.Contains(tabLast[i, j + 1]))
                {
                    neighbors.Add(tabLast[i, j + 1]);
                }
            }

            //rule 2
            int counter = 0;
            if (neighbors.Count > 0)
            {
                for (int x = 0; x < nucleonsAmount; x++)
                {
                    foreach (var v in neighbors)
                    {
                        if (v == x + 1)
                        {
                            counter++;
                        }
                    }
                    if (counter >= 5)
                    {
                        tabActual[i, j] = x + 1;
                        counter = 0;
                        return true;
                    }
                    else
                    {
                        counter = 0;
                    }

                }
            }
            return false;

            //if (neighbors.Count > 0)
            //{
            //    tabActual[i, j] = neighbors.Max();
            //}
        }
        private bool Moore(int i, int j, int[,] tabActual, int[,] tabLast, int sizeX, int sizeY, int nucleonsAmount)
        {
            List<int> neighbors = new List<int>();

            //check left
            if (i != 0)
            {
                if (tabLast[i - 1, j] != 0 && !exceptions.Contains(tabLast[i - 1, j]))
                {
                    neighbors.Add(tabLast[i - 1, j]);
                }
            }
            //check left up
            if (i != 0 && j != 0)
            {
                if (tabLast[i - 1, j - 1] != 0 && !exceptions.Contains(tabLast[i - 1, j - 1]))
                {
                    neighbors.Add(tabLast[i - 1, j - 1]);
                }
            }
            //check left down
            if (i != 0 && j != sizeY - 1)
            {
                if (tabLast[i - 1, j + 1] != 0 && !exceptions.Contains(tabLast[i - 1, j + 1]))
                {
                    neighbors.Add(tabLast[i - 1, j + 1]);
                }
            }
            //check right
            if (i != sizeX - 1)
            {
                if (tabLast[i + 1, j] != 0 && !exceptions.Contains(tabLast[i + 1, j]))
                {
                    neighbors.Add(tabLast[i + 1, j]);
                }
            }
            //check right up
            if (i != sizeX - 1 && j != 0)
            {
                if (tabLast[i + 1, j - 1] != 0 && !exceptions.Contains(tabLast[i + 1, j - 1]))
                {
                    neighbors.Add(tabLast[i + 1, j - 1]);
                }
            }
            //check right down
            if (i != sizeX - 1 && j != sizeY - 1)
            {
                if (tabLast[i + 1, j + 1] != 0 && !exceptions.Contains(tabLast[i + 1, j + 1]))
                {
                    neighbors.Add(tabLast[i + 1, j + 1]);
                }
            }
            //check up
            if (j != 0)
            {
                if (tabLast[i, j - 1] != 0 && !exceptions.Contains(tabLast[i, j - 1]))
                {
                    neighbors.Add(tabLast[i, j - 1]);
                }
            }
            //check down
            if (j != sizeY - 1)
            {
                if (tabLast[i, j + 1] != 0 && !exceptions.Contains(tabLast[i, j + 1]))
                {
                    neighbors.Add(tabLast[i, j + 1]);
                }
            }

            //rule 1
            int counter = 0;
            if (neighbors.Count > 0)
            {
                for (int x = 0; x < nucleonsAmount; x++)
                {
                    foreach (var v in neighbors)
                    {
                        if (v == x + 1)
                        {
                            counter++;
                        }
                    }
                    if (counter >= 3)
                    {
                        tabActual[i, j] = x + 1;
                        counter = 0;
                        return true;
                    }
                    else
                    {
                        counter = 0;
                    }

                }
            }
            return false;
            //if (neighbors.Count > 0)
            //{
            //    tabActual[i, j] = neighbors.Max();
            //}
        }
        private bool FurtherMoore(int i, int j, int[,] tabActual, int[,] tabLast, int sizeX, int sizeY, int nucleonsAmount)
        {
            List<int> neighbors = new List<int>();


            //check left up
            if (i != 0 && j != 0)
            {
                if (tabLast[i - 1, j - 1] != 0 && !exceptions.Contains(tabLast[i - 1, j - 1]))
                {
                    neighbors.Add(tabLast[i - 1, j - 1]);
                }
            }
            //check left down
            if (i != 0 && j != sizeY - 1)
            {
                if (tabLast[i - 1, j + 1] != 0 && !exceptions.Contains(tabLast[i - 1, j + 1]))
                {
                    neighbors.Add(tabLast[i - 1, j + 1]);
                }
            }
            //check right up
            if (i != sizeX - 1 && j != 0)
            {
                if (tabLast[i + 1, j - 1] != 0 && !exceptions.Contains(tabLast[i + 1, j - 1]))
                {
                    neighbors.Add(tabLast[i + 1, j - 1]);
                }
            }
            //check right down
            if (i != sizeX - 1 && j != sizeY - 1)
            {
                if (tabLast[i + 1, j + 1] != 0 && !exceptions.Contains(tabLast[i + 1, j + 1]))
                {
                    neighbors.Add(tabLast[i + 1, j + 1]);
                }
            }

            //rule 3
            int counter = 0;
            if (neighbors.Count > 0)
            {
                for (int x = 0; x < nucleonsAmount; x++)
                {
                    foreach (var v in neighbors)
                    {
                        if (v == x + 1)
                        {
                            counter++;
                        }
                    }
                    if (counter >= 3)
                    {
                        tabActual[i, j] = x + 1;
                        counter = 0;
                        return true;
                    }
                    else
                    {
                        counter = 0;
                    }

                }
            }
            return false;
            //if (neighbors.Count > 0)
            //{
            //    tabActual[i, j] = neighbors.Max();
            //}
        }
        private void MooreMax(int i, int j, int[,] tabActual, int[,] tabLast, int sizeX, int sizeY, int nucleonsAmount)
        {
            List<int> neighbors = new List<int>();

            //check left
            if (i != 0)
            {
                if (tabLast[i - 1, j] != 0 && !exceptions.Contains(tabLast[i - 1, j]))
                {
                    neighbors.Add(tabLast[i - 1, j]);
                }
            }
            //check left up
            if (i != 0 && j != 0)
            {
                if (tabLast[i - 1, j - 1] != 0 && !exceptions.Contains(tabLast[i - 1, j - 1]))
                {
                    neighbors.Add(tabLast[i - 1, j - 1]);
                }
            }
            //check left down
            if (i != 0 && j != sizeY - 1)
            {
                if (tabLast[i - 1, j + 1] != 0 && !exceptions.Contains(tabLast[i - 1, j + 1]))
                {
                    neighbors.Add(tabLast[i - 1, j + 1]);
                }
            }
            //check right
            if (i != sizeX - 1)
            {
                if (tabLast[i + 1, j] != 0 && !exceptions.Contains(tabLast[i + 1, j]))
                {
                    neighbors.Add(tabLast[i + 1, j]);
                }
            }
            //check right up
            if (i != sizeX - 1 && j != 0)
            {
                if (tabLast[i + 1, j - 1] != 0 && !exceptions.Contains(tabLast[i + 1, j - 1]))
                {
                    neighbors.Add(tabLast[i + 1, j - 1]);
                }
            }
            //check right down
            if (i != sizeX - 1 && j != sizeY - 1)
            {
                if (tabLast[i + 1, j + 1] != 0 && !exceptions.Contains(tabLast[i + 1, j + 1]))
                {
                    neighbors.Add(tabLast[i + 1, j + 1]);
                }
            }
            //check up
            if (j != 0)
            {
                if (tabLast[i, j - 1] != 0 && !exceptions.Contains(tabLast[i, j - 1]))
                {
                    neighbors.Add(tabLast[i, j - 1]);
                }
            }
            //check down
            if (j != sizeY - 1)
            {
                if (tabLast[i, j + 1] != 0 && !exceptions.Contains(tabLast[i, j + 1]))
                {
                    neighbors.Add(tabLast[i, j + 1]);
                }
            }


            if (neighbors.Count > 0)
            {
                tabActual[i, j] = neighbors.Max();
            }
        }
        private void FurtherMooreMax(int i, int j, int[,] tabActual, int[,] tabLast, int sizeX, int sizeY, int nucleonsAmount)
        {
            List<int> neighbors = new List<int>();


            //check left up
            if (i != 0 && j != 0)
            {
                if (tabLast[i - 1, j - 1] != 0 && !exceptions.Contains(tabLast[i - 1, j - 1]))
                {
                    neighbors.Add(tabLast[i - 1, j - 1]);
                }
            }
            //check left down
            if (i != 0 && j != sizeY - 1)
            {
                if (tabLast[i - 1, j + 1] != 0 && !exceptions.Contains(tabLast[i - 1, j + 1]))
                {
                    neighbors.Add(tabLast[i - 1, j + 1]);
                }
            }
            //check right up
            if (i != sizeX - 1 && j != 0)
            {
                if (tabLast[i + 1, j - 1] != 0 && !exceptions.Contains(tabLast[i + 1, j - 1]))
                {
                    neighbors.Add(tabLast[i + 1, j - 1]);
                }
            }
            //check right down
            if (i != sizeX - 1 && j != sizeY - 1)
            {
                if (tabLast[i + 1, j + 1] != 0 && !exceptions.Contains(tabLast[i + 1, j + 1]))
                {
                    neighbors.Add(tabLast[i + 1, j + 1]);
                }
            }


            if (neighbors.Count > 0)
            {
                tabActual[i, j] = neighbors.Max();
            }
        }
        private void VonNeumannMax(int i, int j, int[,] tabActual, int[,] tabLast, int sizeX, int sizeY, int nucleonsAmount)
        {
            List<int> neighbors = new List<int>();

            //check left
            if (i != 0)
            {
                if (tabLast[i - 1, j] != 0 && !exceptions.Contains(tabLast[i - 1, j]))
                {
                    neighbors.Add(tabLast[i - 1, j]);
                }
            }
            //check right
            if (i != sizeX - 1)
            {
                if (tabLast[i + 1, j] != 0 && !exceptions.Contains(tabLast[i + 1, j]))
                {
                    neighbors.Add(tabLast[i + 1, j]);
                }
            }
            //check up
            if (j != 0)
            {
                if (tabLast[i, j - 1] != 0 && !exceptions.Contains(tabLast[i, j - 1]))
                {
                    neighbors.Add(tabLast[i, j - 1]);
                }
            }
            //check down
            if (j != sizeY - 1)
            {
                if (tabLast[i, j + 1] != 0 && !exceptions.Contains(tabLast[i, j + 1]))
                {
                    neighbors.Add(tabLast[i, j + 1]);
                }
            }

            if (neighbors.Count > 0)
            {
                tabActual[i, j] = neighbors.Max();
            }
        }
        private void Probability(int i, int j, int[,] tabActual, int[,] tabLast, int sizeX, int sizeY, int nucleonsAmount, Random random, int probability)
        {
            List<int> neighbors = new List<int>();
            int randomNumber = 0;

            //check left
            if (i != 0)
            {
                if (tabLast[i - 1, j] != 0 && !exceptions.Contains(tabLast[i - 1, j]))
                {
                    neighbors.Add(tabLast[i - 1, j]);
                }
            }
            //check left up
            if (i != 0 && j != 0)
            {
                if (tabLast[i - 1, j - 1] != 0 && !exceptions.Contains(tabLast[i - 1, j - 1]))
                {
                    neighbors.Add(tabLast[i - 1, j - 1]);
                }
            }
            //check left down
            if (i != 0 && j != sizeY - 1)
            {
                if (tabLast[i - 1, j + 1] != 0 && !exceptions.Contains(tabLast[i - 1, j + 1]))
                {
                    neighbors.Add(tabLast[i - 1, j + 1]);
                }
            }
            //check right
            if (i != sizeX - 1)
            {
                if (tabLast[i + 1, j] != 0 && !exceptions.Contains(tabLast[i + 1, j]))
                {
                    neighbors.Add(tabLast[i + 1, j]);
                }
            }
            //check right up
            if (i != sizeX - 1 && j != 0)
            {
                if (tabLast[i + 1, j - 1] != 0 && !exceptions.Contains(tabLast[i + 1, j - 1]))
                {
                    neighbors.Add(tabLast[i + 1, j - 1]);
                }
            }
            //check right down
            if (i != sizeX - 1 && j != sizeY - 1)
            {
                if (tabLast[i + 1, j + 1] != 0 && !exceptions.Contains(tabLast[i + 1, j + 1]))
                {
                    neighbors.Add(tabLast[i + 1, j + 1]);
                }
            }
            //check up
            if (j != 0)
            {
                if (tabLast[i, j - 1] != 0 && !exceptions.Contains(tabLast[i, j - 1]))
                {
                    neighbors.Add(tabLast[i, j - 1]);
                }
            }
            //check down
            if (j != sizeY - 1)
            {
                if (tabLast[i, j + 1] != 0 && !exceptions.Contains(tabLast[i, j + 1]))
                {
                    neighbors.Add(tabLast[i, j + 1]);
                }
            }

            randomNumber = random.Next(0, 101);
            if (randomNumber <= probability)
            {
                if (neighbors.Count > 0)
                {
                    tabActual[i, j] = neighbors.Max();
                }
            }
        }
        private void SelectBorders()
        {
            int sizeX = int.Parse(sizexTextBox.Text);
            int sizeY = int.Parse(sizeyTextBox.Text);

            Bitmap bmp = new Bitmap(pictureBox2.Size.Width, pictureBox2.Size.Height);
            pictureBox2.Image = bmp;

            

            Random random = new Random(); 

            int[,] tabActual = new int[sizeX, sizeY];
            int[,] tabLast = new int[sizeX, sizeY];
            int[,] tabBorders = new int[sizeX, sizeY];
            int[,] tabLastBorders = new int[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    tabActual[i, j] = globalTab[i, j];
                    tabLast[i, j] = globalTab[i, j];
                    tabBorders[i, j] = 0;
                    tabLastBorders[i, j] = 0;
                }
            }


            for (int i = 0; i < sizeX; i++) //first iteration
            {
                for (int j = 0; j < sizeY; j++)
                {
                    BorderCheckup(i, j, tabActual, tabLast, tabBorders, sizeX, sizeY);
                }
            }

            for (int i = 0; i < sizeX; i++) //first rewrite
            {
                for (int j = 0; j < sizeY; j++)
                {
                    tabLastBorders[i, j] = tabBorders[i, j];
                }
            }            

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (tabBorders[i, j] == -1)
                    {
                        bmp.SetPixel(i, j, Color.Yellow);
                    }

                    if (tabBorders[i, j] == 0)
                    {
                        bmp.SetPixel(i, j, Color.Blue);
                    }
                }
            }

            pictureBox1.Refresh();
            globalEnergyTab = tabBorders;

            globalBordersTab = new int[sizeX, sizeY];
            for(int i = 0; i<sizeX; i++)
            {
                for(int j = 0; j<sizeY; j++)
                {
                    globalBordersTab[i, j] = tabBorders[i, j];
                }
            }



        }
        private void BorderCheckup(int i, int j, int[,] tabActual, int[,] tabLast, int[,] tabBorders, int sizeX, int sizeY)
        {

            //check left
            if (i != 0)
            {
                if (tabLast[i - 1, j] != tabActual[i, j])
                {
                    tabBorders[i, j] = -1;
                }
            }
            //check left up
            if (i != 0 && j != 0)
            {
                if (tabLast[i - 1, j - 1] != tabActual[i, j])
                {
                    tabBorders[i, j] = -1;
                }
            }
            //check left down
            if (i != 0 && j != sizeY - 1)
            {
                if (tabLast[i - 1, j + 1] != tabActual[i, j])
                {
                    tabBorders[i, j] = -1;
                }
            }
            //check right
            if (i != sizeX - 1)
            {
                if (tabLast[i + 1, j] != tabActual[i, j])
                {
                    tabBorders[i, j] = -1;
                }
            }
            //check right up
            if (i != sizeX - 1 && j != 0)
            {
                if (tabLast[i + 1, j - 1] != tabActual[i, j])
                {
                    tabBorders[i, j] = -1;
                }
            }
            //check right down
            if (i != sizeX - 1 && j != sizeY - 1)
            {
                if (tabLast[i + 1, j + 1] != tabActual[i, j])
                {
                    tabBorders[i, j] = -1;
                }
            }
            //check up
            if (j != 0)
            {
                if (tabLast[i, j - 1] != tabActual[i, j])
                {
                    tabBorders[i, j] = -1;
                }
            }
            //check down
            if (j != sizeY - 1)
            {
                if (tabLast[i, j + 1] != tabActual[i, j])
                {
                    tabBorders[i, j] = -1;
                }
            }

        }



        private void Reset()
        {
            for(int i = 0; i<globalTab.GetLength(0); i++)
            {
                for(int j = 0; j<globalTab.GetLength(1); j++)
                {
                    globalTab[i, j] = 0;
                }
            }

            exceptions.Clear();
            lastNucleonsAmount = 0;
        }


        private void startButton_Click(object sender, EventArgs e)
        {            
            startCAButton.Enabled = false;            
            MonteCarloSimulation();
            startSRXBtn.Enabled = true;
            button1.Enabled = true;
            selectBordersBTN.Enabled = true;
        }

        private void startCAButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            CellularAutomataSimulation();
            startSRXBtn.Enabled = true;
            button1.Enabled = true;
            selectBordersBTN.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            startButton.Enabled = false;
            startCAButton.Enabled = false;
            startSRXBtn.Enabled = false;
            DualPhaseSimulation();   
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            selectBordersBTN.Enabled = false;
            startSRXBtn.Enabled = false;
            Reset();
            startButton.Enabled = true;
            startCAButton.Enabled = true;
        }

        private void selectBordersBTN_Click(object sender, EventArgs e)
        {
            SelectBorders();
            selectBordersBTN.Enabled = false;
        }

        private void startSRXBtn_Click(object sender, EventArgs e)
        {
            firstIteration = true;
            MonteCarloSRX();
            startSRXBtn.Enabled = false;
            button1.Enabled = false;
            startCAButton.Enabled = false;
            startButton.Enabled = false;
        }
    }
}
