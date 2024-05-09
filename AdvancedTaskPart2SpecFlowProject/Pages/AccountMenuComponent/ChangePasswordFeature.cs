using AdvancedTaskPart2SpecFlowProject.DataModel;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.AccountMenuComponent
{
    public class ChangePasswordFeature : CommonDriver
    {
        ChangePasswordRenderComponent? changePasswordRenderComponent;
        public ChangePasswordFeature()
        {
            changePasswordRenderComponent = new ChangePasswordRenderComponent();
        }
        public void ChangePassword(ChangePasswordDM passwordDM)
        {
            changePasswordRenderComponent?.PasswordRenderComponent();

            changePasswordRenderComponent?.GetCurrentPasswordLocator().SendKeys(passwordDM.currentPassword);
            changePasswordRenderComponent?.GetNewPasswordLocator().SendKeys(passwordDM.newPassword);
            changePasswordRenderComponent?.GetConfirmPasswordLocator().SendKeys(passwordDM.confirmPassword);

            changePasswordRenderComponent?.GetSavePasswordLocator().Click();

        }
        public void ChangePasswordBack(ChangePasswordDM passwordDM)
        {
            changePasswordRenderComponent?.UserNameMenuRenderComponent();
            changePasswordRenderComponent?.ChangePasswordOptionRenderComponent();
            ChangePassword(passwordDM);
        }
    }
}
