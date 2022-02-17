using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using DAL.Interface;
using DAL.Provider;
using DataService;
using DataService.Interface;

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
    public partial class DataManagementForm : Form
    {
        #region Data

        private CreationForm creationForm;

        private readonly string idBuiderPath;
        private readonly string dbConectionPath;

        private IPassportService passportService;
        private IDCodeBuilder iDCodeBuilder;
        private IBank monoBank;
        private IBank privaeBank;
        private IInsuranceAgency insuranceAgency;

        #endregion


        #region Subsystem

        private void CreateSuportService(string path)
        {
            passportService = new UkrainianPassportService();
            iDCodeBuilder = IDCodeBuilder.GetUniqueIDBuilder(path);
            monoBank = new MonoBank();
            privaeBank = new PrivateBank();
            insuranceAgency = new UHGInsuranceAgency();
        }
        private void SubscribeUpdateHandler()
        {
            bindingElectonicCardSourse.AddingNew += UpdateInfoHandler;
            bindingElectonicCardSourse.CurrentItemChanged += UpdateInfoHandler;
            bindingNavigatorAddNewItem.Click += UpdateInfoHandler;
        }

        #endregion


        private void bindingNavigatorAddNewItem_Click_NewForm(object sender, EventArgs e)
        {
            if (creationForm == null)
            {
                creationForm = new CreationForm(this, idBuiderPath);
                creationForm.Show();
            }

            if (creationForm.IsDisposed)
            {
                creationForm = new CreationForm(this, idBuiderPath);
                creationForm.Show();
            }
        }



        #region DAL_Conection

        IDataProvider<List<UniversalElectronicCard>> dataProvider;
        IEntityService<List<UniversalElectronicCard>> entityService;

        private void ConectionDB(string path)
        {
            dataProvider = new BinaryProvider<List<UniversalElectronicCard>>(path);
            entityService = new EntityService<List<UniversalElectronicCard>>(dataProvider);
        }
        private List<UniversalElectronicCard> GetData()
        {
            List<UniversalElectronicCard> data;

            try
            {
                data = entityService.GetData();
            }
            catch (Exception)
            {
                data = new List<UniversalElectronicCard>();
                entityService.AddNewData(data);
            }

            return data;
        }
        private bool SaveChange()
        {
            var objData = bindingElectonicCardSourse.List;
            List<UniversalElectronicCard> data = new List<UniversalElectronicCard>(objData.Count);

            foreach (var item in objData)
            {
                data.Add(item as UniversalElectronicCard);
            }

            return entityService.AddNewData(data);
        }

        #endregion


        //ctor
        public DataManagementForm(string idPath, string dbPath)
        {
            InitializeComponent();

            idBuiderPath = idPath;
            dbConectionPath = dbPath;

            CreateSuportService(idBuiderPath);
            SubscribeUpdateHandler();

            ConectionDB(dbConectionPath);
            AddDataInSourseBinding(GetData());
        }



        #region InteractWithBindingSourse

        public void AddElectronicCard(IUniversalElectronicCard electronicCard)
        {
            bindingElectonicCardSourse.Add(electronicCard as UniversalElectronicCard);
        }
        private void AddDataInSourseBinding(List<UniversalElectronicCard> data)
        {
            foreach (var item in data)
                bindingElectonicCardSourse.Add(item);
        }

        #endregion


        #region UpdateDataOnForm

        private void ClearData()
        {
            bindingIDCodeSource.Clear();
            bindingPassportSource.Clear();
            bindingBankCardSource.Clear();
            bindingAccountSource.Clear();
            bindingInsurancePolicySource.Clear();
        }
        private void UpdateInfo()
        {
            var objEletronicCard = bindingElectonicCardSourse.Current;
            if (objEletronicCard != null)
            {
                if (objEletronicCard is UniversalElectronicCard electronicCard)
                {
                    textBoxBriefName.Text = electronicCard?.Name;
                    textBoxBriefSurname.Text = electronicCard?.Surname;

                    bindingIDCodeSource.Clear();
                    bindingPassportSource.Clear();
                    bindingBankCardSource.Clear();
                    bindingAccountSource.Clear();
                    bindingInsurancePolicySource.Clear();

                    bindingIDCodeSource.Add(electronicCard?.IDCode);
                    bindingPassportSource.Add(electronicCard?.Passport);
                    bindingBankCardSource.Add(electronicCard?.BankCard);
                    bindingAccountSource.Add(electronicCard?.BankCard);
                    bindingInsurancePolicySource.Add(electronicCard?.InsurancePolicy);


                    textBoxBankOwnerCode.Text = electronicCard?.BankCard?.OwnerCode?.GetUniqueIdCode ?? null;


                    textBoxPolicyOwnerCode.Text = electronicCard?.InsurancePolicy?.OwnerCode?.GetUniqueIdCode ?? null;
                    textBoxPolicyCardNumber.Text = electronicCard?.InsurancePolicy?.PaymentMethod?.BankCardNumber ?? null;
                    textBoxPosileCurrentSum.Text = (electronicCard?.InsurancePolicy?.PaymentMethod?.CurrentSum ?? null).ToString();

                    checkBoxActivated.Checked = electronicCard?.InsurancePolicy?.IsValid() ?? false;
                }
            }
            else
            {
                ClearData();
            }
        }
        private void UpdateInfoHandler(object sender, EventArgs e) => UpdateInfo();

        #endregion


        #region HendlerForNavigator

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e) => UpdateInfo();
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e) => UpdateInfo();
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e) => UpdateInfo();
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e) => UpdateInfo();
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) => UpdateInfo();

        #endregion



        #region ButtonHandler


        private void buttonActivate_Click(object sender, EventArgs e)
        {
            var objEletronicCard = bindingElectonicCardSourse.Current;
            if (objEletronicCard != null)
            {
                if (objEletronicCard is UniversalElectronicCard electronicCard)
                {
                    if (electronicCard?.InsurancePolicy?.Activate() ?? false)
                    {
                        UpdateInfo();
                        MessageBox.Show("Страховка активована успішно!!!");
                    }
                    else
                    {
                        UpdateInfo();
                        MessageBox.Show("Страховку неможливо активувати!!!");
                    }
                }
            }
        }


        #region WorkWithBankCard

        private void buttonPutMoney_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBoxSum.Text, out decimal sum))
            {
                textBoxSum.Text = string.Empty;
                MessageBox.Show("Ведіть коректну суму");

                return;
            }

            var objEletronicCard = bindingElectonicCardSourse.Current;
            if (objEletronicCard != null)
            {
                if (objEletronicCard is UniversalElectronicCard electronicCard)
                {
                    if (electronicCard?.BankCard == null)
                    {
                        UpdateInfo();
                        MessageBox.Show("Спочатку потрібно створити банківську карту");
                        return;
                    }


                    if (electronicCard?.BankCard?.PutMoney(sum) ?? false)
                    {
                        UpdateInfo();
                        MessageBox.Show("Рахунок поповнено");
                    }
                    else
                    {
                        UpdateInfo();
                        MessageBox.Show("Неможливо поповнити рахунок");
                    }

                    textBoxSum.Text = string.Empty;
                }
            }
        }
        private void buttonWithdrawMoney_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBoxSum.Text, out decimal sum))
            {
                textBoxSum.Text = string.Empty;
                MessageBox.Show("Ведіть коректну суму");

                return;
            }

            var objEletronicCard = bindingElectonicCardSourse.Current;
            if (objEletronicCard != null)
            {
                if (objEletronicCard is UniversalElectronicCard electronicCard)
                {
                    if (electronicCard?.BankCard == null)
                    {
                        UpdateInfo();
                        MessageBox.Show("Спочатку потрібно створити банківську карту");
                        return;
                    }


                    if (electronicCard?.BankCard?.WithdrawMoney(sum) ?? false)
                    {
                        UpdateInfo();
                        MessageBox.Show("Кошти успішно зняті");
                    }
                    else
                    {
                        UpdateInfo();
                        MessageBox.Show("Неможливо зняти кошти з рахунку");
                    }

                    textBoxSum.Text = string.Empty;
                }
            }
        }

        #endregion


        #region CreatorMethodHandler

        private void buttonAddNewPassport_Click(object sender, EventArgs e)
        {
            if (RegEx.Name.IsMatch(textBoxName.Text))
            {
                if (RegEx.Surname.IsMatch(textBoxSurname.Text))
                {
                    if (RegEx.Age(dateTimePicker.Value))
                    {
                        var objEletronicCard = bindingElectonicCardSourse.Current;
                        if (objEletronicCard != null)
                        {
                            if (objEletronicCard is UniversalElectronicCard electronicCard)
                            {
                                electronicCard.AddNewPassport(passportService.CreatePassport(textBoxName.Text, textBoxSurname.Text, dateTimePicker.Value));

                                UpdateInfo();

                                textBoxName.Text = string.Empty;
                                textBoxSurname.Text = string.Empty;
                                dateTimePicker.Value = DateTime.Now;

                                MessageBox.Show("Новий паспорт успішно створено");
                            }
                        }
                    }
                    else
                    {
                        dateTimePicker.Value = DateTime.Now;
                        MessageBox.Show("Неможливо додати дату яка більша за теперішне");
                    }
                }
            }
        }
        private void buttonNewBankCard_Click(object sender, EventArgs e)
        {
            var objEletronicCard = bindingElectonicCardSourse.Current;
            if (objEletronicCard != null)
            {
                if (objEletronicCard is UniversalElectronicCard electronicCard)
                {

                    if (radioButtonMonoBank.Checked)
                    {
                        electronicCard.AddNewBankCard(monoBank.CreateUniversalBankCard(electronicCard?.IDCode));
                    }
                    else
                    {
                        electronicCard.AddNewBankCard(privaeBank.CreateUniversalBankCard(electronicCard?.IDCode));
                    }

                    UpdateInfo();

                    MessageBox.Show("Нова банківська карта успішно створена");
                }
            }
        }
        private void buttonNewInsurmcePolicy_Click(object sender, EventArgs e)
        {
            var objEletronicCard = bindingElectonicCardSourse.Current;
            if (objEletronicCard != null)
            {
                if (objEletronicCard is UniversalElectronicCard electronicCard)
                {
                    if (electronicCard.BankCard == null)
                    {
                        MessageBox.Show("Спочатку потрібно створити банківську карту");
                        return;
                    }

                    electronicCard.AddNewInsurancePolicy(insuranceAgency.CreateUniversalInsurancePolicy(electronicCard.IDCode, electronicCard.BankCard));

                    UpdateInfo();

                    MessageBox.Show("Створено новий страховий поліс");
                }
            }
        }

        #endregion


        #endregion



        private void DataManagementForm_FormClosing(object sender, FormClosingEventArgs e) => SaveChange();
        private void buttonExit_Click(object sender, EventArgs e) => Application.Exit();

    }
}
