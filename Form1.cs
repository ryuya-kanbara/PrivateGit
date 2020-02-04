using System;
using System.Reflection;
using System.Windows.Forms;
using sd_lib = System_ds_CommonLibraryCS.libCommon_Common;

namespace GitTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //2020/01/30 Ryuya.Kambara
        //システム終了ボタン処理を追加


        /// <summary>
        /// システム終了ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {        
                //2020/02/04 Ryuya.Kambara
                //システム終了確認メッセージ表示
                if (MessageBox.Show("システムを終了します。よろしいですか?", this.Text, MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            
                //システム終了
                Application.Exit();
            }
            catch (Exception ex)
            {
                sd_lib.ErrorLog_Write("[Object Name]:" + MethodBase.GetCurrentMethod().ReflectedType.Name.ToString() +
                                    "  [Method Name]:" + MethodBase.GetCurrentMethod().Name +
                                    "  [Error kind]:Exception Error" + "\r\n" + ex.Message + "\r\n" + ex.StackTrace, true);
#if DEBUG
                {
                    MessageBox.Show(ex.Message, MethodBase.GetCurrentMethod().ReflectedType.Name.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
#endif
            }
            finally
            {

            }
        }
    }
}
