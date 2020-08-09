using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_C_2048_Yogurtcry_20200806
{
    public partial class FrmMain : Form
    {
        private static List<List<Label>> LABELARRAY;

        BackgroundWorker BACKGROUNDWORKERLABELMOVE0 = null;
        BackgroundWorker BACKGROUNDWORKERLABELMOVE1 = null;
        BackgroundWorker BACKGROUNDWORKERLABELMOVE2 = null;
        BackgroundWorker BACKGROUNDWORKERLABELMOVE3 = null;

        private static int KEYBOARDSTATE0 = 0;
        private static int KEYBOARDSTATE1 = 0;
        private static int KEYBOARDSTATE2 = 0;
        private static int KEYBOARDSTATE3 = 0;
        private static int KEYBOARDSTATEFULL = 0;

        BackgroundWorker BACKGROUNDWORKERLABELNEWNUMBER = null;

        public FrmMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);  // 禁止擦除背景.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲
            this.UpdateStyles();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LABELARRAY = new List<List<Label>> {
                new List<Label> { lbl00, lbl01, lbl02, lbl03 },
                new List<Label> { lbl10, lbl11, lbl12, lbl13 },
                new List<Label> { lbl20, lbl21, lbl22, lbl23 },
                new List<Label> { lbl30, lbl31, lbl32, lbl33 }
            };

            List<List<int>> calculateArray = new List<List<int>>
            {
                new List<int>{ 0, 0, 0, 0 },
                new List<int>{ 0, 0, 0, 0 },
                new List<int>{ 0, 0, 0, 0 },
                new List<int>{ 0, 0, 0, 0 }
            };

            RefleshCalculate(calculateArray);
        }

        #region 刷新计算
        /// <summary>
        /// 刷新计算
        /// </summary>
        /// <param name="calculateArray"></param>
        private void RefleshCalculate(List<List<int>> calculateArray)
        {
            int score = 0;                  // 分数
            int maxNumber = 0;              // 最大值
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 4; columnIndex++)
                {
                    Label labelItem = LABELARRAY[rowIndex][columnIndex];
                    string calculateNumber = calculateArray[rowIndex][columnIndex].ToString();
                    // 计算分数
                    score += int.Parse(calculateNumber);
                    // 计算最大分值
                    if (int.Parse(calculateNumber) > maxNumber)
                    {
                        maxNumber = int.Parse(calculateNumber);
                    }
                    // 渲染颜色
                    Dictionary<string, object> labelStyle = ClassCalculate.GetNumberLabelStyle(int.Parse(calculateNumber));
                    labelItem.Font = (Font)labelStyle["font"];
                    labelItem.BackColor = (Color)labelStyle["backColor"];
                    labelItem.ForeColor = (Color)labelStyle["foreColor"];

                    // 输出结果
                    labelItem.Text = calculateNumber;
                }
            }
            // 分值
            lblGameScore.Text = (score * maxNumber).ToString();
            // lblMaxNumber.Text = maxNumber.ToString();
        }
        #endregion

        #region 方法 - 随机生成 2 或 4
        /// <summary>
        /// 随机生成 2 或 4
        /// </summary>
        private List<List<int>> RandomNewNumberTwoOrFour()
        {
            Random random = new Random();
            List<List<int>> currentLabelNumberArray = GetCurrentLabelNumberArray();
            List<int> locationList = GetNotUseLocationList();
            int locationListCount = locationList.Count;
            if (locationListCount > 0)
            {
                int locationNumber = locationList[random.Next(0, locationListCount)];
                int rowIndex = (int)(locationNumber / 10);
                int columnIndex = locationNumber - (rowIndex * 10);
                int randomNumber = 0;
                switch (random.Next(0, 99) % 2)
                {
                    case 0:
                        randomNumber = 2;
                        break;
                    case 1:
                        randomNumber = 4;
                        break;
                }
                currentLabelNumberArray[rowIndex][columnIndex] = randomNumber;
                //labelArray[rowIndex][columnIndex].Text = randomNumber;
                //lblScore.Text = locationListCount.ToString() + "|" + rowIndex.ToString() + columnIndex.ToString() + "|" + labelArray[rowIndex][columnIndex].Name;
            }
            return currentLabelNumberArray;
        }
        #endregion

        #region 函数 - 获取当前控件的值的数组
        /// <summary>
        /// 获取当前控件的值
        /// </summary>
        /// <returns></returns>
        private List<List<int>> GetCurrentLabelNumberArray()
        {
            List<List<int>> currentLabelNumberArray = new List<List<int>>();
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                List<int> labelNumberList = new List<int>();
                for (int columnIndex = 0; columnIndex < 4; columnIndex++)
                {
                    Label labelItem = LABELARRAY[rowIndex][columnIndex];
                    labelNumberList.Add(int.Parse(labelItem.Text));
                }
                currentLabelNumberArray.Add(labelNumberList);
            }

            return currentLabelNumberArray;
        }
        #endregion

        #region 函数 - 获取未使用的坐标列表
        /// <summary>
        /// 获取未使用的坐标列表
        /// </summary>
        /// <returns></returns>
        private List<int> GetNotUseLocationList()
        {
            List<int> locationList = new List<int>();
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 4; columnIndex++)
                {
                    Label labelItem = LABELARRAY[rowIndex][columnIndex];
                    if (labelItem.Text == "0")
                    {
                        locationList.Add(rowIndex * 10 + columnIndex);
                    }
                }
            }

            return locationList;
        }
        #endregion

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefleshCalculate(RandomNewNumberTwoOrFour());;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                RefleshCalculate(LabelNumberCalculate(0, LABELARRAY));;
                // RefleshCalculate(RandomNewNumberTwoOrFour());
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                RefleshCalculate(LabelNumberCalculate(1, LABELARRAY));;
                // RefleshCalculate(RandomNewNumberTwoOrFour());
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                RefleshCalculate(LabelNumberCalculate(2, LABELARRAY));;
                // RefleshCalculate(RandomNewNumberTwoOrFour());
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                RefleshCalculate(LabelNumberCalculate(3, LABELARRAY));;
                // RefleshCalculate(RandomNewNumberTwoOrFour());
            }
            #region 折叠
            // int loopIndex = 0;
            // for (loopIndex = 0; loopIndex <= 1; loopIndex ++)
            // {
            //     if (KEYBOARDSTATE0 + KEYBOARDSTATE1 + KEYBOARDSTATE2 + KEYBOARDSTATE3 + KEYBOARDSTATEFULL == 0)
            //     {
            //         loopIndex = 1;
            //     }
            //     else
            //     {
            //         loopIndex = 0;
            //     }
            //     Application.DoEvents();
            // }

            // if (KEYBOARDSTATE0 + KEYBOARDSTATE1 + KEYBOARDSTATE2 + KEYBOARDSTATE3 + KEYBOARDSTATEFULL == 0)
            // {
            //     if (e.KeyCode == Keys.Enter)
            //     {
            //         KEYBOARDSTATEFULL = 1;

            //         BACKGROUNDWORKERLABELNEWNUMBER = new BackgroundWorker()
            //         {
            //             WorkerReportsProgress = true,
            //             WorkerSupportsCancellation = true,
            //         };
            //         BACKGROUNDWORKERLABELNEWNUMBER.DoWork += BACKGROUNDWORKERLABELNEWNUMBER_DoWork;
            //         BACKGROUNDWORKERLABELNEWNUMBER.ProgressChanged += BACKGROUNDWORKERLABELNEWNUMBER_ProgressChanged;
            //         BACKGROUNDWORKERLABELNEWNUMBER.RunWorkerCompleted += BACKGROUNDWORKERLABELNEWNUMBER_RunWorkerCompleted;

            //         List<List<int>> usedNumberArray = ClassCalculate.GetUsedNumberArray(pnlGameArea, LABELARRAY);
            //         Dictionary<string, object> labelNewNumberInfoDict = new Dictionary<string, object>
            //         {
            //             { "usedNumberArray", usedNumberArray },
            //             { "pnlGameArea", pnlGameArea }
            //         };

            //         BACKGROUNDWORKERLABELNEWNUMBER.RunWorkerAsync(labelNewNumberInfoDict);
            //     }
            //     else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            //     {
            //         KEYBOARDSTATE0 = 1;
            //         KEYBOARDSTATE1 = 1;
            //         KEYBOARDSTATE2 = 1;
            //         KEYBOARDSTATE3 = 1;

            //         BACKGROUNDWORKERLABELMOVE0 = new BackgroundWorker()
            //         {
            //             WorkerReportsProgress = true,
            //             WorkerSupportsCancellation = true,
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.DoWork += BackgroundWorkerLabelMove_DoWork;
            //         BACKGROUNDWORKERLABELMOVE0.ProgressChanged += BackgroundWorkerLabelMove_ProgressChanged;
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerCompleted += BackgroundWorkerLabelMove_RunWorkerCompleted;
            //         Dictionary<string, object> labelMoveInfoDict1 = new Dictionary<string, object>
            //         {
            //             { "labelMove", lblNumber105_105 },
            //             { "direction", 0 },
            //             { "startMove", lblNumber105_105.Top },
            //             { "endMove", 15 },
            //             { "moveStep", 10 },
            //             { "backgroundWorkerId", 0 }
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerAsync(labelMoveInfoDict1);

            //         BACKGROUNDWORKERLABELMOVE0 = new BackgroundWorker()
            //         {
            //             WorkerReportsProgress = true,
            //             WorkerSupportsCancellation = true,
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.DoWork += BackgroundWorkerLabelMove_DoWork;
            //         BACKGROUNDWORKERLABELMOVE0.ProgressChanged += BackgroundWorkerLabelMove_ProgressChanged;
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerCompleted += BackgroundWorkerLabelMove_RunWorkerCompleted;
            //         Dictionary<string, object> labelMoveInfoDict2 = new Dictionary<string, object>
            //         {
            //             { "labelMove", lblNumber195_195 },
            //             { "direction", 0 },
            //             { "startMove", lblNumber195_195.Top },
            //             { "endMove", 15 },
            //             { "moveStep", 10 },
            //             { "backgroundWorkerId", 0 }
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerAsync(labelMoveInfoDict2);
            //     }
            //     else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            //     {
            //         KEYBOARDSTATE0 = 1;
            //         KEYBOARDSTATE1 = 1;
            //         KEYBOARDSTATE2 = 1;
            //         KEYBOARDSTATE3 = 1;

            //         BACKGROUNDWORKERLABELMOVE0 = new BackgroundWorker()
            //         {
            //             WorkerReportsProgress = true,
            //             WorkerSupportsCancellation = true,
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.DoWork += BackgroundWorkerLabelMove_DoWork;
            //         BACKGROUNDWORKERLABELMOVE0.ProgressChanged += BackgroundWorkerLabelMove_ProgressChanged;
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerCompleted += BackgroundWorkerLabelMove_RunWorkerCompleted;
            //         Dictionary<string, object> labelMoveInfoDict1 = new Dictionary<string, object>
            //         {
            //             { "labelMove", lblNumber105_105 },
            //             { "direction", 0 },
            //             { "startMove", lblNumber105_105.Top },
            //             { "endMove", 285 },
            //             { "moveStep", 10 },
            //             { "backgroundWorkerId", 0 }
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerAsync(labelMoveInfoDict1);
            //     }
            //     else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            //     {
            //         KEYBOARDSTATE0 = 1;
            //         KEYBOARDSTATE1 = 1;
            //         KEYBOARDSTATE2 = 1;
            //         KEYBOARDSTATE3 = 1;

            //         BACKGROUNDWORKERLABELMOVE0 = new BackgroundWorker()
            //         {
            //             WorkerReportsProgress = true,
            //             WorkerSupportsCancellation = true,
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.DoWork += BackgroundWorkerLabelMove_DoWork;
            //         BACKGROUNDWORKERLABELMOVE0.ProgressChanged += BackgroundWorkerLabelMove_ProgressChanged;
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerCompleted += BackgroundWorkerLabelMove_RunWorkerCompleted;
            //         Dictionary<string, object> labelMoveInfoDict1 = new Dictionary<string, object>
            //         {
            //             { "labelMove", lblNumber105_105 },
            //             { "direction", 1 },
            //             { "startMove", lblNumber105_105.Left },
            //             { "endMove", 15 },
            //             { "moveStep", 10 },
            //             { "backgroundWorkerId", 0 }
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerAsync(labelMoveInfoDict1);
            //     }
            //     else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            //     {
            //         KEYBOARDSTATE0 = 1;
            //         KEYBOARDSTATE1 = 1;
            //         KEYBOARDSTATE2 = 1;
            //         KEYBOARDSTATE3 = 1;

            //         BACKGROUNDWORKERLABELMOVE0 = new BackgroundWorker()
            //         {
            //             WorkerReportsProgress = true,
            //             WorkerSupportsCancellation = true,
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.DoWork += BackgroundWorkerLabelMove_DoWork;
            //         BACKGROUNDWORKERLABELMOVE0.ProgressChanged += BackgroundWorkerLabelMove_ProgressChanged;
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerCompleted += BackgroundWorkerLabelMove_RunWorkerCompleted;
            //         Dictionary<string, object> labelMoveInfoDict1 = new Dictionary<string, object>
            //         {
            //             { "labelMove", lblNumber105_105 },
            //             { "direction", 1 },
            //             { "startMove", lblNumber105_105.Left },
            //             { "endMove", 285 },
            //             { "moveStep", 10 },
            //             { "backgroundWorkerId", 0 }
            //         };
            //         BACKGROUNDWORKERLABELMOVE0.RunWorkerAsync(labelMoveInfoDict1);
            //     }
            // }
            #endregion
        }

        private List<List<int>> LabelNumberCalculate(int direction, List<List<Label>> labelArray)
        {
            List<List<int>> resultLabelNumberArray = new List<List<int>> {
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 }
            };

            // Step 1 获取当前标签数字分布现状, 并且变更为可计算的方向
            List<List<int>> currentLabelNumberArray = new List<List<int>> {
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 }
            };

            int calculateRowIndex;
            int calculateColumnIndex;
            calculateRowIndex = 0;
            for (int columnIndex = 0; columnIndex <= 3; columnIndex++)
            {
                calculateColumnIndex = 0;
                for (int rowIndex = 0; rowIndex <= 3; rowIndex++)
                {
                    int currentLabelNumber = int.Parse(labelArray[rowIndex][columnIndex].Text);
                    currentLabelNumberArray[calculateRowIndex][calculateColumnIndex] = currentLabelNumber;
                    calculateColumnIndex += 1;
                }
                calculateRowIndex += 1;
            }
            
            // Step 2 输出结果计算
            List<List<int>> calculateLabelNumberArray = new List<List<int>>();
            for (int rowIndex = 0; rowIndex <= 3; rowIndex ++) {
                // --> Step 2-1 去除空值
                List<int> calculateLabelNumberList = new List<int>();
                for (int columnIndex = 0; columnIndex <= 3; columnIndex ++) {
                    int currentLabelNumber = currentLabelNumberArray[rowIndex][columnIndex];
                    if (currentLabelNumber > 0) {
                        calculateLabelNumberList.Add(currentLabelNumber);
                    }
                }
                int calculateLabelNumberListCount = calculateLabelNumberList.Count;
                for (int columnIndex = 0; columnIndex < (4 - calculateLabelNumberListCount); columnIndex++)
                {
                    calculateLabelNumberList.Add(0);
                }
                calculateLabelNumberArray.Add(calculateLabelNumberList);
            }

            return calculateLabelNumberArray;
            // int startRowIndex = 0;
            // int endRowIndex = 0;
            // int startColumnIndex = 0;
            // int endColumnIndex = 0;
            
            // switch (direction)
            // {
            //     case 0: // 上
            //         startRowIndex = 0;
            //         endRowIndex = 3;
            //         startColumnIndex = 0;
            //         endColumnIndex = 3;
            //         break;
            //     case 1: // 左
            //         startRowIndex = 0;
            //         endRowIndex = 3;
            //         startColumnIndex = 0;
            //         endColumnIndex = 3;
            //         break;
            //     case 2: // 下
            //         startRowIndex = -3;
            //         endRowIndex = 0;
            //         startColumnIndex = 0;
            //         endColumnIndex = 3;
            //         break;
            //     case 3: // 右
            //         startRowIndex = 0;
            //         endRowIndex = 3;
            //         startColumnIndex = -3;
            //         endColumnIndex = 0;
            //         break;
            // }

            // int outputRowIndex = 0;
            // int outputColumnIndex = 0;

            // int resultRowIndex;
            // int resultColumnIndex;

            // resultRowIndex = 0;
            // for (int rowIndex = startRowIndex; rowIndex <= endRowIndex; rowIndex ++) {
            //     resultColumnIndex = 0;
            //     for (int columnIndex = startColumnIndex; columnIndex <= endColumnIndex; columnIndex ++) {
            //         if (direction % 2 == 0) {
            //             outputRowIndex = Math.Abs(rowIndex);
            //             outputColumnIndex = Math.Abs(columnIndex);
            //         }
            //         else
            //         {
            //             outputRowIndex = Math.Abs(columnIndex);
            //             outputColumnIndex = Math.Abs(rowIndex);
            //         }
            //         int labelNumber = int.Parse(labelArray[outputRowIndex][outputColumnIndex].Text);
            //         currentLabelNumberArray[resultRowIndex][resultColumnIndex] = labelNumber;
            //         resultColumnIndex += 1;
            //     }
            //     resultRowIndex += 1;
            // }

            // // Step 2 输出结果计算
            // List<List<int>> calculateLabelNumberArray = new List<List<int>>();
            // for (int rowIndex = 0; rowIndex <= 3; rowIndex ++) {
            //     // --> Step 2-1 去除空值
            //     List<int> calculateLabelNumberList = new List<int>();
            //     for (int columnIndex = 0; columnIndex <= 3; columnIndex ++) {
            //         int currentLabelNumber = currentLabelNumberArray[rowIndex][columnIndex];
            //         if (currentLabelNumber != 0) {
            //             calculateLabelNumberList.Add(currentLabelNumber);
            //         }
            //     }
            //     int calculateLabelNumberListCount = calculateLabelNumberList.Count;
            //     for (int columnIndex = 0; columnIndex < (4 - calculateLabelNumberListCount); columnIndex++)
            //     {
            //         calculateLabelNumberList.Add(0);
            //     }

            //     // --> Step 2-2 合并同向值
            //     for (int columnIndex = 0; columnIndex < 3; columnIndex++)
            //     {
            //         int currentLabelNumber = calculateLabelNumberList[columnIndex];
            //         int nextLabelNumber = calculateLabelNumberList[columnIndex + 1];
            //         if (currentLabelNumber == nextLabelNumber)
            //         {
            //             calculateLabelNumberList[columnIndex] = 2 * currentLabelNumber;
            //             calculateLabelNumberList[columnIndex + 1] = 0;
            //         }
            //     }

            //     // --> Step 2-3 去除空值
            //     List<int> outputLabelNumberList = new List<int>();
            //     for (int columnIndex = 0; columnIndex < calculateLabelNumberList.Count; columnIndex ++) {
            //         int currentLabelNumber = calculateLabelNumberList[columnIndex];
            //         if (currentLabelNumber != 0) {
            //             outputLabelNumberList.Add(currentLabelNumber);
            //         }
            //     }
            //     int outputLabelNumberListCount = outputLabelNumberList.Count;
            //     for (int columnIndex = 0; columnIndex < (4 - outputLabelNumberListCount); columnIndex++)
            //     {
            //         outputLabelNumberList.Add(0);
            //     }
            //     calculateLabelNumberArray.Add(outputLabelNumberList);
            // }

            // // 旋转回输出的方向
            // outputRowIndex = 0;
            // for (int rowIndex = startRowIndex; rowIndex <= endRowIndex; rowIndex ++) {
            //     outputColumnIndex = 0;
            //     for (int columnIndex = startColumnIndex; columnIndex <= endColumnIndex; columnIndex ++) {
            //         if (direction % 2 == 0) {
            //             resultRowIndex = Math.Abs(rowIndex);
            //             resultColumnIndex = Math.Abs(columnIndex);
            //         }
            //         else
            //         {
            //             resultRowIndex = Math.Abs(columnIndex);
            //             resultColumnIndex = Math.Abs(rowIndex);
            //         }
            //         // int labelNumber = currentLabelNumberArray[outputRowIndex][outputColumnIndex];
            //         int labelNumber = calculateLabelNumberArray[outputRowIndex][3 - outputColumnIndex];
            //         resultLabelNumberArray[resultRowIndex][resultColumnIndex] = labelNumber;
            //         outputColumnIndex += 1;
            //     }
            //     outputRowIndex += 1;
            // }
        }

        #region 多线程 - 标签控件放大
        private void BACKGROUNDWORKERLABELNEWNUMBER_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, object> labelNewNumberSizeChangeDict = (Dictionary<string, object>)e.Result;
            if (labelNewNumberSizeChangeDict != null)
            {
                BackgroundWorker backgroundWorkerSizeChange = new BackgroundWorker(){
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true,
                };
                backgroundWorkerSizeChange.DoWork += BackgroundWorkerSizeChange_DoWork;
                backgroundWorkerSizeChange.ProgressChanged += BackgroundWorkerSizeChange_ProgressChanged;
                backgroundWorkerSizeChange.RunWorkerCompleted += BackgroundWorkerSizeChange_RunWorkerCompleted;
                backgroundWorkerSizeChange.RunWorkerAsync(labelNewNumberSizeChangeDict);
            }
            else
            {
                KEYBOARDSTATEFULL = 0;
            }
            ((BackgroundWorker)sender).Dispose();
        }

        private void BACKGROUNDWORKERLABELNEWNUMBER_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Dictionary<string, object> labelNewNumberChangeInfoDict = (Dictionary<string, object>)e.UserState;
            Label labelDemo = (Label)labelNewNumberChangeInfoDict["labelDemo"];
            Panel PnlGameArea = (Panel)labelNewNumberChangeInfoDict["pnlGameArea"];
            int newNumber = (int)labelNewNumberChangeInfoDict["newNumber"];
            Label newLabel = (Label)labelNewNumberChangeInfoDict["newLabel"];

            PnlGameArea.Controls.Add(newLabel);
            newLabel.BringToFront();
        }

        private void BACKGROUNDWORKERLABELNEWNUMBER_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> labelNewNumberInfoDict = (Dictionary<string, object>)e.Argument;
            List<List<int>> usedNumberArray = (List<List<int>>)labelNewNumberInfoDict["usedNumberArray"];
            Panel PnlGameArea = (Panel)labelNewNumberInfoDict["pnlGameArea"];
            
            // 获取未使用的坐标
            List<List<int>> usableNumberRCList = new List<List<int>>();
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 4; columnIndex++)
                {
                    int useState = usedNumberArray[rowIndex][columnIndex];
                    if (useState == 0)
                    {
                        usableNumberRCList.Add(new List<int> { rowIndex, columnIndex });
                    }
                }
            }

            // 随机提取一个坐标
            Random random = new Random();
            int usableNumberRCListCount = usableNumberRCList.Count;
            int usableIndex = 0;
            int usableNumberRowIndex = 0;
            int usableNumberColumnIndex = 0;
            if (usableNumberRCListCount > 0)
            {
                usableIndex = random.Next(0, usableNumberRCListCount);
                List<int> usableNumberRC = usableNumberRCList[usableIndex];
                usableNumberRowIndex = usableNumberRC[0];
                usableNumberColumnIndex = usableNumberRC[1];

                // 随机生成一个数字
                int randomNumber = random.Next(0, 99);
                int newNumber = 0;
                if (randomNumber <= 60)
                {
                    newNumber = 2;
                }
                else
                {
                    newNumber = 4;
                }

                // 数字样式
                Dictionary<string, object> numberLabelStyle = ClassCalculate.GetNumberLabelStyle(newNumber);
                Font font = (Font)numberLabelStyle["font"];
                Color foreColor = (Color)numberLabelStyle["foreColor"];
                Color backColor = (Color)numberLabelStyle["backColor"];

                // 创建新标签
                Label labelDemo = LABELARRAY[usableNumberRowIndex][usableNumberColumnIndex];
                Label newLabel = new Label
                {
                    Width = 0,
                    Height = 0,
                    Left = labelDemo.Left + labelDemo.Width / 2,
                    Top = labelDemo.Top + labelDemo.Height / 2,
                    Font = font,
                    BackColor = backColor,
                    ForeColor = foreColor,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = newNumber.ToString(),
                    Name = String.Format("lblNumber{0}_{1}", Left, Top)
                };

                Dictionary<string, object> labelNewNumberSizeChangeDict = new Dictionary<string, object>
                {
                    { "newLabel", newLabel },
                    { "labelDemo", labelDemo },
                    { "sizeIndex", -1 }
                };
                e.Result = labelNewNumberSizeChangeDict;

                Dictionary<string, object> labelNewNumberChangeInfoDict = new Dictionary<string, object>{
                    { "labelDemo", labelDemo },
                    { "pnlGameArea", PnlGameArea },
                    { "newNumber", newNumber },
                    { "newLabel", newLabel }
                };
                ((BackgroundWorker)sender).ReportProgress(1, labelNewNumberChangeInfoDict);
            }
        }

        private void BackgroundWorkerSizeChange_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            KEYBOARDSTATEFULL = 0;
            ((BackgroundWorker)sender).Dispose();
        }

        private void BackgroundWorkerSizeChange_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Dictionary<string, object> labelNewNumberSizeChangeDict = (Dictionary<string, object>)e.UserState;
            Label newLabel = (Label)labelNewNumberSizeChangeDict["newLabel"];
            Label labelDemo = (Label)labelNewNumberSizeChangeDict["labelDemo"];
            int sizeIndex = (int)labelNewNumberSizeChangeDict["sizeIndex"];

            newLabel.Width = sizeIndex;
            newLabel.Height = sizeIndex;
            newLabel.Left = (2 * labelDemo.Left + labelDemo.Width - sizeIndex) / 2;
            newLabel.Top = (2 * labelDemo.Top + labelDemo.Height - sizeIndex) / 2;
        }

        private void BackgroundWorkerSizeChange_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> labelNewNumberSizeChangeDict = (Dictionary<string, object>)e.Argument;
            Label newLabel = (Label)labelNewNumberSizeChangeDict["newLabel"];
            Label labelDemo = (Label)labelNewNumberSizeChangeDict["labelDemo"];
            
            for (int sizeIndex = 0; sizeIndex <= labelDemo.Width; sizeIndex += 2)
            {
                labelNewNumberSizeChangeDict["sizeIndex"] = sizeIndex;
                Thread.Sleep(2);
                ((BackgroundWorker)sender).ReportProgress(1, labelNewNumberSizeChangeDict);
            }
        }
        #endregion

        #region 多线程 - 标签控件移动
        private void BackgroundWorkerLabelMove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int backgroundWorkerId = int.Parse(e.Result.ToString());
            switch (backgroundWorkerId)
            {
                case 0:
                    KEYBOARDSTATE0 = 0;
                    break;
                case 1:
                    KEYBOARDSTATE1 = 0;
                    break;
                case 2:
                    KEYBOARDSTATE2 = 0;
                    break;
                case 3:
                    KEYBOARDSTATE3 = 0;
                    break;
            }
            KEYBOARDSTATE0 = 0;
            KEYBOARDSTATE1 = 0;
            KEYBOARDSTATE2 = 0;
            KEYBOARDSTATE3 = 0;

            ((BackgroundWorker)sender).Dispose();
        }

        private void BackgroundWorkerLabelMove_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Dictionary<string, Object> labelMoveIndexInfoDict = (Dictionary<string, Object>)e.UserState;
            int direction = (int)labelMoveIndexInfoDict["direction"];
            Label labelMove = (Label)labelMoveIndexInfoDict["labelMove"];
            int moveIndex = (int)labelMoveIndexInfoDict["moveIndex"];

            if (direction == 0)
            {
                // 当移动方向为 0 时, 表示上下移动
                labelMove.Top = moveIndex;
            }
            else
            {
                // 当移动方向为 1 时, 表示左右移动
                labelMove.Left = moveIndex;
            }

            lblGameScore.Text = moveIndex.ToString();
        }

        private void BackgroundWorkerLabelMove_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> labelMoveInfoDict = (Dictionary<string, object>)e.Argument;
            Label labelMove = (Label)labelMoveInfoDict["labelMove"];
            int direction = (int)labelMoveInfoDict["direction"];
            int startMove = (int)labelMoveInfoDict["startMove"];
            int endMove = (int)labelMoveInfoDict["endMove"];
            int moveStep = (int)labelMoveInfoDict["moveStep"];
            int backgroundWorkerId = (int)labelMoveInfoDict["backgroundWorkerId"];

            e.Result = backgroundWorkerId;

            // 当『起始移动位置』大于『终止移动位置』时, 表示移动方向为反向移动
            if (startMove > endMove)
            {
               startMove = -startMove;
               endMove = -endMove;
            }

            for (int moveIndex = startMove; moveIndex <= endMove; moveIndex += moveStep)
            {
                Dictionary<string, Object> labelMoveIndexInfoDict = new Dictionary<string, Object> {
                    { "direction", direction },
                    { "labelMove", labelMove },
                    { "moveIndex", Math.Abs(moveIndex) },
                };
                Thread.Sleep(5);
                ((BackgroundWorker)sender).ReportProgress(1, labelMoveIndexInfoDict);
            }
        }
        #endregion
    }
}
