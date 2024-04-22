using MotionModifys.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionModifys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.motion3.json)|*.motion3.json|(*.json)|*.json";
            openFileDialog.Title = "选择Json文件";
            openFileDialog.Multiselect = true;
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            var filePaths = openFileDialog.FileNames;
            if (filePaths.Length == 0) return;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "选择保存目录";
            folderBrowserDialog.ShowDialog();
            string saveDirPath = folderBrowserDialog.SelectedPath;
            if (string.IsNullOrWhiteSpace(saveDirPath)) return;

            for (int i = 0; i < filePaths.Length; i++)
            {
                string filePath = filePaths[i];
                string fileName = new FileInfo(filePath).Name;
                string savePath = Path.Combine(saveDirPath, fileName);
                changeJson(filePath, savePath);
                AppendLog("转换完毕：" + savePath);
            }
        }

        private void changeJson(string filePath, string savePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                JsonModel jsonModel = JsonConvert.DeserializeObject<JsonModel>(json);
                for (int i = 0; i < jsonModel.Curves.Count; i++)
                {
                    changeId(jsonModel.Curves[i]);
                }
                string jsonOutput = JsonConvert.SerializeObject(jsonModel, Formatting.Indented);
                File.WriteAllText(savePath, jsonOutput, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                AppendLog($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void changeId(CurvesModel model)
        {
            // PARAM_ANGLE_X --> ParamAngleX
            if (model.Id.Contains("_") == false) return;
            string[] idArr = model.Id.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
            string[] parms = idArr.Select(o => toHump(o)).ToArray();
            model.Id = string.Join(string.Empty, parms);
        }

        private string toHump(string str)
        {
            str = str?.Trim() ?? string.Empty;
            if (str.Length == 1) return str.ToUpper();
            return str.ToUpper().Take(1).First().ToString() + string.Join(string.Empty, str.ToLower().Skip(1).ToList());
        }

        private void AppendLog(string content)
        {
            this.txtLog.Text += "\r\n" + content;
        }




    }
}
