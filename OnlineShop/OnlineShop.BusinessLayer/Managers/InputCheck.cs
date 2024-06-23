using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.Managers
{
    public static class InputCheck
    {
        public static Action<string>? ShowError;


        public static bool GetPriceUint(string textbox, out uint uintPrice)
        {

            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные цены отсутствуют");
                uintPrice = 0;
                return false;
            }
            else if (textbox.Length > 5)
            {
                ShowError.Invoke("Ошибка формата данных цены, слишком большое значение");
                uintPrice = 0;
                return false;
            }

             if(!uint.TryParse(textbox, out uintPrice))
            {
                ShowError.Invoke("Ошибка формата данных цены");
            }

             return true;
        }

        public static bool GetAmountDecimal(string textbox,out decimal result)
        {
            

            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные количества товара отсутствуют");
                result = 0;
                return false;
            }
            else if (textbox.Length > 4)
            {
                ShowError.Invoke("Ошибка формата данных количества товара, слишком большое значение количества");
                result = 0;
                return false;
            }

            if(!decimal.TryParse(textbox, out result))
            {
                ShowError.Invoke("Ошибка формата данных количества товара");
                result = 0;
                return false;
            }
            return true;

        }

        public static bool GetINN(string textbox, out ulong result)
        {
            
            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные ИНН отсутствуют");
                result = 0;
                return false;
            }
            else if (textbox.Length != 10)
            {
                ShowError.Invoke("Ошибка формата данных ИНН");
                result = 0;
                return false;
            }

             if (Regex.IsMatch(textbox, @"^\d{10}$"))
            {
                result = ulong.Parse(textbox);
                return true;
            }

            result = 0;
            return false;
        }

        public static bool GetIdNumber(string textbox, out int idNumber)
        {;

            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные Id отсутствуют");
                idNumber = 0;
                return false;
            }
            else if (textbox.Length > 5)
            {
                ShowError.Invoke("Ошибка формата данных Id");
                idNumber = 0;
                return false;
            }

            if(!int.TryParse(textbox, out idNumber))
            {
                ShowError.Invoke("Ошибка конвертации данных Id");
                idNumber = 0;
                return false;
            }

            return true;
        }

        public static bool GetEDRPOU(string textbox, out string strEDRPOU)
        {
            strEDRPOU = string.Empty;

            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные ЕДРПОУ отсутствуют");
                return false;
            }
            else if (textbox.Length != 8)
            {
                ShowError.Invoke("Ошибка формата данных ЕДРПОУ");
                return false;
            }

            else if (Regex.IsMatch(textbox, @"^\d{8}$"))
            {
                strEDRPOU = textbox;
                return true;
            }

            return false;
        }

        public static string GetString(string textbox)
        {
            string result = string.Empty;

            if (textbox == null)
            {
                ShowError.Invoke("Ошибка при получении текста");
                return result;
            }

            result = textbox.Trim();

            return result;
        }

        public static DateOnly GetDataOnly(string textbox)
        {

            DateOnly result = DateOnly.MinValue;


            if (string.IsNullOrWhiteSpace(textbox))
            {
                ShowError.Invoke("Ошибка, данные даты не заполнены");
                return result;
            }

            else if (!DateOnly.TryParse(textbox.Trim(), out result))
            {
                ShowError.Invoke("Ошибка при преобразовании текста в дату");
            }

            return result;

        }

        public static string GetEmail(string textbox)
        {
            string result = string.Empty;   
            try
            {
                if (Regex.IsMatch(textbox.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    result = textbox;
                    return result;
                }

            }
            catch (Exception)
            {
                ShowError.Invoke("Неверный формат email.");
                result = string.Empty;
            }

            return result;
        }

        public static string GetPhoneNumber(string textbox)
        {
            string result = string.Empty;
            
            Regex regex2 = new Regex("^0\\d{2}-\\d{3}-\\d{2}-\\d{2}$");

            // Проверка соответствия текста регулярному выражению
            if (regex2.IsMatch(textbox))
            {
                result = textbox;
            }

            else
            {
                ShowError.Invoke("Неверный формат телефона.");
                result = string.Empty;
            }
            return result;
        }
    }
}
