using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.Controllers.sms
{
 
    public class SmsAero
    {
        /// 

        /// API V2 example
        /// 

        public static async void ExampleUsage()
        {
            SmsAero smsc = new SmsAero("narytososet@yandex.ru", "1jWxv7AbcPveD4GrJ3zhtqmBKZEu");

            // Отправка SMS сообщений
            string[] numbers = { "89065528630"};
            Task<string> oo= smsc.SmsSend("Привет!", numbers: numbers);

          
             
        }

        private readonly System.Net.Http.HttpClient _http = new HttpClient();

        // Константы с параметрами отправки
        private readonly bool Debug = false; // Вывод информации об отправке
        private readonly string _from; //

        /// 

        ///
        /// 

        /// логин
        /// ваш api-key
        /// подпись отправителя
        public SmsAero(string smsAeroLogin, string smsAeroApiKey, string from = "SMS Aero")
        {
            _from = UrlEncode(from);

            var basicAuthData =
                Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                    .GetBytes(smsAeroLogin + ":" + smsAeroApiKey));

            // Авторизация по умолчанию для HttpClient
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", basicAuthData);
        }

        /// 

        /// Отправка SMS сообщения
        /// 

        /// Канал отправки
        /// Текст сообщения
        /// Номер телефона
        /// Номера телефона
        /// Дата для отложенной отправки сообщения
        /// url для отправки статуса сообщения в формате http://mysite.com или https://mysite.com (в ответ система ждет статус 200)
        /// Подпись отправителя
        /// string(json)
        public async Task<string> SmsSend(string text, string number = "",
            string[] numbers = null, DateTime? dateSend = null, string callbackUrl = "", string sign = "")
        {
            var data = $"sign={(sign == "" ? _from : UrlEncode(sign))}&text={UrlEncode(text)}";

            if (number != "") data += $"&number={number}";
            if (numbers != null) data += numbers.Aggregate("", (s, s1) => $"{s}&numbers[]={s1}");
            if (dateSend != null) data += $"&dateSend={ToUnixTime((DateTime)dateSend)}";
            if (callbackUrl != "") data += $"&callbackUrl={UrlEncode(callbackUrl)}";

            return await Send(data, "sms/send");
        }

        /// 

        /// Проверка статуса SMS сообщения
        /// 

        /// Идентификатор сообщения
        /// string(json)
        public async Task CheckSend(int id)
            => await Send($"id={id}", "sms/status");

        /// 

        /// Получение списка отправленных sms сообщений
        /// 

        /// Фильтровать сообщения по номеру телефона
        /// Фильтровать сообщения по тексту
        /// Номер страницы
        /// string(json)
        public async Task<string> SmsList(string number = "", string text = "", int? page = null)
        {
            var data = "";

            if (number != "") data += $"number={number}&";
            if (text != "") data += $"text={UrlEncode(text)}&";
            if (page != null) data += $"page={page}";

            return await Send(data, "sms/list");
        }

        /// 

        /// Запрос баланса
        /// 

        /// string(json)
        public async Task Balance()
            => await Send("balance");

        /// 

        /// Тестовый метод для проверки авторизации
        /// 

        /// string(json)
        public async Task Auth()
            => await Send("auth");

        /// 

        /// Получение платёжных карт
        /// 

        /// string(json)
        public async Task Cards()
            => await Send("cards");

        /// 

        /// Пополнение баланса
        /// 

        /// Сумма пополнения
        /// Идентификационный номер карты
        /// string(json)
        public async Task AddBalance(int sum, int cardId)
            => await Send($"sum={sum}&cardId={cardId}", "balance/add");

        /// 

        /// Запрос тарифа
        /// 

        /// string(json)
        public async Task Tariffs()
            => await Send("tariffs");

        /// 

        /// Добавление подписи
        /// 

        /// Имя подписи
        /// string(json)
        public async Task SignAdd(string name)
            => await Send($"name={name}", "sign/add");

        /// 

        /// Получить список подписей
        /// 

        /// string(json)
        public async Task SignList()
            => await Send("sign/list");

        /// 

        /// Добавление группы
        /// 

        /// Имя группы
        /// string(json)
        public async Task GroupAdd(string name)
            => await Send($"name={UrlEncode(name)}", "group/add");

        /// 

        /// Удаление группы
        /// 

        /// Идентификатор группы
        /// string(json)
        public async Task GroupDelete(int id)
            => await Send($"id={id}", "group/delete");

        /// 

        /// Получение списка групп
        /// 

        /// Пагинация
        /// string(json)
        public async Task GroupList(int page = 0)
            => await Send(page == 0 ? "" : $"page={page}", "group/list");

        /// 

        /// Добавление контакта
        /// 

        /// Номер абонента
        /// Идентификатор группы
        /// Дата рождения абонента
        /// Пол
        /// Фамилия абонента
        /// Имя абонента
        /// Отчество абонента
        /// Свободный параметр
        /// Свободный параметр
        /// Свободный параметр
        /// string(json)
        public async Task<string> ContactAdd(string number, int? groupId = null, DateTime? birthday = null, Sex? sex = null,
            string lname = "", string fname = "", string sname = "", string param1 = "", string param2 = "",
            string param3 = "")
        {
            var data = $"number={number}";

            if (groupId != null) data += $"&groupId={groupId}";
            if (birthday != null) data += $"&birthday={ToUnixTime((DateTime)birthday)}";
            if (sex != null) data += $"&sex={sex.ToString()}";
            if (lname != "") data += $"&lname={lname}";
            if (fname != "") data += $"&fname={fname}";
            if (sname != "") data += $"&sname={sname}";
            if (param1 != "") data += $"¶m1={UrlEncode(param1)}";
            if (param2 != "") data += $"¶m2={UrlEncode(param2)}";
            if (param3 != "") data += $"¶m3={UrlEncode(param3)}";

            return await Send(data, "contact/add");
        }

        /// 

        /// Удаление контакта
        /// 

        /// Идентификатор абонента
        /// string(json)
        public async Task ContactDelete(int id)
            => await Send($"id={id}", "contact/delete");

        /// 

        /// Список контактов
        /// 

        /// Номер абонента
        /// Идентификатор группы
        /// Дата рождения абонента
        /// Пол
        /// Фамилия абонента
        /// Имя абонента
        /// Отчество абонента
        /// string(json)
        public async Task<string> ContactList(string number = "", int? groupId = null, DateTime? birthday = null, Sex? sex = null,
            string lname = "", string fname = "", string sname = "")
        {
            var data = "";

            if (number != "") data += $"number={number}&";
            if (groupId != null) data += $"groupId={groupId}&";
            if (birthday != null) data += $"birthday={ToUnixTime((DateTime)birthday)}&";
            if (sex != null) data += $"sex={sex.ToString()}&";
            if (lname != "") data += $"lname={lname}&";
            if (fname != "") data += $"fname={fname}&";
            if (sname != "") data += $"sname={sname}";

            return await Send(data, "contact/list");
        }

        /// 

        /// Добавление в чёрный список
        /// 

        /// Номер абонента
        /// Номера телефонов
        /// 
        public async Task<string> BlackListAdd(string number = "", string[] numbers = null)
        {
            var data = "";

            if (number != "") data += $"number={number}&";
            if (numbers != null) data += numbers.Aggregate("", (s, s1) => $"{s}numbers[]={s1}&");

            return await Send(data, "blacklist/add");
        }

        /// 

        /// Удаление из черного списка
        /// 

        /// Идентификатор абонента
        /// string(json)
        public async Task BlackListDelete(int id)
            => await Send($"id={id}", "blacklist/delete");

        /// 

        /// Список контактов в черном списке
        /// 

        /// Номер абонента
        /// Пагинация
        /// string(json)
        public async Task<string> BlackListGet(string number = "", int page = 0)
        {
            var data = "";

            if (number != "") data += $"number={number}&";
            if (page > 0) data += $"page={page}&";

            return await Send(data, "blacklist/list");
        }

        // ReSharper disable once InconsistentNaming
        /// 

        /// Создание запроса на проверку HLR
        /// 

        /// Номер абонента
        /// Номера телефонов
        /// string(json)
        public async Task<string> CheckHLR(string number = "", string[] numbers = null)
        {
            var data = "";

            if (number != "") data += $"number={number}&";
            if (numbers != null) data += numbers.Aggregate("", (s, s1) => $"{s}numbers[]={s1}&");

            return await Send(data, "hlr/status");
        }

        /// 

        /// Определение оператора
        /// 

        /// Номер абонента
        /// Номера телефонов
        /// string(json)
        public async Task<string> NumberOperator(string number = "", string[] numbers = null)
        {
            var data = "";

            if (number != "") data += $"number={number}&";
            if (numbers != null) data += numbers.Aggregate("", (s, s1) => $"{s}numbers[]={s1}&");

            return await Send(data, "number/operator");
        }

        /// 

        /// Отправка Viber-рассылок
        /// 

        /// Канал отправки Viber
        /// Текст сообщения
        /// Номер телефона
        /// Номера телефонов. Максимальное количество 50
        /// ID группы по которой будет произведена рассылка. Для выбора всех контактов необходимо передать значение "all"
        /// Картинка кодированная в base64 формат, не должна превышать размер 300 kb. Отправка поддерживается только в 3 форматах: png, jpg, gif. Перед кодированной картинкой необходимо указывать её формат. Пример: jpg#TWFuIGlzIGRpc3Rpbmd1aXNoZ. Отправка доступна только методом POST.
        ///     Параметр передается совместно с textButton и linkButton
        /// Текст кнопки. Максимальная длина 30 символов. Параметр передается совместно с imageSource и linkButton
        /// Ссылки для перехода при нажатие кнопки. Ссылка должна быть с указанием http:// или https://. Параметр передается совместно с imageSource и textButton
        /// Дата для отложенной отправки рассылки
        /// Подпись для SMS-рассылки. Используется при выборе канала "Viber-каскад" (channel=CASCADE). Параметр обязателен
        /// Канал отправки SMS-рассылки. Используется при выборе канала "Viber-каскад" (channel=CASCADE). Параметр обязателен
        /// Текст сообщения для SMS-рассылки. Используется при выборе канала "Viber-каскад" (channel=CASCADE). Параметр обязателен
        /// Максимальная стоимость SMS-рассылки. Используется при выборе канала "Viber-каскад" (channel=CASCADE). Если параметр не передан, максимальная стоимость будет рассчитана автоматически
        /// Подпись отправителя
        /// string(json)
        public async Task<string> ViberSend(ViberChannel channel, string text, string number = "",
            string[] numbers = null, string groupId = "", string imageSource = "", string textButton = "",
            string linkButton = "", DateTime? dateSend = null, string signSms = "", string channelSms = "",
            string textSms = "", int? priceSms = null, string sign = "")
        {
            var data = $"sign={(sign == "" ? _from : sign)}&channel={channel.ToString()}&text={UrlEncode(text)}";

            if (number != "") data += $"&number={number}";
            if (numbers != null) data += numbers.Aggregate("", (s, s1) => $"{s}&numbers[]={s1}");
            if (groupId != "") data += $"&groupId={groupId}";
            if (imageSource != "") data += $"&imageSource={imageSource}";
            if (textButton != "") data += $"&textButton={UrlEncode(textButton)}";
            if (linkButton != "") data += $"&linkButton={UrlEncode(linkButton)}";
            if (dateSend != null) data += $"&dateSend={ToUnixTime((DateTime)dateSend)}";
            if (signSms != "") data += $"&signSms={signSms}";
            if (channelSms != "") data += $"&channelSms={channelSms}";
            if (textSms != "") data += $"&textSms={textSms}";
            if (priceSms != null) data += $"&priceSms={priceSms}";

            return await Send(data, "viber/send", HttpMethod.Post);
        }

        /// 

        /// Статистика по Viber-рассылке
        /// 

        /// Идентификатор Viber-рассылки в системе
        /// string(json)
        public async Task<string> ViberStatistic(int sendingId)
        {
            var data = $"sendingId={sendingId}";
            return await Send(data, "viber/statistic");
        }

        /// 

        /// Список Viber-рассылок
        /// 

        /// string(json)
        public async Task ViberList()
            => await Send("viber/list");

        /// 

        /// Список доступных подписей для Viber-рассылок
        /// 

        /// string(json)
        public async Task ViberSignList()
            => await Send("viber/sign/list");

        #region enums

        public enum ViberChannel
        {
            // ReSharper disable once InconsistentNaming
            /// 

            /// Инфоподпись
            /// 

            INFO,

            // ReSharper disable once InconsistentNaming
            /// 

            /// Официальный Viber
            /// 

            OFFICIAL,

            // ReSharper disable once InconsistentNaming
            /// 

            /// Viber каскад
            /// 

            CASCADE
        }

        public enum Sex
        {
            // ReSharper disable once InconsistentNaming
            male,
            // ReSharper disable once InconsistentNaming
            female
        }

        #endregion

        #region ПРИВАТНЫЕ МЕТОДЫ

        /// 

        /// вывод сообщений в консоль
        /// 

        private static void _PrintDebug(string url, string str)
        {
            Console.WriteLine(url);
            Console.WriteLine(str);
            Console.ReadLine();
        }

        /// 

        /// отправка
        /// 

        /// API метод
        /// string(json)
        private async Task Send(string method)
            => await Send("", method);

        /// 

        /// Отправка
        /// 

        /// передаваемые данные
        /// API метод
        /// POST или GET запрос
        /// string(json)
        private async Task<string> Send(string data, string method, HttpMethod httpMethod = null)
        {
            var url = "https://gate.smsaero.ru/v2/" + method;
            httpMethod = HttpMethod.Get;
            // формируем запрос
            HttpRequestMessage request = null;

            if (httpMethod == null || httpMethod == HttpMethod.Get)
                request = new HttpRequestMessage(httpMethod, url + "?" + data);

            if (httpMethod == HttpMethod.Post)
                request = new HttpRequestMessage(httpMethod, url)
                {
                    Content = new StringContent(data)
                };

            if (request == null)
                throw new Exception($"{nameof(httpMethod)} value exception");

            // асинхронно отправляем запрос
            var response = await _http.SendAsync(request);

            // проверяем статус код ответа, если не 200 бросаем исключение
            response.EnsureSuccessStatusCode();

            // асинхронно читаем тело ответа сервера
            var responseBody = await response.Content.ReadAsStringAsync();

            // если отладка включена пишем в консоль ответ сервера
            if (Debug) _PrintDebug(url, responseBody);

            return responseBody;
        }

        private static int ToUnixTime(DateTime time)
        {
            return (int)(time - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        private string UrlEncode(string data)
        {
            return HttpUtility.UrlEncode(data);
        }

        #endregion
    }
}
