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
        /// <summary>
        /// кнопка добавить  обраозование
        /// </summary>
        Button bTcontrolEducations;
      

      /// <summary>
      /// льготы
      /// </summary>
        CheckBox chekLigoty;

        /// <summary>
        /// гендер
        /// </summary>
        ComboBox cbSStatus;
        ComboBox cbGender;

        CheckBox chekOlimp;


        private int count; // кол-во  страниц на форме 
        private int countMax;
        private List<ControlList> controls = new List<ControlList>();




        private  int countEducatom ;

        public MainWindow()
        {
            InitializeComponent();
            count = 0;

            countEducatom = 1;

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
            controls.Add(StartName(0));
            controls.Add(StartReg(1));
            controls.Add(StartVremennoeProzhvanie(2));
            controls.Add(StartDocumebt(3));
            controls.Add(StartEducations(4));
            controls.Add(StartOtherDocument(5));
            controls.Add(StartMilitaryService(6));
            controls.Add(StartOther(7));
            controls.Add(StartliGoty(8));

            controls.Add(StartOlimp(9));


            // todo : методы добавдяем сюда 
        }

        /// <summary>
        /// Олимпиады
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private ControlList StartOlimp(int c)
        {
            List<Control> controlsStartOlimp= new List<Control>();
          
            var lBOlimp = new Label();
            lBOlimp.Content = "Раскажите есть ли  у вас индивидуальные  достижения или  целевой договор?";

            chekOlimp = new CheckBox();
            chekOlimp.Content = "Да/Нет";
            chekOlimp.HorizontalAlignment = HorizontalAlignment.Stretch;
            chekOlimp.Checked += ChekOlimp_Checked;
            chekOlimp.Unchecked += ChekOlimp_Unchecked;

            var lBOlimp1 = new Label();

            lBOlimp1.Content = "Укажите какие  у вас есть достижения из  списка";

            lBOlimp1.Margin = new Thickness(0, 15, 0, 0);


            controlsStartOlimp.AddRange (
                new List<Control> 
                { 
                    lBOlimp , chekOlimp
                });

            controlsStartOlimp.Add(lBOlimp1);

            controlsStartOlimp.AddRange(GetContorlChekBox());

           

            return  new ControlList (  c ,  controlsStartOlimp);
        }

        private IEnumerable<CheckBox> GetContorlChekBox()
        {

            List<CheckBox> CheckBoxVS = new List<CheckBox>();

            CheckBox checkBox = new CheckBox();
            checkBox.Content = "наличие статуса победителя и призера в олимпиадах и иных интеллектуальных и (или)"+ 
            "творческих конкурсах, мероприятиях, направленных на развитие интеллектуальных и творческих"+
           " способностей, способностей к занятиям физической культурой и спортом, интереса к научной"+
           " (научно-исследовательской), инженерно - технической, изобретательской, творческой, "+
            "физкультурно - спортивной деятельности, а также на пропаганду научных знаний, творческих и"+
              "спортивных достижений; " ;


            CheckBox checkBox1 = new CheckBox();
            checkBox1.Content = "наличие статуса победителя и призера в олимпиадах и иных наличие" +
                " у поступающего статуса победителя и призера чемпионата по профессиональному"+ 
            "мастерству среди инвалидов и лиц с ограниченными возможностями здоровья «Абилимпикс» ";

            CheckBox checkBox2 = new CheckBox();
            checkBox2.Content = "наличие у поступающего статуса победителя и призера чемпионата профессионального "+
            "мастерства, проводимого союзом «Агентство развития профессиональных сообществ и рабочих"+
            "кадров Молодые профессионалы (Ворлдскиллс Россия)» либо международной организацией"  +
            " «WorldSkills International»";


            CheckBox checkBox3 = new CheckBox();
            checkBox3.Content = "Наличие целевого договора";

            CheckBoxVS.AddRange( new List<CheckBox> { checkBox, checkBox1, checkBox2, checkBox3 });

            foreach (var items in  CheckBoxVS )
            {
                items.Visibility = Visibility.Collapsed;
                items.HorizontalContentAlignment = HorizontalAlignment.Left;
            }

            return CheckBoxVS;

        }

        private void ChekOlimp_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chekOlimp.IsChecked == false)
            {
               for ( int  i = 2; i < controls[9].Controls.Count; i++  )
                {
                    controls[9].Controls[i].Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ChekOlimp_Checked(object sender, RoutedEventArgs e)
        {
           if (  chekOlimp.IsChecked == true)
            {
                foreach( var it in  controls[9].Controls)
                {
                    it.Visibility = Visibility.Visible;
                }
            }
        }

        private ControlList StartliGoty(int c)
        {
            List<Control> controlsStartliGoty = new List<Control>();

            var lBMs = new Label();
            lBMs.Content = "Раскажите есть ли  у вас льготы?";
            chekLigoty = new CheckBox();
            chekLigoty.Content = "Да/Нет";
            chekLigoty.HorizontalAlignment = HorizontalAlignment.Stretch;
            chekLigoty.Checked += ChekLigoty_Checked;
            chekLigoty.Unchecked += ChekLigoty_Unchecked;

            controlsStartliGoty.AddRange( new List<Control> { lBMs , chekLigoty });

            controlsStartliGoty.AddRange(Getligoty());

            return new ControlList(c, controlsStartliGoty);
        }
     

        private IEnumerable<Control> Getligoty()
        {
            List<Control> controlsStartliGoty = new List<Control>();

            var lb0 = new Label();
            lb0.Content = "Укажите из списка  какие  у вас есть льготы";

            var lb1 = new Label();

            var s1  = "дети-сироты и дети, оставшиеся без попечения родителей,"
            +"лица из числа детей-сирот и детей, оставшихся без попеч"+
           "ения родителей";

            var ch1 = new CheckBox();
            ch1.Content = s1;
            ch1.HorizontalAlignment = HorizontalAlignment.Center;

            var lb2 = new Label();
            var s2 = "дети-инвалиды, инвалиды I и II групп, инвалиды с детства";
            var ch2 = new CheckBox();
            ch2.Content = s2;
            ch2.HorizontalAlignment = HorizontalAlignment.Center;

            var lb3 = new Label();
            var s3 = "лица, подвергшиеся воздействию радиации вследствие " +
                "катастрофы на Чернобыльской АЭС и иных радиационных катастроф, " +
                "вследствие ядерных испытаний на Семипалатинском полигоне";
            var ch3 = new CheckBox();
            ch3.Content = s3;
            ch3.HorizontalAlignment = HorizontalAlignment.Center;

            var lb4 = new Label();
            var s4 = "лица, имеющие право на получение государственной социальной помощи";
            var ch4 = new CheckBox();
            ch4.Content = s4;
            ch4.HorizontalAlignment = HorizontalAlignment.Center;

            var lb5 = new Label();
            var s5 = "лица из числа граждан, проходивших в течение не менее " +
                "трех лет военную службу по контракту в Вооруженных Силах " +
                "Российской Федерации, во внутренних войсках Министерства" +
                " внутренних дел Российской Федерации, в инженерно- технических, " +
                "дорожно-строительных воинских формированиях при федеральных органах" +
                " исполнительной власти и в спасательных воинских формированиях федерального " +
                "органа исполнительной власти, уполномоченного на решение задач в области" +
                " гражданской обороны, Службе внешней разведки Российской Федерации," +
                " органах федеральной службы безопасности, органах государственной охраны " +
                "и федеральном органе обеспечения мобилизационной подготовки органов " +
                "государственной власти Российской Федерации на воинских должностях, " +
                "подлежащих замещению солдатами, матросами, сержантами, старшинами, " +
                "и уволенных с военной службы по основаниям, предусмотренным подпунктами " +
                "«б» – «г» пункта 1, подпунктом «а» пункта 2 и подпунктами «а» - «в» пункта 3 " +
                "статьи 51 Федерального закона от 28.03.1998  № 53-ФЗ «О воинской обязанности" +
                " и военной службе»";

            var ch5 = new CheckBox();
            ch5.Content = s5;
            ch5.HorizontalAlignment = HorizontalAlignment.Center;
            ch5.HorizontalContentAlignment = HorizontalAlignment.Stretch;

            controlsStartliGoty.AddRange(
                new List<Control>
                {
                  lb0 ,lb1, ch1 , lb2, ch2 ,lb3, ch3 ,lb4, ch4 ,lb5, ch5 
                }
                );

            foreach ( var  item in  controlsStartliGoty)
            {
                item.Visibility = Visibility.Collapsed;
                item.HorizontalAlignment = HorizontalAlignment.Left;
            }

            return controlsStartliGoty;
        }

        private void ChekLigoty_Checked(object sender, RoutedEventArgs e)
        {
            if (chekLigoty.IsChecked == true)
            {
               foreach (  var  items in   controls[8].Controls)
               {
                    items.Visibility = Visibility.Visible;
               }
            }
            else
            {
                for (int i = 2; i < controls[8].Controls.Count; i++)
                {
                    controls[8].Controls[i].Visibility = Visibility.Collapsed;
                }
            }
            SetStep(controls[count]);
        }

        private void ChekLigoty_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chekLigoty.IsChecked == false)
            {
                for (int i = 2; i < controls[8].Controls.Count; i++)
                {
                    controls[8].Controls[i].Visibility = Visibility.Collapsed;
                }
               }
            SetStep(controls[count]);
        }


        private ControlList StartOther(int c)
        {
            List<Control> controlsStartOther = new List<Control>();

            var lBMs = new Label();
            lBMs.Content = "Укажите является ли ваша семья многодетной";
            var chekMs = new CheckBox();
            chekMs.Content = "Да/Нет";
            chekMs.HorizontalAlignment = HorizontalAlignment.Center;

            var lBother = new Label();
            lBother.Content = "Укажите нуждаетесь ли вы в общежитии?";
            var chekOb = new CheckBox();
            chekOb.Content = "Да/Нет";
            chekOb.HorizontalAlignment = HorizontalAlignment.Center;

            var lBother1 = new Label();
            lBother1.Content = "Укажите нуждаетесь ли вы в спец. условиях при про" +
                "проведении вступительных экзаменов?";
            var chekOsYs = new CheckBox();
            chekOsYs.Content = "Да/Нет";
            chekOsYs.HorizontalAlignment = HorizontalAlignment.Center;

            var lBother2 = new Label();
            lBother2.Content = "Раскажите о себе, чем вы увлекаетесь, что  вам  интересно";
            var tBOSebe = new TextBox();

            var lBother3 = new Label();
            lBother3.Content = "Раскажите как вы узнали о  СГК";
            var tBoSGK = new TextBox();

            var lBEmail = new Label();
            lBEmail.Content = "Укажите ваш eMail";
            var tBEmail    = new TextBox();

            var lBVc = new Label();
            lBVc.Content = "Укажите ваш id в Контекте";
            var tBVc = new TextBox();

            controlsStartOther.AddRange(new List<Control>()
            {
                lBMs, chekMs ,lBother , chekOb , lBother1, chekOsYs , lBother2 , tBOSebe  , lBother3 ,tBoSGK,
                lBEmail ,  tBEmail , lBVc , tBVc
            });

            return new ControlList(c, controlsStartOther);
        }

        /// <summary>
        /// Военный учет
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private ControlList StartMilitaryService(int c)
        {
            List<Control> controlsMilitaryService = new List<Control>();
            
            var lBother = new Label();
            lBother.Content = "Отношение к военной службе";

            var cBMilitaryService = new ComboBox();
            cBMilitaryService.Items.Add("Невоеннообязан");
            cBMilitaryService.Items.Add("Военнообязан");
            cBMilitaryService.Items.Add("Служба по призиву");
            cBMilitaryService.Items.Add("Служба по контракту");

            var  lBspase = new Label();
            lBspase.Content = "Заполняются если есть";
            lBspase.Margin = new Thickness(0, 10, 0, 0);

            var lBPripYdv = new Label();
            lBPripYdv.Content = "Номер приписного свидетельства";
            var bTPripYdv = new TextBox();
            
            var lBspase1 = new Label();
            lBspase1.Margin = new Thickness(0, 10, 0, 10);

            var lBVbs = new Label();
            lBVbs.Content = "Серия военного билета";
            var bTVbs = new TextBox();


            var lBVb = new Label();
            lBVb.Content = "Номер военного билета";
            var bTVb = new TextBox();

            var lBVbPY = new Label();
            lBVbPY.Content = "Причина увольнения";
            var bTVbPY = new TextBox();

            var lBVbData = new Label();
            lBVbData.Content = "Дата увольнения";
            var dtVB = new   DatePicker();

            controlsMilitaryService.AddRange(
            new List<Control>
            {
                   lBother, cBMilitaryService,  lBspase , lBPripYdv , bTPripYdv ,  lBspase1, lBVbs ,bTVbs ,lBVb,bTVb,
                   lBVbPY  ,bTVbPY , lBVbData , dtVB
            });
            return new ControlList( c, controlsMilitaryService);
        }

        /// <summary>
        /// полис   и  сниллс  и   инн 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private ControlList StartOtherDocument(int c)
        {
            List<Control> controlsOtherDocument = new List<Control>();

            var lBother = new Label();
            lBother.Content = "Еще немного о себе";

            var lBSSved = new Label();
            lBSSved.Content = "Введите номер страхового свидетельства (СНИЛС)";
            var tBSSved = new TextBox();

            var lBMedSved = new Label();
            lBMedSved.Content = "Введите номер медецинского полиса";
            var tlBMedSved = new TextBox();

            var lBMedSvedSerya = new Label();
            lBMedSvedSerya.Content = "Введите серию медецинского полиса (старый  образец)";
            var tlBMedSvedSerya = new TextBox();

            var lBINN = new Label();
            lBINN.Content = "Введите номер ИНН";
            var tlINN = new TextBox();

            controlsOtherDocument.AddRange(
               new List<Control>
               {
                   lBother, lBSSved , tBSSved , lBMedSved , tlBMedSved , lBMedSvedSerya , tlBMedSvedSerya
                   , lBINN , tlINN
               }   );

            return new ControlList(c, controlsOtherDocument);
        }

        /// <summary>
        /// Временное  проживание
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private ControlList StartVremennoeProzhvanie(int c)
        {
            return new ControlList(c, GetAddressControlls("Введите адрес временного проживания" +
                " (Если адрес совпадает с адресом регестрации оставьте поля пустыми" +
                ""));
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
            
            controlsStart.Add(labelSurrname);
            controlsStart.Add(tbSurrname);
            controlsStart.Add(labelName);
            controlsStart.Add(tbName);
            controlsStart.Add(labelPatronumic);
            controlsStart.Add(tbPatronumic);

            var lBDataBD = new Label();

            lBDataBD.Content = "Введите вашу дату рождения";
            var DataBD = new DatePicker();

            var lBGender = new Label();
            lBGender.Content = "Введите ваш пол";

            cbGender = new ComboBox();
            cbGender.Items.Add("Мужской");
            cbGender.Items.Add("Женский");
            cbGender.SelectionChanged += CbGender_SelectionChanged;

            var  lBSStatus = new Label();
            lBSStatus.Content = "Введите ваше семейное положение";

            cbSStatus = new ComboBox();
            cbSStatus.Items.Add("Холост");
            cbSStatus.Items.Add("Женат");
            cbSStatus.Items.Add("Замужем");
            cbSStatus.Items.Add("Не замужем");

            controlsStart.Add(lBDataBD);
            controlsStart.Add(DataBD);

            controlsStart.Add(lBGender);
            controlsStart.Add(cbGender);

            controlsStart.Add(lBSStatus);
            controlsStart.Add(cbSStatus);

            return new ControlList(c, controlsStart);
        }

        private void CbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbGender.SelectedIndex == 0)
            {
                cbSStatus.Items.Clear();
                cbSStatus.Items.Add("Холост");
                cbSStatus.Items.Add("Женат");
                return;
            }

          if (cbGender.SelectedIndex == 1)
          {
                cbSStatus.Items.Clear();
                cbSStatus.Items.Add("Замужем");
                cbSStatus.Items.Add("Не замужем");
                return;
          }
            cbSStatus.Items.Clear();
            cbSStatus.Items.Add("Холост");
            cbSStatus.Items.Add("Женат");
            cbSStatus.Items.Add("Замужем");
            cbSStatus.Items.Add("Не замужем");
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

        /// <summary>
        /// Документ  УЛ
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        ControlList StartDocumebt(int c)
        {

            List<Control> controlsDobument = new List<Control>();

            var lbGrashd = new Label();
            lbGrashd.Content = "Гражданство";
            var tBGrashd = new TextBox();
            tBGrashd.Text = "РФ";

            var lbNameDocumentEducation  = new Label();
            lbNameDocumentEducation.Content = "Введите название документа удостоверяющий личность";

            var vs = new List<string>
            {
                "Паспорт гражданина РФ" ,
                "Заграничный паспорт гражданина РФ",
                "Паспорт гражданина иностранного государства",
                "Свидетельство о рождении",
                "Военный билет",
                "Дипломатический паспорт гражданина РФ",
                "Паспорт моряка",
                "Свидетельство о рождении, выданное уполномоченным органом иностранного государства",
                "Временное удостоверение личности гражданина РФ",
                "Вид на жительство",
                "Удостоверение личности гражданина Российской Федерации в виде пластиковой карты",
                "Служебный паспорт",
                "Удостоверение личности военнослужащего",
                " Удостоверение беженца",
                "Свидетельство о рассмотрении ходатайства о признании гражданина беженцем",
                "Иной документ, удостоверяющий личность",
            }; 

            var cBDocumentEducation = new ComboBox() { ItemsSource = vs }; //todo: переписать  из источника
            cBDocumentEducation.SelectedIndex = 0;

            var lbSeria = new Label();
            lbSeria.Content = "Серия";
            var tBSeria = new TextBox();

            var lbCode = new Label();
            lbCode.Content = "Номер";
            var tBCode = new TextBox();

            var lbKemV = new Label();
            lbKemV.Content = "Кем выдан";
            var tBKemV = new TextBox();

            var lbData = new Label();
            lbData.Content = "Дата Выдачи докумета";

            var data = new DatePicker();

            var lbMr = new Label();
            lbMr.Content = "Место рождения (как в паспорте, без сокращений)";
            var tBMr = new TextBox();

            controlsDobument.AddRange(new List<Control>
            {
                lbGrashd, tBGrashd, lbNameDocumentEducation, cBDocumentEducation,

                lbSeria, tBSeria , lbCode ,tBCode , lbKemV, tBKemV,lbData, data ,  lbMr,tBMr
            }
                );

            return new ControlList(c, controlsDobument);
        }

        /// <summary>
        /// Обарозование 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        ControlList StartEducations (int c  )
        {
            int countEducatom = 1;
            List<Control> controlsEducations = new List<Control>();

            controlsEducations = GetEdicatiun(countEducatom);
          
            return new ControlList (c, controlsEducations );
        }

        /// <summary>
        /// Получаем  образование  
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<Control>  GetEdicatiun( int  count)
        {
            List<Control> controlsEducations = new List<Control>();

            bTcontrolEducations = new Button();

            bTcontrolEducations.Content = "Добавить  еще одно образование";
            bTcontrolEducations.Click += BTcontrolEducations_Click;

            bTcontrolEducations.Margin = new Thickness(0, 10, 0, 0);

            var lbEducations = new Label();
            lbEducations.Content = "Укажите ваше образование";

            List<string> vs = new List<string>()
            {
                "Основное общее (9 кл.)",
                "Среднее общее (11 кл.)",
                "Начальное профессиональное",
                "Среднее профессиональное",
                "Высшее"
            };
            var cBTypeEducation = new ComboBox();
            cBTypeEducation.ItemsSource = vs;

            var lbdocument = new Label();
            lbdocument.Content = "Тип документа";

            var cBTypeDok = new ComboBox();
            cBTypeDok.Items.Add("Аттестат");
            cBTypeDok.Items.Add("Диплом");
            cBTypeDok.Items.Add("Справка");
            
            var lbSeria = new Label();
            lbSeria.Content = "Серия";
            var tBSeria = new TextBox();

            var lbCode = new Label();
            lbCode.Content = "Номер";
            var tBCode = new TextBox();
           
            var lbData = new Label();
            lbData.Content = "Дата Выдачи докумета";
            var data = new DatePicker();

            controlsEducations.AddRange(new List<Control>()
            {
                lbEducations , cBTypeEducation,  lbdocument ,cBTypeDok ,  lbSeria ,tBSeria
                , lbCode , tBCode , lbData , data , 
            });

            var vsadress = GetAddressControlls("Укажите  адрес учебного заведения");

            vsadress = vsadress.Take(11).ToList(); // todo: неполный адресс берем отсюда 
            controlsEducations.AddRange(vsadress);

            var lbNameYch = new Label();
            lbNameYch.Content = "Укажите полное название  учебного заведения";
            var tBNameYch = new TextBox();

            var lbSrBall = new Label();
            lbSrBall.Content = "Укажите cредний рейтинг вашего  документа об образовании";
            var tBSrBall = new TextBox();

            controlsEducations.AddRange(new List<Control>()
            {
                lbNameYch , tBNameYch , lbSrBall , tBSrBall
            });

            controlsEducations.Add(bTcontrolEducations);

            return controlsEducations;
        }

        /// <summary>
        /// добавляет  образование 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTcontrolEducations_Click(object sender, RoutedEventArgs e)
        {
            string text ="Если у вас есть еще один документ об образовании нажмите OK и продолжите заполнять информацию  ниже" +
                " если  вы указали все документы  нажмите Отмена" 
               ;

            if (MessageBoxResult.OK == MessageBox.Show(text, "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation))
            {
                countEducatom++;
                controls[4].Controls.AddRange(GetEdicatiun(countEducatom));
                SetStep(controls[count]);
            }
        }

        /// <summary>
        /// получает  форму ввода адреса  
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
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
