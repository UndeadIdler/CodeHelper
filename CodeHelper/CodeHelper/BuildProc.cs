using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeHelper
{
    public partial class BuildProc : UserControl
    {
        public BuildProc()
        {
            InitializeComponent();
            cBType.Items.Clear();
            List<string> OperationTypes = Enum.GetNames(typeof(OperationType)).ToList();
            foreach (string operation in OperationTypes)
            {
                cBType.Items.Add(operation);
            }
            cBType.SelectedText = Singleton<Condition>.Instance.OperationType.ToString();
            //if (Singleton<Condition>.Instance.OperationType != null)
            //{
            //    cBType.SelectedText = Singleton<Condition>.Instance.OperationType.ToString();
            //}
            //else
            //{
            //    cBType.SelectedIndex = 0;
            //}
            //cBType.SelectedIndex = 0;
            if (Singleton<Condition>.Instance.OperationType == OperationType.Add)
            {
                BPReturnID.Enabled = true;
            }
            else
            {
                BPReturnID.Enabled = false;
            }
            BPReturnID.SelectedIndex = 0;
            //BPReturnID.Enabled = false;
        }


        private void cBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Singleton<Condition>.Instance.OperationType = (OperationType)Enum.Parse(typeof(OperationType), cBType.SelectedItem.ToString());
            if (Singleton<Condition>.Instance.OperationType == OperationType.Add)
            {
                BPReturnID.Enabled = true;
            }
            else
            {
                BPReturnID.Enabled = false;
            }
        }

        private void BPReturnID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BPReturnID.SelectedItem.ToString() == "是")
            {
                Singleton<Condition>.Instance.IsProcReturnID = true;
            }
            else
            {
                Singleton<Condition>.Instance.IsProcReturnID = false;
            }
        }
    }
}
