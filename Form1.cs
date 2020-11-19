using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        List<Drinks> drinksList = new List<Drinks>();  //список напитков
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)  //Обработчик кнопки "Перезаполнить"
        {
            this.drinksList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 15; ++i)
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2 для выбора напитка
                {
                    case 0:
                        this.drinksList.Add(Juice.Generate());
                        break;
                    case 1:
                        this.drinksList.Add(Soda.Generate());
                        break;
                    case 2:
                        this.drinksList.Add(Alcohol.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        private void ShowInfo() // Функция, выводящая информацию о количестве напитков на форму
        {
            listOfDrinks.Clear();  //Список очереди напитков
            // счетчики под каждый тип
            int juiceCount = 0;
            int sodaCount = 0;
            int alcoholCount = 0;

            foreach (var drink in this.drinksList)
            {
                //Проверка на то, какой объект типа Drinks
                if (drink is Juice)
                {
                    juiceCount += 1;
                    listOfDrinks.Text += "Сок\n";  //Добавление "Сок" в список очереди
                }
                else if (drink is Soda)
                {
                    sodaCount += 1;
                    listOfDrinks.Text += "Газировка\n";  //Добавление "Газировка" в список очереди
                }
                else if (drink is Alcohol)
                {
                    alcoholCount += 1;
                    listOfDrinks.Text += "Алкоголь\n";  //Добавление "Алкоголь" в список очереди
                }
            }

            // Вывод количества объектов на форму
            txtInfo.Text = "               Сок              Газировка              Алкоголь";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("                 {0}                         {1}                            {2}", juiceCount, sodaCount, alcoholCount);
        }

        private void btnGet_Click(object sender, EventArgs e)  //Обработчик кнопки "Взять"
        {
            if (this.drinksList.Count == 0)
            {
                txtOut.Text = "Пусто ... больше нет напитков?";
                return;
            }
            var drink = this.drinksList[0];
            this.drinksList.RemoveAt(0);

            txtOut.Text = drink.GetInfo();

            ShowInfo();
        }
    }
}
