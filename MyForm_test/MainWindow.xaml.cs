using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyForm_test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

        



    public partial class MainWindow : Window
    {

        private int count;
        private int countMax;
        private List<ControlList> controls = new List<ControlList>();

        public MainWindow()
        {
            InitializeComponent();
            count = 0;
            StartComonent();
            countMax = controls.Count;
            SetStep(controls[count]);
        }

        private void SetStep(ControlList controlList)
        {
            Content.Children.Clear();

           foreach (  var  items in  controlList.Controls)
           {
                if (controlList!=null)
                Content.Children.Add(items);
           }

        }

       
        private void StartComonent()
        {
            controls.Add(StartName( 0));
            controls.Add(StartData(1));
            controls.Add(StartReg(2));

            // todo : методы добавдяем сюда 
        }
       

       /// <summary>
       /// назад 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void bTDown_Click(object sender, RoutedEventArgs e)
        {

            if (count >0)
            {
                count--;
                SetStep(controls[count]);
            }

        }

        /// <summary>
        /// вперед
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bTUp_Click(object sender, RoutedEventArgs e)
        {
            if (count < countMax-1 )
            {
                count++;
                SetStep(controls[count]);
            }
        }


        /// <summary>
        /// фио
        /// </summary>
        /// <returns></returns>
        ControlList StartName(int c)
        {
            List<Control> controlsStart = new List<Control>();

            var labelName = new Label();
            labelName.Content = "Введите ваше имя";

            var labelSurrname = new Label();
            labelSurrname.Content = "Введите вашу фамилию";

            var labelPatronumic = new Label();
            labelPatronumic.Content = "Введите ваше отчество";

            var tbName = new TextBox();
            var tbSurrname = new TextBox();
            var tbPatronumic = new TextBox();

            controlsStart.Add(labelName);
            controlsStart.Add(tbName);
            controlsStart.Add(labelSurrname);
            controlsStart.Add(tbSurrname);
            controlsStart.Add(labelPatronumic);
            controlsStart.Add(tbPatronumic);

            return new ControlList(c, controlsStart);
        }

        /// <summary>
        /// дата , сем стутус  , гнедер 
        /// </summary>
        /// <returns></returns>
        ControlList StartData( int c )
        {

            List<Control> controlsStartData = new List<Control>();
            var lBDataBD = new Label();

            lBDataBD.Content = "Введите вашу дату рождения";
            var DataBD = new DatePicker();

            var lBGender = new Label();
            lBGender.Content = "Введите ваш пол";

            var cbGender = new ComboBox();
            cbGender.Items.Add("Мужской");
            cbGender.Items.Add("Женский");

            var lBSStatus = new Label();
            lBSStatus.Content = "Введите ваше семейное положение";

            var cbSStatus = new ComboBox();
            cbSStatus.Items.Add("Холост");
            cbSStatus.Items.Add("Женат");
            cbSStatus.Items.Add("Замужем");
            cbSStatus.Items.Add("Не замужем");

            controlsStartData.Add(lBDataBD);
            controlsStartData.Add(DataBD);

            controlsStartData.Add(lBGender);
            controlsStartData.Add(cbGender);

            controlsStartData.Add(lBSStatus);
            controlsStartData.Add(cbSStatus);

            return new ControlList(c, controlsStartData);
        }

        /// <summary>
        /// Регестрация 
        /// </summary>
        /// <returns></returns>
        ControlList StartReg(int c)
        {
            List<Control> controlsStarReg = GetAddressControlls("Введите информацию о регистрации (прописка  в  Паспорте)");

            return new ControlList(c, controlsStarReg);
        }

        private static List<Control> GetAddressControlls( string  st)
        {
            List<Control> controlsStarReg = new List<Control>();

            var lBreg = new Label();
            lBreg.Content = st;

            var lBCountry = new Label();
            lBCountry.Content = "Страна";
            var tBCountry = new TextBox();
            tBCountry.Text = "РФ";

            var LbRegion = new Label();
            LbRegion.Content = "Область";
            var tBRegion = new TextBox();
            tBRegion.Text = "Самарская";


            var Lbdistrict = new Label();
            Lbdistrict.Content = "Район";
            var tBdistrict = new TextBox();


            var LbTypeLacality = new Label();
            LbTypeLacality.Content = "Тип Населенного пункта";


            var vs = new List<string>() // список  типов посленений  
            {
                "Город" , "Село" , "Деревня", "ПГТ" , "ЖД Ст."
            };             vs.OrderBy(x => x);


            var cBMTypeLacality = new ComboBox();

            cBMTypeLacality.ItemsSource = vs; // todo : переписать на внешний источник 
            cBMTypeLacality.SelectedIndex = 0;

            var LbSity = new Label();
            LbSity.Content = "Название населенного пункта";
            var tBSity = new TextBox();

            var lBStrit = new Label();
            lBStrit.Content = "Улица";
            var tBStrit = new TextBox();

            var lBHouse = new Label();
            lBHouse.Content = "Номер Дома/Литеры";
            var tBHouse = new TextBox();

            var lBCvatryra = new Label();
            lBCvatryra.Content = "Номер Квартиры";
            var tBCvatryra = new TextBox();

            var lBIndex = new Label();
            lBIndex.Content = "Почтовый  индекс";
            var tBIndex = new TextBox();

            var lBHouseTelefone = new Label();
            lBHouseTelefone.Content = "Домашний телефон";
            var tBHouseTekefone = new TextBox();


            controlsStarReg.AddRange(new List<Control>()
            {
                lBreg , lBCountry ,tBCountry , LbRegion , tBRegion ,
                Lbdistrict , tBdistrict , LbTypeLacality , cBMTypeLacality , LbSity,

                tBSity, 
                lBStrit ,tBStrit ,
                lBHouse , tBHouse , 
                lBCvatryra ,   tBCvatryra ,

                lBIndex , tBIndex ,
                
                lBHouseTelefone , tBHouseTekefone
            });

            return controlsStarReg;
        }
    }

    /// <summary>
    /// Список  контроллеров 
    /// </summary>
    public class ControlList
    {
        public ControlList(int number, List<Control> controls)
        {
            this.Number = number;
            Controls = controls;
        }

        public int  Number {get ; set; }
        public List<Control> Controls { get; set; }
       
    }
}
