using Infragistics.Win.UltraWinToolbars;
using SwissAcademic.Citavi;
using SwissAcademic.Citavi.Shell;
using System.Linq;
using System.Windows.Forms;

namespace OfflineSwitch
{
    partial class Addon
    {
        private void SwitchOnlineOfflineStatus()
        {
            if (CitaviEngine.IsOfflineModeActive)
            {
                CitaviEngine.DeactivateOfflineMode();
            }
            else
            {
                CitaviEngine.ActivateOfflineMode();
            }
        }

        private void ShowActiveOfflineModeDialog()
        {
            if (Application.OpenForms.OfType<StartForm>().FirstOrDefault() is StartForm startForm)
            {
                var toolbarsManager = startForm.GetType().GetField("toolbarsManager", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(startForm) as SwissAcademic.Controls.ToolbarsManager;
                ButtonTool tool = toolbarsManager.Tools["ActivateOfflineMode"] as ButtonTool;
                startForm.GetType().GetMethod("toolbarsManager_ToolClick", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.Invoke(startForm, new object[] { startForm, new ToolClickEventArgs(tool, new ListToolItem("ActivateOfflineMode")) });
            }
        }
    }
}
