using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalProcessing
{
    public class Debug
    {
        public static void ShowMessage(String errorName, String errorMessage)
        {
            MessageBox.Show("Detail:" + "\r\n\r\n" + errorMessage, errorName);
        }
    }
}
