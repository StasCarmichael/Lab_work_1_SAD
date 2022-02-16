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
using BLL.RegExpressions;

namespace PL
{
    public partial class CreationForm : Form
    {

        #region Data

        private DataManagementForm managementForm;

        private AdministrativeServiceCenter administrativeServiceCenter;

        private IPassportService passportService;
        private IDCodeBuilder iDCodeBuilder;
        private IBank monoBank;
        private IBank privaeBank;
        private IInsuranceAgency insuranceAgency;

        #endregion

        private void CreateSuportService(string path)
        {
            passportService = new UkrainianPassportService();
            iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder(path);
            monoBank = new MonoBank();
            privaeBank = new PrivateBank();
            insuranceAgency = new UHGInsuranceAgency();

            administrativeServiceCenter = new AdministrativeServiceCenter(iDCodeBuilder, passportService, monoBank, insuranceAgency);
            administrativeServiceCenter.MessageEvent += AdminCenterHandler;
        }



        public CreationForm(DataManagementForm _managementForm, string idBuilderPath)
        {
            InitializeComponent();

            managementForm = _managementForm;
 
            CreateSuportService(idBuilderPath);
        }



        private void AdminCenterHandler(object sender, string str) => MessageBox.Show(str);


        #region CreationMenu

        private void buttonAddNewUser_Click(object sender, EventArgs e)
        {
            if (RegEx.Name.IsMatch(textBoxName.Text))
            {
                if (RegEx.Surname.IsMatch(textBoxSurname.Text))
                {
                    if (RegEx.Age(dateTimePicker.Value))
                    {
                        administrativeServiceCenter.CreateNewUserWithPassport(textBoxName.Text, textBoxSurname.Text, dateTimePicker.Value);

                        textBoxName.Text = string.Empty;
                        textBoxSurname.Text = string.Empty;
                        dateTimePicker.Value = DateTime.Now;

                        return;
                    }
                    else
                    {
                        dateTimePicker.Value = DateTime.Now;
                        MessageBox.Show("Неможливо додати дату яка більша за теперішне");
                        return;
                    }
                }
            }

            MessageBox.Show("Перевірте коректність вводу даних");
            return;
        }
        private void buttonNewBankCard_Click(object sender, EventArgs e)
        {
            if (radioButtonMonoBank.Checked)
                administrativeServiceCenter.Bank = monoBank;
            else
                administrativeServiceCenter.Bank = privaeBank;

            administrativeServiceCenter.AddBankCard();
        }
        private void buttonNewInsurmcePolicy_Click(object sender, EventArgs e)
        {
            administrativeServiceCenter.AddInsurancePolicy();
        }

        #endregion


        private void CreationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var universalElectronicCard = administrativeServiceCenter.ReturnNewElectronicCard();
            if (universalElectronicCard != null)
            {
                managementForm.AddElectronicCard(administrativeServiceCenter.ReturnNewElectronicCard());
            }
        }
        private void buttonGoBack_Click(object sender, EventArgs e) {this.Close(); this.Dispose(); }


    }
}
