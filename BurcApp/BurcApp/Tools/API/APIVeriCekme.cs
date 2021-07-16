using BurcApp.Modals;
using BurcApp.ViewModals;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BurcApp.Tools.API
{
    public class  APIVeriCekme
    {
        private string url = "https://yazilimdelisi.com/api/burclopedi/burclopedi_api/";

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/JSON");

            return client;
        }

        public async Task<string> ReklamAyarlari(string yol)
        {
            HttpClient client = await GetClient();
            string reklamAyari = "";
            var jsonResult = await client.GetStringAsync(url + yol);
            try
            {
                reklamAyari = JsonConvert.DeserializeObject<string>(jsonResult);
            }
            catch { }

            return reklamAyari;
        }

        public async Task<BurcYorumlariViewModal> GetBurcYorumlari(string yol)
        {
            HttpClient client = await GetClient();
            BurcYorumlariViewModal burcYorumlariViewModal = new BurcYorumlariViewModal();
            var jsonResult = await client.GetStringAsync(url + yol);
            try
            {
                burcYorumlariViewModal = JsonConvert.DeserializeObject<BurcYorumlariViewModal>(jsonResult);
            }
            catch
            {
                burcYorumlariViewModal.Hata = true;
            }
            
            return burcYorumlariViewModal;
        }

        public async Task<KullaniciYorumlariViewModal> GetKullaniciYorumlari(string yol)
        {
            HttpClient client = await GetClient();
            KullaniciYorumlariViewModal kullaniciYorumlariViewModal = new KullaniciYorumlariViewModal();
            var jsonResult = await client.GetStringAsync(url + yol);
            try
            {
                kullaniciYorumlariViewModal = JsonConvert.DeserializeObject<KullaniciYorumlariViewModal>(jsonResult);
            }
            catch
            {
                kullaniciYorumlariViewModal.Hata = true;
            }
            

            return kullaniciYorumlariViewModal;
        }

        public async Task<bool> PostKullaniciYorumu(PostKullaniciYorum postKullaniciYorum)
        {
            HttpClient client = await GetClient();
            var content = JsonConvert.SerializeObject(postKullaniciYorum);
            var jsonResult = await client.PostAsync(url, new StringContent(content));

            return jsonResult.IsSuccessStatusCode;
        }
    }
}
