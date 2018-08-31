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
    public partial class BuildEntity : UserControl
    {
        public BuildEntity()
        {
            InitializeComponent();
            cBEntityType.Items.Clear();
            List<string> EntityType = Enum.GetNames(typeof(EntityType)).ToList();
            foreach (string entity in EntityType)
            {
                cBEntityType.Items.Add(entity);
            }
            cBEntityType.SelectedIndex = 0;
        }

        private void cBEntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Singleton<Condition>.Instance.EntityType = (EntityType)Enum.Parse(typeof(EntityType), cBEntityType.SelectedItem.ToString());
        }
    }
}
