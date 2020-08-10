using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Project_C_2048_Yogurtcry_20200806
{
    class ClassCalculate
    {
        /// <summary>
        /// 获取标签控件样式
        /// </summary>
        /// <param name="calculateNumber"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetNumberLabelStyle(int calculateNumber)
        {
            Dictionary<string, object> calculateLabelStyle = new Dictionary<string, object>();
            // 渲染颜色
            switch (calculateNumber)
            {
                case 0:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 30, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(204, 192, 178));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(204, 192, 178));
                    break;
                case 2:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 30, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(238, 228, 218));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(127, 116, 107));
                    break;
                case 4:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 30, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(237, 224, 200));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(127, 116, 107));
                    break;
                case 8:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 30, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(242, 177, 121));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 16:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 28, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(245, 149, 99));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 32:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 28, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(246, 124, 95));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 64:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 28, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(246, 94, 59));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 128:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 24, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(237, 207, 114));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 256:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 24, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(237, 204, 97));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 512:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 24, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(237, 201, 80));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 1024:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 18, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(237, 198, 63));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 2048:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 18, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(237, 195, 46));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 4096:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 18, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(237, 192, 29));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
                case 8192:
                    calculateLabelStyle.Add("font", new Font("微软雅黑", 18, FontStyle.Bold));
                    calculateLabelStyle.Add("backColor", Color.FromArgb(237, 189, 12));
                    calculateLabelStyle.Add("foreColor", Color.FromArgb(251, 248, 241));
                    break;
            }
            return calculateLabelStyle;
        }

        /// <summary>
        /// 获取已使用的数字标签
        /// </summary>
        /// <param name="pnlGameArea"></param>
        /// <param name="labelArray"></param>
        /// <returns></returns>
        public static List<List<int>> GetUsedNumberArray(Panel pnlGameArea, List<List<Label>> labelArray)
        {
            List<List<int>> resultUsedNumberArray = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0}
            };

            List<Label> labelNumberList = new List<Label>();
            foreach (object labelItem in pnlGameArea.Controls)
            {
                Label labelNumber = (Label)labelItem;
                if (labelNumber.Name.IndexOf("lblNumber") >= 0)
                {
                    labelNumberList.Add(labelNumber);
                }
            }

            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 4; columnIndex++)
                {
                    Label labelDemo = labelArray[rowIndex][columnIndex];
                    // labelDemo.Text = labelDemo.Name;
                    foreach (Label labelItem in labelNumberList)
                    {
                        int labelLeft = labelDemo.Left;
                        int labelTop = labelDemo.Top;
                        if (labelItem.Left == labelLeft)
                        {
                            if (labelItem.Top == labelTop)
                            {
                                resultUsedNumberArray[rowIndex][columnIndex] = 1;
                            }
                        }
                    }
                }
            }

            return resultUsedNumberArray;
        }
    
        #region 函数 - 获取当前控件的值
        /// <summary>
        /// 获取当前控件的值
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLabelNumberString(List<List<int>> labelArray)
        {
            string currentLabelNumber = string.Empty;
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 4; columnIndex++)
                {
                    int labelNumber = labelArray[rowIndex][columnIndex];
                    currentLabelNumber += "|" + labelNumber.ToString();
                }
            }

            return currentLabelNumber;
        }
        #endregion
    }
}
