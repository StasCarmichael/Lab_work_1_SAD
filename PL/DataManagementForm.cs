using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using BLL.DataCreationSubsystem.Class;
using BLL.DataCreationSubsystem.Interface;
using BLL.DataPackingSubsystem.Interface;
using BLL.DataPackingSubsystem.Class;
using BLL.DataElectronicCardSubsystem.Class;
using BLL.DataElectronicCardSubsystem.Interface;
using BLL.DataFunctionalSubsystem.Class;
using BLL.DataFunctionalSubsystem.Interface;

namespace PL
{
    public partial class DataManagementForm : Form
    {
        private List<UniversalElectronicCard> universalElectronicCards;

        private void bindingNavigatorAddNewItem_Click_NewForm(object sender, EventArgs e)
        {
            UpdataInfo();
        }

        public DataManagementForm()
        {
            //TODO
            InitializeComponent();

            universalElectronicCards = new List<UniversalElectronicCard>();

            IDCodeBuilder iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder("data.dat");

            var administrativeServiceCenter = new AdministrativeServiceCenter(iDCodeBuilder, new UkrainianPassportService(), new MonoBank(), new UHGInsuranceAgency());


            administrativeServiceCenter.CreateNewUserWithPassport("Stas", "Kyrei", new DateTime(2003, 12, 2));
            administrativeServiceCenter.AddBankCard();
            administrativeServiceCenter.AddInsurancePolicy();
            bindingElectonicCardSourse.Add(administrativeServiceCenter.ReturnNewElectronicCard());


            administrativeServiceCenter.CreateNewUserWithPassport("Ldffdf", "sdfdsf", new DateTime(1996, 4, 8));
            // administrativeServiceCenter.AddBankCard();
            //  administrativeServiceCenter.AddInsurancePolicy();
            bindingElectonicCardSourse.Add(administrativeServiceCenter.ReturnNewElectronicCard());
        }




        private void UpdataInfo()
        {
            var objEletronicCard = bindingElectonicCardSourse.Current;
            if (objEletronicCard != null)
            {
                if (objEletronicCard is UniversalElectronicCard electronicCard)
                {
                    bindingIDCodeSource.Clear();
                    bindingPassportSource.Clear();
                    bindingBankCardSource.Clear();
                    bindingAccountSource.Clear();
                    bindingInsurancePolicySource.Clear();

                    bindingIDCodeSource.Add(electronicCard.IDCode);
                    bindingPassportSource.Add(electronicCard.Passport);
                    bindingBankCardSource.Add(electronicCard.BankCard);
                    bindingAccountSource.Add(electronicCard.BankCard);
                    bindingInsurancePolicySource.Add(electronicCard.InsurancePolicy);

                    textBoxBankOwnerCode.Text = electronicCard?.BankCard?.OwnerCode?.GetUniqueIdCode ?? null;

                    textBoxPolicyOwnerCode.Text = electronicCard?.InsurancePolicy?.OwnerCode?.GetUniqueIdCode ?? null;
                }
            }
        }


        #region HendlerForNavigator

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e) => UpdataInfo();
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e) => UpdataInfo();
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e) => UpdataInfo();
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e) => UpdataInfo();
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) => UpdataInfo();
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e) => UpdataInfo();

        #endregion


        private void buttonActivate_Click(object sender, EventArgs e)
        {
            var objEletronicCard = bindingElectonicCardSourse.Current;
            if (objEletronicCard != null)
            {
                if (objEletronicCard is UniversalElectronicCard electronicCard)
                {
                    if (electronicCard?.InsurancePolicy?.Activate() ?? false)
                    {
                        Update();
                        MessageBox.Show("Страховка активована успішно!!!");
                    }
                    else
                    {
                        MessageBox.Show("Страховку неможливо активувати!!!");
                    }
                }
            }

        }

        private void buttonExit_Click(object sender, EventArgs e) => Application.Exit();

    }
}
