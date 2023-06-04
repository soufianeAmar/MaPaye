using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace MaPaye.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class MaPayeWindowsFormsModule : ModuleBase
    {
        public MaPayeWindowsFormsModule()
        {
            InitializeComponent();
        }
    }
}
