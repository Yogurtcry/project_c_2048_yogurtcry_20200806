﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Project_C_2048_Yogurtcry_20200806
{
    class ClassCalculate
    {
        /// <summary>
        /// 标签控件移动事件 - 待删除
        /// </summary>
        /// <param name="labelMove">待移动标签控件</param>
        /// <param name="direction">移动方向。0: 上下; 1: 左右;</param>
        /// <param name="startMove">起始移动位置</param>
        /// <param name="endMove">终止移动位置</param>
        /// <param name="moveStep">移动步长</param>
        public static int LabelMoveEvent(Label labelMove, int direction, int startMove, int endMove, int moveStep)
        {
            // 当『起始移动位置』大于『终止移动位置』时, 表示移动方向为反向移动
            if (startMove > endMove)
            {
                startMove = -startMove;
                endMove = -endMove;
            }

            for (int moveIndex = startMove; moveIndex <= endMove; moveIndex += moveStep)
            {
                if (direction == 0)
                {
                    // 当移动方向为 0 时, 表示上下移动
                    labelMove.Top = Math.Abs(moveIndex);
                }
                else
                {
                    // 当移动方向为 1 时, 表示左右移动
                    labelMove.Left = Math.Abs(moveIndex);
                }
                //Application.DoEvents();
                Thread.Sleep(10);
            }

            return 0;
        }

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
        public static List<List<int>> GetUsedNumberArray(Panel pnlGameArea, List<List<Label>> labelArray){
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
    }
}
