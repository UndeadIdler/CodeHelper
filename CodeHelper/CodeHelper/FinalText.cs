using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace CodeHelper
{
    public partial class FinalText : UserControl
    {
        public FinalText()
        {
            InitializeComponent();
        }

        private void FinalText_Load(object sender, EventArgs e)
        {
            DealData.SetFParameter();
            //textEditorControl1.Text = DALText();
            //textEditorControl1.Text = EntityText();
            if (Singleton<Condition>.Instance.ResultType==ResultType.DAL)
            {
                if (string.IsNullOrEmpty(Singleton<Condition>.Instance.DALAccessType))
                {
                    Singleton<Condition>.Instance.DALAccessType = "public";
                }
                textEditorControl1.Text = DALText.FinalDAL();
            }
            else if (Singleton<Condition>.Instance.ResultType==ResultType.Entity)
            {

                if (string.IsNullOrEmpty(Singleton<Condition>.Instance.EntityAccessType))
                {
                    Singleton<Condition>.Instance.EntityAccessType = "public";
                }
                //textEditorControl1.Text = FinalTexts.EntityTexts();
                textEditorControl1.Text = EntityText.FinalEntity();
            }
            else
            {
                //textEditorControl1.Text = FinalTexts.ProcTexts();
            }
            //if (ActiveEditor != null)
            //{
            //    ActiveEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(miThis.Tag as string);
            //}
            textEditorControl1.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
        }
    }
}

