﻿using System;
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
        public static bool GetINN(TextBox textbox, out ulong result)
        {
            if (string.IsNullOrEmpty(textbox.Text))
            {
                MessageBox.Show("Данные ИНН отсутствуют");
                result = 0;
                return false;
            }
            else if (textbox.Text.Length != 10)
            {
                MessageBox.Show("Ошибка формата данных ИНН");
                result = 0;
                return false;
            }

            result  = ulong.Parse(textbox.Text);
            return true;
        }

        public static bool GetString(TextBox textbox, out string result)
        {
            if (textbox.Text == null)
            {
                MessageBox.Show("Ошибка при получении текста");
                result = string.Empty;
                return false;
            }

            result = textbox.Text.Trim();
            return true;
        }

        public static bool GetDataOnly(TextBox textbox, out DateOnly result)
        {

            DateOnly defaultValue = DateOnly.MinValue;


            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                MessageBox.Show("Ошибка, данные не заполнены");
                textbox.Clear();
                result = defaultValue;
                return false;
            }

            else if (DateOnly.TryParse(textbox.Text.Trim(), out result))
            {
                return true; // Возвращаем успешно преобразованную дату
            }
            else
            {
                MessageBox.Show("Ошибка при преобразовании текста в дату");
                result = defaultValue;
                textbox.Clear();
                return false;
            }
        }

        public static bool GetEmail(TextBox textbox, out string result)
        {
            try
            {
                if(Regex.IsMatch(textbox.Text.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    result = textbox.Text;
                    return true;
                }

                throw new FormatException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат email.");
                textbox.Clear();
                result = string.Empty;
                return false; // Возвращаем null в случае ошибки
            }
        }

        public static bool GetPhoneNumber(TextBox textbox, out string result)
        {
            Regex regex2 = new Regex("@\"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$\"");

            // Проверка соответствия текста регулярному выражению
            if (regex2.IsMatch(textbox.Text))
            {
                result = textbox.Text;
                return true;
            }

            else
            {
                MessageBox.Show("Неверный формат email.");
                result = string.Empty;
                return false;
            }
        }


    }
}
