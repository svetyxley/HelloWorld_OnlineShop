using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Wpf_Menu
{
    static class GettingData
    {
        public static ulong GetINN(TextBox textbox)
        {
            ulong intResult = 0;

            if (string.IsNullOrEmpty(textbox.Text))
            {
                MessageBox.Show("Данные ИНН отсутствуют");
                return intResult;
            }
            else if (textbox.Text.Length != 10)
            {
                MessageBox.Show("Ошибка формата данных ИНН");
                return intResult;
            }

            return intResult = ulong.Parse(textbox.Text);
        }


        public static string GetString(TextBox textbox)
        {
            if (textbox.Text == null)
            {
                MessageBox.Show("Ошибка при получении текста");
            }

            return textbox.Text.Trim();
        }

        public static DateOnly GetDataOnly(TextBox textbox)
        {

            DateOnly defaultValue = DateOnly.MinValue;


            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                MessageBox.Show("Ошибка, данные не заполнены");
                return defaultValue;
            }

            if (DateOnly.TryParse(textbox.Text.Trim(), out DateOnly result))
            {
                return result; // Возвращаем успешно преобразованную дату
            }
            else
            {
                MessageBox.Show("Ошибка при преобразовании текста в дату");
                return defaultValue;
            }
        }

        public static MailAddress GetEmail(TextBox textbox)
        {
            try
            {

                Regex emailCheck = new Regex()
                emailCheck.Match(textbox.Text);


                return new MailAddress(textbox.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат email.");
                return null; // Возвращаем null в случае ошибки
            }
        }

        public static string GetPhoneNumber(TextBox textbox)
        {
            Regex regex2 = new Regex("@\"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$\"");

            // Проверка соответствия текста регулярному выражению
            if (regex2.IsMatch(textbox.Text))
            {
                return textbox.Text;
            }

            else
            {
                MessageBox.Show("Неверный формат email.");
                return string.Empty;
            }
        }


    }
}
