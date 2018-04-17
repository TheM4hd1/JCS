using System;
using JCS_1._0.Utilities;
using System.Windows.Forms;

namespace JCS_1._0.Forms
{
    public partial class FrmIdentification : Form
    {
        public FrmIdentification()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IdentificationOptions.IsHttpStatusCode = chbCode.Checked;
            IdentificationOptions.IsRegexPattern = chbRegex.Checked;
            IdentificationOptions.IsPageCompare = chbPage.Checked;
            IdentificationOptions.IsHtmlTags = chbTag.Checked;

            if (IdentificationOptions.IsHttpStatusCode)
            {
                if (clbCode.CheckedItems.Count > 0)
                {
                    IdentificationOptions.HttpStatusCode = string.Empty;
                    CheckedListBox.CheckedItemCollection checkedItems = clbCode.CheckedItems;
                    foreach (object item in checkedItems)
                        IdentificationOptions.HttpStatusCode += $"{item.ToString().Split(' ')[1]}|";
                }
                else
                {
                    MessageBox.Show("Please select atleast one item", "Status Code Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (IdentificationOptions.IsHtmlTags)
            {
                if (clbTag.CheckedItems.Count > 0)
                {
                    IdentificationOptions.HtmlTags = string.Empty;
                    CheckedListBox.CheckedItemCollection checkedItems = clbTag.CheckedItems;
                    foreach (object item in checkedItems)
                        IdentificationOptions.HtmlTags += $"{item}|";
                }
                else
                {
                    MessageBox.Show("Please select atleast one item", "HTMLTags Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (IdentificationOptions.IsRegexPattern)
            {
                IdentificationOptions.RegexPattern = txtRegex.Text;
                if (!IdentificationOptions.IsValidRegex())
                {
                    IdentificationOptions.IsRegexPattern = false;
                    IdentificationOptions.RegexPattern = string.Empty;
                    MessageBox.Show("Invalid Pattern!", "Regex Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (IdentificationOptions.IsPageCompare)
            {
                IdentificationOptions.IsPageCompare = true;
                IdentificationOptions.PageCompare = System.Text.RegularExpressions.Regex.Replace(rtxPage.Text, @"\t|\n|\r", "");
            }

            IdentificationOptions.IsIdentificationOptions = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IdentificationOptions.IsIdentificationOptions = false;
            Close();
        }

        private void chbPage_CheckedChanged(object sender, EventArgs e)
        {
            rtxPage.Enabled = chbPage.Checked;
        }

        private void chbRegex_CheckedChanged(object sender, EventArgs e)
        {
            txtRegex.Enabled = chbRegex.Checked;
        }

        private void chbTag_CheckedChanged(object sender, EventArgs e)
        {
            clbTag.Enabled = chbTag.Checked;
        }

        private void chbCode_CheckedChanged(object sender, EventArgs e)
        {
            clbCode.Enabled = chbCode.Checked;
        }
    }
}
