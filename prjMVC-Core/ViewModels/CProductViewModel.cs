using prjMVC_Core.Models;
using System.ComponentModel;

namespace prjMVC_Core.ViewModels
{
    public class CProductViewModel
    {

        private TProduct _product;


        public CProductViewModel()
        {
            _product = new TProduct();
        }

        public TProduct Product 
        { 
            get { return _product; } 
            set { _product = value; }
        }




        public int FId 
        {
            get { return _product.FId; }
            set { _product.FId = value; }
        }

        [DisplayName("品名")]
        public string? FName 
        {
            get { return _product.FName; }
            set { _product.FName = value; }
        }

        [DisplayName("庫存")]
        public int? FQty 
        {
            get { return _product.FQty; }
            set { _product.FQty = value; }
        }

        [DisplayName("成本")]
        public decimal? FCost 
        { 
            get { return _product.FCost; }
            set { _product.FCost = value; }
        }

        [DisplayName("售價")]
        public decimal? FPrice 
        {
            get { return _product.FPrice; }
            set { _product.FPrice = value; }
        }

        public string? FPhotoPath 
        {
            get { return _product.FPhotoPath; }
            set { _product.FPhotoPath = value; }
        }

        public IFormFile photo { get; set; }
    }
}
