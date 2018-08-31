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
    public partial class BuildDALandBLL : UserControl
    {
        public BuildDALandBLL()
        {
            InitializeComponent();
            cBOperation.Items.Clear();
            List<string> OperationTypes = Enum.GetNames(typeof(OperationType)).ToList();
            foreach (string operation in OperationTypes)
            {
                cBOperation.Items.Add(operation);
            }
            cBOperation.SelectedText = Singleton<Condition>.Instance.OperationType.ToString();
            ChangecBReturnType();
            //if (Singleton<Condition>.Instance.OperationType ==OperationType.Add)
            //{
            //    cBReturnType.Items.Clear();
            //    label1.Text = "传入的类型:";
            //    cBReturnType.Items.Add("Entity");
            //    cBReturnType.Items.Add("List<Entity>");
            //    cBReturnType.Items.Add("InputDto");
            //    cBReturnType.Items.Add("List<InputDto>");
            //    cBReturnType.SelectedIndex = 0;
            //    //cBReturnType.SelectedText = "int";
            //    if (Singleton<Condition>.Instance.OperationType == OperationType.Add)
            //    {
            //        BReturnID.Enabled = true;
            //    }
            //    else
            //    {
            //        BReturnID.Enabled = false;
            //    }
            //}


            //else
            //{
            //    cBOperation.SelectedIndex = 0;
            //}
            //cBOperation.SelectedIndex = 0;
            //cBSql.SelectedIndex = 0;
            //cBOperation.SelectedIndex = 0;
            if (Singleton<Condition>.Instance.OperationType == OperationType.Add)
            {
                BReturnID.Enabled = true;
            }
            else
            {
                BReturnID.Enabled = false;
            }
            cBReturnType.SelectedIndex = 0;
            cBCommandType.SelectedIndex = 0;
            BReturnID.SelectedIndex = 0;
            //BReturnID.Enabled = false;
        }


        private void cBCommandType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Singleton<Condition>.Instance.CommandType = (DALCommandType)Enum.Parse(typeof(DALCommandType), cBCommandType.SelectedItem.ToString());
        }

        //private void cBSql_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cBSql.SelectedIndex == 0)
        //    {
        //        Singleton<Condition>.Instance.CBDaBSql = "查询";
        //        cBOperation.Items.Clear();
        //        cBOperation.Items.Add("IsExists");
        //        cBOperation.Items.Add("Get");
        //        cBOperation.Items.Add("GetAll");
        //        cBOperation.SelectedIndex = 0;
        //        cBReturnType.Items.Clear();
        //        cBReturnType.Items.Add("bool");
        //        //cBReturnType.SelectedText = "bool";
        //        BReturnID.Enabled = false;
        //    }
        //    else
        //    {
        //        Singleton<Condition>.Instance.CBDaBSql = "操作数据";
        //        cBOperation.Items.Clear();
        //        cBOperation.Items.Add("Add");
        //        cBOperation.Items.Add("Update");
        //        cBOperation.Items.Add("Delete");
        //        cBOperation.SelectedIndex = 0;
        //        cBReturnType.Items.Clear();
        //        cBReturnType.Items.Add("int");
        //        BReturnID.Enabled = true;
        //        //cBReturnType.SelectedText = "int";
        //    }
        //}

        private void cBReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBReturnType.SelectedItem.ToString() == "Entity")
            {
                Singleton<Condition>.Instance.DALReturnType = cBReturnType.SelectedItem.ToString() + "." + Singleton<Condition>.Instance.CDataTable;
            }
            else if (cBReturnType.SelectedItem.ToString().Trim() == "List<Entity>")
            {
                Singleton<Condition>.Instance.DALReturnType = "List<Entity." + Singleton<Condition>.Instance.CDataTable + ">";
            }
            else
            {
                Singleton<Condition>.Instance.DALReturnType = cBReturnType.SelectedItem.ToString();
            }
        }

        private void cBOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Singleton<Condition>.Instance.OperationType = (OperationType)Enum.Parse(typeof(OperationType), cBOperation.SelectedItem.ToString());
            ChangecBReturnType();
            //if (Singleton<Condition>.Instance.OperationType == OperationType.IsExists)
            //{
            //    cBReturnType.Items.Clear();
            //    cBReturnType.Items.Add("bool");
            //    cBReturnType.SelectedIndex = 0;
            //    //cBReturnType.SelectedText = "bool";
            //}
            //else if (Singleton<Condition>.Instance.OperationType == OperationType.Get || Singleton<Condition>.Instance.OperationType == OperationType.GetAll)
            //{
            //    cBReturnType.Items.Clear();
            //    cBReturnType.Items.Add("Entity");
            //    cBReturnType.Items.Add("List<Entity>");
            //    cBReturnType.Items.Add("OutputDto");
            //    cBReturnType.Items.Add("List<OutputDto>");
            //    cBReturnType.Items.Add("string");
            //    cBReturnType.Items.Add("int");
            //    cBReturnType.SelectedIndex = 0;
            //    //cBReturnType.SelectedText = "Entity";
            //}
            //else if(Singleton<Condition>.Instance.OperationType==OperationType.Delete)
            //{
            //    cBReturnType.Items.Clear();
            //    cBReturnType.Items.Add("int");
            //    cBReturnType.SelectedIndex = 0;
            //    //cBReturnType.SelectedText = "int";
            //    if (Singleton<Condition>.Instance.OperationType == OperationType.Add)
            //    {
            //        BReturnID.Enabled = true;
            //    }
            //    else
            //    {
            //        BReturnID.Enabled = false;
            //    }
            //}
            //else
            //{
            //    cBReturnType.Items.Clear();
            //    label1.Text = "传入的类型:";
            //    cBReturnType.Items.Add("Entity");
            //    cBReturnType.Items.Add("List<Entity>");
            //    cBReturnType.Items.Add("InputDto");
            //    cBReturnType.Items.Add("List<InputDto>");
            //    cBReturnType.SelectedIndex = 0;
            //    //cBReturnType.SelectedText = "int";
            //    if (Singleton<Condition>.Instance.OperationType == OperationType.Add)
            //    {
            //        BReturnID.Enabled = true;
            //    }
            //    else
            //    {
            //        BReturnID.Enabled = false;
            //    }
            //}
        }

        private void cBReturnType_SelectedValueChanged(object sender, EventArgs e)
        {
            Singleton<Condition>.Instance.DALReturnType = cBReturnType.SelectedItem.ToString();
        }

        private void cBOperation_SelectedValueChanged(object sender, EventArgs e)
        {
            Singleton<Condition>.Instance.OperationType = (OperationType)Enum.Parse(typeof(OperationType), cBOperation.SelectedItem.ToString());
            ChangecBReturnType();
            //Singleton<Condition>.Instance.OperationType = (OperationType)Enum.Parse(typeof(OperationType), cBOperation.SelectedItem.ToString());
            //if (Singleton<Condition>.Instance.OperationType == OperationType.IsExists)
            //{
            //    cBReturnType.Items.Clear();
            //    cBReturnType.Items.Add("bool");
            //    cBReturnType.SelectedIndex = 0;
            //    //cBReturnType.SelectedText = "bool";
            //}
            //else if (Singleton<Condition>.Instance.OperationType == OperationType.Get || Singleton<Condition>.Instance.OperationType == OperationType.GetAll)
            //{
            //    cBReturnType.Items.Clear();
            //    cBReturnType.Items.Add("Entity");
            //    cBReturnType.Items.Add("List<Entity>");
            //    cBReturnType.Items.Add("string");
            //    cBReturnType.Items.Add("int");
            //    cBReturnType.SelectedIndex = 0;
            //    //cBReturnType.SelectedText = "Entity";
            //}
            //else
            //{
            //    cBReturnType.Items.Clear();
            //    cBReturnType.Items.Add("int");
            //    cBReturnType.SelectedIndex = 0;
            //    //cBReturnType.SelectedText = "int";
            //    if (Singleton<Condition>.Instance.OperationType == OperationType.Add)
            //    {
            //        BReturnID.Enabled = true;
            //    }
            //    else
            //    {
            //        BReturnID.Enabled = false;
            //    }
            //}
        }

        private void BReturnID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BReturnID.SelectedItem.ToString().Trim() == "是")
            {
                Singleton<Condition>.Instance.IsDALReturnID = true;
            }
            else
            {
                Singleton<Condition>.Instance.IsDALReturnID = false;
            }
        }

        private void ChangecBReturnType()
        {
            if (Singleton<Condition>.Instance.OperationType == OperationType.IsExists)
            {
                cBReturnType.Items.Clear();
                label1.Text = "返回值类型：";
                cBReturnType.Items.Add("bool");
                cBReturnType.SelectedIndex = 0;
                BReturnID.Enabled = false;
                //cBReturnType.SelectedText = "bool";
            }
            else if (Singleton<Condition>.Instance.OperationType == OperationType.Get || Singleton<Condition>.Instance.OperationType == OperationType.GetAll)
            {
                cBReturnType.Items.Clear();
                label1.Text = "返回值类型：";
                cBReturnType.Items.Add("Entity");
                cBReturnType.Items.Add("List<Entity>");
                cBReturnType.Items.Add("OutputDto");
                cBReturnType.Items.Add("List<OutputDto>");
                cBReturnType.Items.Add("string");
                cBReturnType.Items.Add("int");
                cBReturnType.SelectedIndex = 0;
                BReturnID.Enabled = false;
                //cBReturnType.SelectedText = "Entity";
            }
            else if (Singleton<Condition>.Instance.OperationType == OperationType.Delete)
            {
                cBReturnType.Items.Clear();
                label1.Text = "返回值类型：";
                cBReturnType.Items.Add("int");
                cBReturnType.SelectedIndex = 0;
                BReturnID.Enabled = false;
            }
            else
            {
                cBReturnType.Items.Clear();
                label1.Text = "传入的类型:";
                cBReturnType.Items.Add("Entity");
                cBReturnType.Items.Add("List<Entity>");
                cBReturnType.Items.Add("InputDto");
                cBReturnType.Items.Add("List<InputDto>");
                cBReturnType.SelectedIndex = 0;
                //cBReturnType.SelectedText = "int";
                if (Singleton<Condition>.Instance.OperationType == OperationType.Add)
                {
                    BReturnID.Enabled = true;
                }
                else
                {
                    BReturnID.Enabled = false;
                }
            }
        }


        //private void cBReturnType_TextUpdate(object sender, EventArgs e)
        //{
        //    cBReturnType.SelectedIndex = 0;
        //    Singleton<Condition>.Instance.CBDaBReturnType = cBReturnType.SelectedItem.ToString();
        //}

        //private void cBOperation_TextUpdate(object sender, EventArgs e)
        //{

        //}
    }
}
