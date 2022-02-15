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


namespace PL
{
    public partial class DataManagementForm : Form
    {
        private List<UniversalElectronicCard> universalElectronicCards;

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
            administrativeServiceCenter.AddBankCard();
            administrativeServiceCenter.AddInsurancePolicy();
            bindingElectonicCardSourse.Add(administrativeServiceCenter.ReturnNewElectronicCard());
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            UpdataInfo();
        }


        private void UpdataInfo()
        {
            var elctronicCard = bindingElectonicCardSourse.Current;
            if (elctronicCard != null)
            {
                if (elctronicCard is UniversalElectronicCard electronicCard)
                {

                    bindingIDCodeSource.Clear();
                    bindingPassportSource.Clear();
                    bindingBankCardSource.Clear();
                    bindingAccountSource.Clear();

                    bindingIDCodeSource.Add(electronicCard.IDCode);
                    bindingPassportSource.Add(electronicCard.Passport);
                    bindingBankCardSource.Add(electronicCard.BankCard);
                    bindingAccountSource.Add(electronicCard.BankCard);
                }
            }
        }


        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {

        }
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

        }
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {

        }
    }
}
