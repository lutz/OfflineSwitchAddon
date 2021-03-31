using SwissAcademic.Citavi;
using SwissAcademic.Citavi.Shell;
using SwissAcademic.Controls;
using SwissAcademic.Resources;
using System.Windows.Forms;

namespace OfflineSwitch
{
    partial class Addon
    {
        public override void OnApplicationIdle(MainForm mainForm)
        {
            var button = mainForm.GetMainCommandbarManager().GetReferenceEditorCommandbar(MainFormReferenceEditorCommandbarId.Menu).GetCommandbarMenu(MainFormReferenceEditorCommandbarMenuId.Tools).GetCommandbarButton(Key_GoOffline);
            if (button != null)
            {
                button.Text = CitaviEngine.IsOfflineModeActive ? Tools.StartForm_ActivateOfflineMode_Deactivate : Tools.StartForm_ActivateOfflineMode_Activate;
            }
        }

        public override void OnHostingFormLoaded(MainForm mainForm)
        {
            if (mainForm.Project.ProjectType != ProjectType.DesktopCloud) return;

            var button = mainForm.GetMainCommandbarManager().GetReferenceEditorCommandbar(MainFormReferenceEditorCommandbarId.Menu).GetCommandbarMenu(MainFormReferenceEditorCommandbarMenuId.Tools).AddCommandbarButton(Key_GoOffline, Tools.StartForm_ActivateOfflineMode_Deactivate, CommandbarItemStyle.Text);
            if (button != null)
            {
                button.Shortcut = (Shortcut)(Keys.Control | Keys.Q);
                button.HasSeparator = true;
            }

            button = mainForm.GetMainCommandbarManager().GetReferenceEditorCommandbar(MainFormReferenceEditorCommandbarId.Menu).GetCommandbarMenu(MainFormReferenceEditorCommandbarMenuId.Tools).AddCommandbarButton(Key_GoOfflineWithDialog, Tools.StartForm_ActivateOfflineMode_Deactivate, CommandbarItemStyle.Text);
            if (button != null)
            {
                button.Shortcut = (Shortcut)(Keys.Control | Keys.Alt | Keys.Q);
                button.Visible = false;
            }
        }

        public override void OnBeforePerformingCommand(MainForm mainForm, BeforePerformingCommandEventArgs e)
        {
            e.Handled = true;

            switch (e.Key)
            {
                case Key_GoOffline:
                    {
                        SwitchOnlineOfflineStatus();
                    }
                    break;
                case Key_GoOfflineWithDialog:
                    {
                        ShowActiveOfflineModeDialog();
                    }
                    break;

                default:
                    e.Handled = false;
                    break;
            }
        }
    }
}
