using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;

using CallApi.DTO;

namespace CallApi
{
    public class Consumo
    {
        public List<DTORegistrado> ListSPregistradoAnonymous { get; set; }
        public List<Registrado> ListRegistradoToken { get; set; }

        public string RutaApiAnonymous = "http://localhost:11585/api/Registrados/dto";
        public string RutaApiPostAnonymous = "http://localhost:11585/api/Registrados/PostObject";
        public string RutaApiPostAuthToken = "http://localhost:11585/api/Token/authenticate";
        public string RutaApiGetToken = "http://localhost:11585/api/Registrados";

        public string PostOK;
        public string Token;

        HttpClient _client;

        public Consumo()
        {
            _client = new HttpClient();
        }

        public void ConsumoAPi()
        {
            while(true)
            {
                try
                {

                    Console.WriteLine("************* Get Anonymous ***********");
                    //GetApiAnonymous();

                    Console.WriteLine("************* Post Anonymous ***********");
                    //PostApiAnonymous();

                    Console.WriteLine("************* Login ***********");
                    LoginPost();

                    Console.WriteLine("************* Get JWT ***********");
                    GetApiJWT();

                    System.Threading.Thread.Sleep(10000);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep(15000);
                }
            }
        }

        public async void LoginPost()
        {
            AuthInfo auth = new AuthInfo();
            auth.Username = "demo";
            auth.Password = "123456";

            var uri = new Uri(RutaApiPostAuthToken);

            var json = JsonConvert.SerializeObject(auth);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responseTokenAuth = null;

            responseTokenAuth = await _client.PostAsync(uri, content);

            if (responseTokenAuth.IsSuccessStatusCode)
            {
                Token = responseTokenAuth.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                Console.WriteLine(Token);

            }

        }

        public async void GetApiJWT()
        {
            ListRegistradoToken = new List<Registrado>();

            var uri = new Uri(RutaApiGetToken);

            if (string.IsNullOrEmpty(Token))
            {
                Console.WriteLine("No existe token aun: " + DateTime.Now);

            }
            else 
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var ResponseApi = await _client.GetAsync(uri);

                if (ResponseApi.IsSuccessStatusCode)
                {
                    var ContentApi = await ResponseApi.Content.ReadAsStringAsync();

                    ListRegistradoToken = JsonConvert.DeserializeObject<List<Registrado>>(ContentApi);

                }

                if (ListRegistradoToken.Count > 0)
                {
                    for (int i = 0; i < ListRegistradoToken.Count; i++)
                    {
                        Console.WriteLine(ListRegistradoToken[i].Identificacion + "-" + ListRegistradoToken[i].NombresCompletos);

                    }

                }

            }


        }

        public async void GetApiAnonymous()
        {
            ListSPregistradoAnonymous = new List<DTORegistrado>();

            var uri = new Uri(RutaApiAnonymous);

            var ResponseApiAnonymous = await _client.GetAsync(uri);

            if (ResponseApiAnonymous.IsSuccessStatusCode)
            {
                var ContentApiAnonymous = await ResponseApiAnonymous.Content.ReadAsStringAsync();

                ListSPregistradoAnonymous = JsonConvert.DeserializeObject<List<DTORegistrado>>(ContentApiAnonymous);

            }

            if (ListSPregistradoAnonymous.Count > 0)
            {
                for (int i=0; i < ListSPregistradoAnonymous.Count;  i++)
                {
                    Console.WriteLine(ListSPregistradoAnonymous[i].DNI +"-" + ListSPregistradoAnonymous[i].Registrado);

                }

            }

        }

        public async void PostApiAnonymous()
        {

            var uri = new Uri(RutaApiPostAnonymous);

            Registrado item = new Registrado();

            item.Identificacion = "0919172551009";
            item.Nombres = "VPR Consumo Api";
            item.Apellidos = "Anonymous";

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage ResponsePost = null;

            ResponsePost = await _client.PostAsync(uri, content);

            if (ResponsePost.IsSuccessStatusCode)
            {
                PostOK = ResponsePost.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                Console.WriteLine(PostOK);

            }

        }

     }
}
