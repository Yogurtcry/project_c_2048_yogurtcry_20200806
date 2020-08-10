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
            string beforeCalculateLabelNumberArrayString = ClassCalculate.GetCurrentLabelNumberString(GetCurrentLabelNumberArray());

            // 执行标签数字计算
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                RefleshCalculate(LabelNumberCalculate(0, LABELARRAY));
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                RefleshCalculate(LabelNumberCalculate(1, LABELARRAY));
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                RefleshCalculate(LabelNumberCalculate(2, LABELARRAY));
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                RefleshCalculate(LabelNumberCalculate(3, LABELARRAY));
            }

            // 创建新数字
            List<List<int>> afterCalculateLabelNumberArray = GetCurrentLabelNumberArray();
            string afterCalculateLabelNumberArrayString = ClassCalculate.GetCurrentLabelNumberString(afterCalculateLabelNumberArray);
            if (beforeCalculateLabelNumberArrayString != afterCalculateLabelNumberArrayString)
            {
                RefleshCalculate(RandomNewNumberTwoOrFour());
            }
            
            // 检验游戏是否结束
            int endGameState = 0;
            for (int rowIndex = 0; rowIndex <= 3; rowIndex ++)
            {
                for (int columnIndex = 0; columnIndex <= 3; columnIndex ++)
                {
                    int currentLabelNumber = afterCalculateLabelNumberArray[rowIndex][columnIndex];
                    if (currentLabelNumber == 0) {
                        endGameState += 1;
                    }

                    if (rowIndex > 0)
                    {
                        if (currentLabelNumber == afterCalculateLabelNumberArray[rowIndex - 1][columnIndex])
                        {
                            endGameState += 1;
                        }
                    }
                    else
                    {
                        if (currentLabelNumber == afterCalculateLabelNumberArray[rowIndex + 1][columnIndex])
                        {
                            endGameState += 1;
                        }
                    }

                    if (columnIndex > 0)
                    {
                        if (currentLabelNumber == afterCalculateLabelNumberArray[rowIndex][columnIndex - 1])
                        {
                            endGameState += 1;
                        }
                    }
                    else
                    {
                        if (currentLabelNumber == afterCalculateLabelNumberArray[rowIndex][columnIndex + 1])
                        {
                            endGameState += 1;
                        }
                    }
                }
            }
            // 1. 判断上下左右四个方位是否与当前值一致, 如果一致则说明还有可以合并的地方
            // 2. 判断当前位置是否为空(0), 如果为空(0)则说明还可以继续创建新数字
            if (endGameState == 0)
            {
                btnRestart.Show();
            }
        }

        /// <summary>
        /// 函数 - 标签控件计算
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="labelArray"></param>
        /// <returns></returns>
        private List<List<int>> LabelNumberCalculate(int direction, List<List<Label>> labelArray)
        {
            List<List<int>> resultLabelNumberArray = new List<List<int>> {
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 }
            };

            // Step 1 获取当前标签数字分布现状
            List<List<int>> currentLabelNumberArray = new List<List<int>> {
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 },
                new List<int> { 0, 0, 0, 0 }
            };

            for (int rowIndex = 0; rowIndex <= 3; rowIndex ++)
            {
                for (int columnIndex = 0; columnIndex <= 3; columnIndex ++)
                {
                    int currentLabelNumber = int.Parse(labelArray[rowIndex][columnIndex].Text);
                    currentLabelNumberArray[rowIndex][columnIndex] = currentLabelNumber;
                }
            }

            if (direction % 2 == 0)
            {
                #region 上下移动
                int startIndex = 0;
                int endIndex = 0;
                if (direction == 0)
                {
                    startIndex = 0;
                    endIndex = 3;
                }
                else if (direction == 2)
                {
                    startIndex = -3;
                    endIndex = 0;
                }

                // Step 2 输出结果计算
                List<List<int>> calculateLabelNumberArray = new List<List<int>>();
                for (int columnIndex = 0; columnIndex <= 3; columnIndex ++)
                {
                    // --> Step 2-1 去除空值
                    List<int> calculateLabelNumberList = new List<int>();
                    for (int rowIndex = startIndex; rowIndex <= endIndex; rowIndex ++) // 变了。上: rowIndex = 0 <=3 ++
                    {
                        int currentLabelNumber = currentLabelNumberArray[Math.Abs(rowIndex)][Math.Abs(columnIndex)];
                        if (currentLabelNumber > 0) {
                            calculateLabelNumberList.Add(currentLabelNumber);
                        }
                    }
                    int calculateLabelNumberListCount = calculateLabelNumberList.Count;
                    for (int rowIndex = 0; rowIndex < (4 - calculateLabelNumberListCount); rowIndex++)
                    {
                        calculateLabelNumberList.Add(0);
                    }

                    // --> Step 2-2 合并同向值
                    for (int rowIndex = 0; rowIndex <= 2; rowIndex ++)
                    {
                        int currentLabelNumber = calculateLabelNumberList[rowIndex];
                        int lastLabelNumber = calculateLabelNumberList[rowIndex + 1];
                        if (currentLabelNumber == lastLabelNumber)
                        {
                            calculateLabelNumberList[rowIndex] = currentLabelNumber * 2;
                            calculateLabelNumberList[rowIndex + 1] = 0;
                        }
                    }

                    // --> Step 2-3 去除合并后的空值
                    List<int> cleanCalculateLabelNumberList = new List<int>();
                    for (int rowIndex = 0; rowIndex <= 3; rowIndex ++) {
                        int currentLabelNumber = calculateLabelNumberList[rowIndex];
                        if (currentLabelNumber > 0) {
                            cleanCalculateLabelNumberList.Add(currentLabelNumber);
                        }
                    }
                    int cleanCalculateLabelNumberListCount = cleanCalculateLabelNumberList.Count;
                    for (int rowIndex = 0; rowIndex < (4 - cleanCalculateLabelNumberListCount); rowIndex++)
                    {
                        cleanCalculateLabelNumberList.Add(0);
                    }

                    calculateLabelNumberArray.Add(cleanCalculateLabelNumberList);
                }

                // Step 3 旋转输出结果
                int outputRowIndex;
                int outputColumnIndex;
                outputRowIndex = 0;
                for (int columnIndex = startIndex; columnIndex <= endIndex; columnIndex ++)  // 变了 上: columnIndex = 0 <=3 ++
                {
                    outputColumnIndex = 0;
                    for (int rowIndex = 0; rowIndex <= 3; rowIndex ++)
                    {
                        int calculateLabelNumber = calculateLabelNumberArray[rowIndex][Math.Abs(columnIndex)];
                        resultLabelNumberArray[outputRowIndex][outputColumnIndex] = calculateLabelNumber;
                        outputColumnIndex += 1;
                    }
                    outputRowIndex += 1;
                }

                return resultLabelNumberArray;
                #endregion
            } 
            else
            {
                #region 左右移动
                int startIndex = 0;
                int endIndex = 0;
                if (direction == 1)
                {
                    startIndex = 0;
                    endIndex = 3;
                }
                else if (direction == 3)
                {
                    startIndex = -3;
                    endIndex = 0;
                }

                // Step 2 输出结果计算
                List<List<int>> calculateLabelNumberArray = new List<List<int>>();
                for (int rowIndex = 0; rowIndex <= 3; rowIndex ++)
                {
                    // --> Step 2-1 去除空值
                    List<int> calculateLabelNumberList = new List<int>();
                    for (int columnIndex = startIndex; columnIndex <= endIndex; columnIndex ++) // 变了。上: rowIndex = 0 <=3 ++  左: columnIndex = 0 <=3 ++
                    {
                        int currentLabelNumber = currentLabelNumberArray[Math.Abs(rowIndex)][Math.Abs(columnIndex)];
                        if (currentLabelNumber > 0) {
                            calculateLabelNumberList.Add(currentLabelNumber);
                        }
                    }
                    int calculateLabelNumberListCount = calculateLabelNumberList.Count;
                    for (int columnIndex = 0; columnIndex < (4 - calculateLabelNumberListCount); columnIndex++)
                    {
                        calculateLabelNumberList.Add(0);
                    }

                    // --> Step 2-2 合并同向值
                    for (int columnIndex = 0; columnIndex <= 2; columnIndex ++)
                    {
                        int currentLabelNumber = calculateLabelNumberList[columnIndex];
                        int lastLabelNumber = calculateLabelNumberList[columnIndex + 1];
                        if (currentLabelNumber == lastLabelNumber)
                        {
                            calculateLabelNumberList[columnIndex] = currentLabelNumber * 2;
                            calculateLabelNumberList[columnIndex + 1] = 0;
                        }
                    }

                    // --> Step 2-3 去除合并后的空值
                    List<int> cleanCalculateLabelNumberList = new List<int>();
                    for (int columnIndex = 0; columnIndex <= 3; columnIndex ++) {
                        int currentLabelNumber = calculateLabelNumberList[columnIndex];
                        if (currentLabelNumber > 0) {
                            cleanCalculateLabelNumberList.Add(currentLabelNumber);
                        }
                    }
                    int cleanCalculateLabelNumberListCount = cleanCalculateLabelNumberList.Count;
                    for (int columnIndex = 0; columnIndex < (4 - cleanCalculateLabelNumberListCount); columnIndex++)
                    {
                        cleanCalculateLabelNumberList.Add(0);
                    }

                    calculateLabelNumberArray.Add(cleanCalculateLabelNumberList);
                }

                // Step 3 旋转输出结果
                int outputRowIndex;
                int outputColumnIndex;
                outputRowIndex = 0;
                for (int rowIndex = 0; rowIndex <= 3; rowIndex ++)  // 变了 上: columnIndex = 0 <=3 ++
                {
                    outputColumnIndex = 0;
                    for (int columnIndex = startIndex; columnIndex <= endIndex; columnIndex ++) // 变了 左: columnIndex = 0 <=3 ++
                    {
                        int calculateLabelNumber = calculateLabelNumberArray[rowIndex][Math.Abs(columnIndex)];
                        resultLabelNumberArray[outputRowIndex][outputColumnIndex] = calculateLabelNumber;
                        outputColumnIndex += 1;
                    }
                    outputRowIndex += 1;
                }

                return resultLabelNumberArray;
                #endregion
            }
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            FrmMain_Load(null, null);
            RefleshCalculate(RandomNewNumberTwoOrFour());
            ((Button)sender).Hide();
        }
    }
}
