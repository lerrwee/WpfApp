using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    partial class Partner 
    {
        public string Discont
        { 
            get
            {
                return "Скидка";
            } 
        }

        public string Type_Name
        {
            get
            {
                return $"{Partner_type.Partner_type1} | {Partner_name}";
            }
        }

        public string FIO
        {
            get
            {
                return $"{Familia_director} {Name_director} {Othestvo_director}";
            }
        }

        public string Rey
        {
            get
            {
                return $"Рейтинг {Reiting}";
            }
        }                
    }

    partial class Partner_products
    {
        public string NameProduct
        {
            get
            {
                return Product.Name_product;
            }
        }

        public string Kolichectvo
        {
            get
            {
                return $"Количество: {Kolvo}";
            }
        }

        public string Data
        {
            get
            {
                return $"Дата продажи: {Data_prodaz}";
            }
        }       
    }

    partial class Partner_type
    {
        public override string ToString()
        {
            return Partner_type1;
        }
    }
}
