namespace KitapTakipSistemi.Models
{
    public class Kitap
    {
      
        public int Id { get; private set; } 
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public bool Durum { get; set; } 

        public Kitap(int id, string ad, string yazar)
        {
            
            this.Id = id;
            this.Ad = ad;
            this.Yazar = yazar;
            this.Durum = true; 
        }

        
        public override string ToString()
        {
            string durumStr = this.Durum ? "Müsait" : "Ödünçte";
            return $"ID: {this.Id}, Ad: {this.Ad}, Yazar: {this.Yazar}, Durum: {durumStr}";
        }
    }
}