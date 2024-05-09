using AdvancedTaskPart2SpecFlowProject.DataModel;
using AdvancedTaskPart2SpecFlowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Pages.ProfileNavigationMenuComponents
{
    public class CertificationAddAndDeleteComponent : CommonDriver
    {
        public CertificationRenderComponents certificationRenderComponents;
        int cancelFlag = 0;

        public CertificationAddAndDeleteComponent()
        {
            certificationRenderComponents = new CertificationRenderComponents();
        }
        public void DeleteAllCertificationRecords()
        {

            int rowCount = certificationRenderComponents.GetCertificationRecordsCount();
            for (int i = 1; i <= rowCount;)
            {
                certificationRenderComponents.RenderDeleteComponents();
                rowCount--;
                Thread.Sleep(4000);
            }
        }
        public void SetCancelFlag(int flag)
        {
            cancelFlag = flag;
        }
        public void AddCertification(CertificationDM certificationDM)
        {
            certificationRenderComponents.RenderAddComponents();

            if (!string.IsNullOrEmpty(certificationDM.certificateName))
            {
                certificationRenderComponents.CertificationTextBoxLocator().SendKeys(certificationDM.certificateName);
            }
            if (!string.IsNullOrEmpty(certificationDM.certifiedFrom))
            {
                certificationRenderComponents.CertifiedFromTextBoxLocator().SendKeys(certificationDM.certifiedFrom);
            }
            if (!string.IsNullOrEmpty(certificationDM.year))
            {
                certificationRenderComponents.ChooseYearDDLocator().SendKeys(certificationDM.year);
            }
            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                certificationRenderComponents.AddButtonLocator().Click();
            }
            else
            { cancelFlag = 0; certificationRenderComponents.CancelButtonLocator().Click(); }

            Thread.Sleep(2000);

        }

    }
}
